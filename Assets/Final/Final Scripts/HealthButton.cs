using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthButton : MonoBehaviour
{
    public int cost;
    // Start is called before the first frame update
    void Start()
    {

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
}
