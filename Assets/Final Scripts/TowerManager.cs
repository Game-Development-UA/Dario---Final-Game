using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TowerParent> TowersList = new List<TowerParent>();
    public static TowerManager Singleton;

    void Awake() {
        Singleton = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveFromAllTowers(EnemyFinal Enemy) {
        for (int i = 0; i < TowersList.Count; i++) {
            for (int j = 0; j < TowersList[i].TargetList.Count; j++) {
                if (TowersList[i].TargetList[j] == Enemy) {
                    TowersList[i].TargetList.Remove(Enemy);
                }
            }

        }

    }
}
