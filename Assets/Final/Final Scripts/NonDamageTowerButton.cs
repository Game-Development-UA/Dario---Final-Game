using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDamageTowerButton : TowerButton
{
    // Start is called before the first frame update
    
    // Start is called before the first frame update
    void Start()
    {
        base.towerClicked = false;

    }


    void Update()
    {
        if (base.towerClicked)
        {

            CreateTower();
        }


    }

    public void onHover()
    {
        if (!base.towerClicked)
        {
            UIManager.Singleton.UpdateTextBox("This is the " + base.currTower.name + " Tower. \n" +
                       "It slows down bike opponents within it's range." +
                      "\nRange: " + base.currTower.range +
                      
                      "\nCost: " + base.currTower.cost);
        }
    }
}
