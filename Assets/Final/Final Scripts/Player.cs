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

    public static Player Singleton;

    void Awake() {
        Singleton = this;
    }
    void Start()
    {
       

    }


    public void UpdateMoney(int numToAdd) {
        money += numToAdd;

    }

    public void UpdateHealth(int num) {
        health += num;
        if (health <= 0) {
            SceneManager.LoadScene(3);
        }
    }

    public void UpdateScore(int num) {
        score += num;
    }
}
