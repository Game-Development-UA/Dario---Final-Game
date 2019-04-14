using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using TMPro;

public class TowerButton : MonoBehaviour
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
    public Player player;
    private bool towerClicked;

    void Start()
    {
        towerClicked = false;
        
        player = GameObject.FindWithTag("player").GetComponent<Player>();

        
    }

  
    void Update()
    {
        if (towerClicked) {
            CreateTower();
            

        }
    }

    public void Click() {

        if (currTower.cost <=  player.money) {
            if (currTower.name == "Health")
            {
                print("clicked on health");
                towerClicked = false;
                UpdatePlayerInfo();
            }
            else
            {
                // TextBox.text = "You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.";
                UIManager.Singleton.UpdateTextBox("You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.");
                UpdatePlayerInfo();
                towerClicked = true;
                
            }
        }
    }

    public void CreateTower() {
        //TextBox.text = "You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.";
        UIManager.Singleton.UpdateTextBox("You have selected the " + currTower.name + " Tower. Click on any area of dirt to place the tower.");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseLoc.z = 0f;
            TowerParent tempTower = Instantiate(currTower, mouseLoc, Quaternion.identity);
            tempTower.xCoordinate = mouseLoc.x;
            tempTower.yCoordinate = mouseLoc.y;
            towerClicked = false;
            UpdateToOriginalText();
        }


    }
    public void UpdateToOriginalText() {
        UIManager.Singleton.UpdateTextBox("Hover over a tower icon to learn its details. \nClick on the tower to purchase it. \nClick on the music icon to turn music on or off.");
        //TextBox.text = "Hover over a tower icon to learn its details. \nClick on the tower to purchase it. \nClick on the music icon to turn music on or off.";

    }

    public void onHover() {
        print("Tower Name: " + currTower.name);
        if (currTower.name == "Health")
        {
            UIManager.Singleton.UpdateTextBox("Purchase Health. This option gives you one health point for the following cost:" +
                "\nCost: " + currTower.cost);
            /*TextBox.text = "Purchase Health. This option gives you one health point for the following cost:" +
                "\nCost: " + currTower.cost
                ;*/
        }
        else
        {
            UIManager.Singleton.UpdateTextBox("This is the " + currTower.name + " Tower. \n" +
                "Fire Rate: " + currTower.fireRate +
                "\nRange: " + currTower.range +
                "\nDamage: " + currTower.damage +
                "\nCost: " + currTower.cost);

            /*TextBox.text = "This is the " + currTower.name + " Tower. \n" +
                "Fire Rate: " + currTower.fireRate +
                "\nRange: " + currTower.range +
                "\nDamage: " + currTower.damage +
                "\nCost: " + currTower.cost
                ;*/
        }
    }

    public void UpdatePlayerInfo() {
        print("Update Player Info - Tower: " + currTower.name);
        if (currTower.name == "Health")
        {
            UIManager.Singleton.UpdateHealthText(1);
            UIManager.Singleton.UpdateMoneyText(-currTower.cost);
            //UIManager.Singleton.UpdateMoneyText()
            /*player.health++;
            player.money = player.money - currTower.cost;
            HealthText.text = "" + player.health;
            MoneyText.text = "" + player.money;*/
        }
        else {
            UIManager.Singleton.UpdateMoneyText(-currTower.cost);
            /*player.money = player.money - currTower.cost;
            MoneyText.text = "" + player.money;*/
        }
    }
}
