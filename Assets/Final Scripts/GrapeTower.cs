using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeTower : TowerParent
{
    // Start is called before the first frame update
    void Start()
    {
            TowerManager.Singleton.AddTower(this);    
    }

    // Update is called once per frame
    void Update()
    {
        FindTargets();
      
    }
}
