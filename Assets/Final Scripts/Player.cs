using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    public int health;
    public int score;

    
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) {
        SceneManager.LoadScene(3);
        }
    }

    public void UpdateMoney(int numToAdd) {
        money += numToAdd;

    }

    public void UpdateHealth() {

    }

    public void UpdateScore() {

    }
}
