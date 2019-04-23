using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : TowerParent
{
    public List<int> targetIndexes = new List<int>();
    void Start()
    {
        TowerManager.Singleton.AddTower(this);
    }

    // Update is called once per frame
    void Update()
    {
        FindTargets();
        Fire();
    }

    public override void FindTargets() {
        for (int i = 0; i < EnemyManager.Singleton.enemyList.Count; i++)
        {
           // if (EnemyManager.Singleton.enemyList[i].enemySpeed > 1.25f) {// Only Targets Bikes
                if (!TargetList.Contains(EnemyManager.Singleton.enemyList[i]))
                {

                    if ((EnemyManager.Singleton.enemyList[i].transform.position - towerPosition).magnitude <= range)
                    {
                        TargetList.Add(EnemyManager.Singleton.enemyList[i]);
                        Fire();
                    }

                }
                else
                {

                    if ((EnemyManager.Singleton.enemyList[i].transform.position - towerPosition).magnitude > range)
                    {
                    EnemyManager.Singleton.enemyList[i].enemySpeed = EnemyManager.Singleton.enemyList[i].enemySpeed / .85f;
                        TargetList.Remove(EnemyManager.Singleton.enemyList[i]);
                    }
                }

           // }
        }
       // SortTargetList();
    }

    public void Fire() {
       
        for (int i = 0; i < TargetList.Count; i++) {

            if (!TargetList[i].slowed)
            {
                TargetList[i].enemySpeed = TargetList[i].enemySpeed * .85f;
                TargetList[i].slowed = true;
             
            }
            
         
        }
        

    }
}
