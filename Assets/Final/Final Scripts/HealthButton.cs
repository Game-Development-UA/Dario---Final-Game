using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthButton : MonoBehaviour
{
    public string name;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        name = "Health";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth(){
        if (Player.Singleton.money > cost) {
            UIManager.Singleton.UpdateHealthText(1, -cost);
        }
    }

    public void onHover() {
        UIManager.Singleton.UpdateTextBox("This is the incerase " + name + " button. \n" +
           "Purchase an increment in health for: \n" + cost);
    }

    public void HoverExit() {
        UIManager.Singleton.UpdateTextBox("Hover over a tower icon to learn its details. \nClick on the tower to purchase it. \nClick on the music icon to turn music on or off.");

    }

}
