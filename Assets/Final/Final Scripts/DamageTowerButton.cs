using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTowerButton : TowerButton
{
   //private DamageTower currDamage = currTower.GetComponent<DamageTower>();
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

    public override void onHover() {
        if (!base.towerClicked)
        {
            UIManager.Singleton.UpdateTextBox("This is the " + currTower.name + " Tower. \n" +
                      "Fire Rate: " + currTower.GetComponent<DamageTower>().fireRate +
                      "\nRange: " + currTower.range +
                      "\nDamage: " + currTower.GetComponent<DamageTower>().damage +
                      "\nCost: " + currTower.cost);
        }
    }
}
