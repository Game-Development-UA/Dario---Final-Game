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

    public void AddTower(TowerParent tower) {
        TowersList.Add(tower);
    }

    public void RemoveFromAllTowers() {
        for (int i = 0; i < TowersList.Count; i++) {
            for (int j = 0; j < TowersList[i].TargetList.Count; j++) {
                if (TowersList[i].TargetList[j].dead) {
                    TowersList[i].TargetList[j].removed = true;
                    TowersList[i].TargetList.Remove(TowersList[i].TargetList[j]);
                }
            }

        }
        
    }
}
