using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerParent : MonoBehaviour
{
    // Start is called before the first frame update

    public float fireRate;
    public float xCoordinate;
    public float yCoordinate;
    public Vector3 towerPosition;
    public float range;
    public int damage;
    public int cost;
    public int Level;
    public List<EnemyFinal> TargetList = new List<EnemyFinal>();
    public Projectile currProjectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindTargets() {
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
    }


}
