using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerParent : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float xCoordinate;
    public float yCoordinate;
    public Vector3 towerPosition;
    public float range;
    public string name;
    
    public int cost;
   
    public List<EnemyFinal> TargetList = new List<EnemyFinal>();
   
   


   
    public virtual void FindTargets() {
        for (int i = 0; i < EnemyManager.Singleton.enemyList.Count; i++) {
            
            if (!TargetList.Contains(EnemyManager.Singleton.enemyList[i]))
            {
                
                if ((EnemyManager.Singleton.enemyList[i].transform.position - towerPosition).magnitude <= range)
                {
                    TargetList.Add(EnemyManager.Singleton.enemyList[i]);
                }

            }
            else {

                if ((EnemyManager.Singleton.enemyList[i].transform.position - towerPosition).magnitude > range){
                    TargetList.Remove(EnemyManager.Singleton.enemyList[i]);
                  }
            }

        }
        SortTargetList();
    }





    public void SortTargetList() {
        EnemyFinal Temp;
        if (TargetList.Count > 1) {
            for (int i = 0; i < TargetList.Count; i++) {
                if (i != TargetList.Count - 1) {
                    if (TargetList[i].timer < TargetList[i + 1].timer) {
                        Temp = TargetList[i];
                        TargetList[i] = TargetList[i + 1];
                        TargetList[i + 1] = Temp;

                    }
                }

            }
        }
    }


}
