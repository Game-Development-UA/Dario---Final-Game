using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using TMPro;

public abstract class TowerButton : MonoBehaviour
{
    // Start is called before the first frame update
    /*public float fireRate;
    public float range;
    public int damage;
    public string name;
    public int cost;
    public int Level;*/


    public TowerParent currTower;
  
    public TextMeshProUGUI TextBox;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI ScoreText;
    public bool towerClicked;




    public void Click() {

        if (currTower.cost <=  Player.Singleton.money) {

                // TextBox.text = "You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.";
                UIManager.Singleton.UpdateTextBox("You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.");
                UpdatePlayerInfo();
                towerClicked = true;
                
            
        }
    }

    public void CreateTower() {
        //TextBox.text = "You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.";
        // UIManager.Singleton.UpdateTextBox("You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.");
        //print("create tower: before if clicked");
        if (Input.GetKey(KeyCode.Mouse0))
         {
            Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (ValidClickedLocation(Input.mousePosition))
                {

                 mouseLoc.z = 0f;
                 TowerParent tempTower = Instantiate(currTower, mouseLoc, Quaternion.identity);
                 tempTower.towerPosition = new Vector3(mouseLoc.x, mouseLoc.y, 0f);
                 tempTower.xCoordinate = mouseLoc.x;
                 tempTower.yCoordinate = mouseLoc.y;
                 towerClicked = false;
                    // Path.Singleton.acceptableLocation = true;
                 UpdateToOriginalText();

             }
             else {
                    UIManager.Singleton.UpdateTextBox("Cannot Place Tower here. Pick another spot.");

                }

         }


    }
    public void UpdateToOriginalText() {
        if (!towerClicked) {
            UIManager.Singleton.UpdateTextBox("Hover over a tower icon to learn its details. \nClick on the tower to purchase it. \nClick on the music icon to turn music on or off.");
            //TextBox.text = "Hover over a tower icon to learn its details. \nClick on the tower to purchase it. \nClick on the music icon to turn music on or off.";
        }
    }

    public virtual void onHover() {
        if (!towerClicked)
        {

            /*  if (currTower.name == "Health")
              {
                  UIManager.Singleton.UpdateTextBox("Purchase Health. This option gives you one health point for the following cost:" +
                      "\nCost: " + currTower.cost);

              }*/


            /*  UIManager.Singleton.UpdateTextBox("This is the " + currTower.name + " Tower. \n" +
                  "Fire Rate: " + currTower.fireRate +
                  "\nRange: " + currTower.range +
                  "\nDamage: " + currTower.damage +
                  "\nCost: " + currTower.cost);

          */
        }
    }

    public void UpdatePlayerInfo() {
        print("Update Player Info - Tower: " + currTower.name);
      /*  if (currTower.name == "Health")
        {
            UIManager.Singleton.UpdateHealthText(1);
            UIManager.Singleton.UpdateMoneyText(-currTower.cost);

        }*/
        //else {
            UIManager.Singleton.UpdateMoneyText(-currTower.cost);
           
        //}
    }

    public bool ValidClickedLocation(Vector3 mouseLoc) {
        bool goodSpot = true;
        
        Ray ray = Camera.main.ScreenPointToRay(mouseLoc);

        RaycastHit2D hit = Physics2D.Raycast(new Vector3(ray.origin.x, ray.origin.y, 0f), ray.direction);
        if (hit.collider == null)
        {
            goodSpot = true;
        }
        else {
            print(hit.collider);
            goodSpot = false;
        }

        return goodSpot;

    }
}
