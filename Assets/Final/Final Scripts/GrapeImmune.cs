using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeImmune : DamageTower
{
    // Start is called before the first frame update
    public override void FindTargets() {
        for (int i = 0; i < EnemyManager.Singleton.enemyList.Count; i++)
        {
            if (EnemyManager.Singleton.enemyList[i].secondName != "Grape") {
               
                if (!TargetList.Contains(EnemyManager.Singleton.enemyList[i]))
                {

                    if ((EnemyManager.Singleton.enemyList[i].transform.position - towerPosition).magnitude <= range)
                    {
                        print(EnemyManager.Singleton.enemyList[i].secondName);
                        TargetList.Add(EnemyManager.Singleton.enemyList[i]);
                    }

                }
                else
                {

                    if ((EnemyManager.Singleton.enemyList[i].transform.position - towerPosition).magnitude > range)
                    {
                        TargetList.Remove(EnemyManager.Singleton.enemyList[i]);
                    }
                }
            }


        }
        SortTargetList();
    }
}
