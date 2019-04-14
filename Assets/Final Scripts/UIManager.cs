using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI TextBox;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI ScoreText;

    public static UIManager Singleton;

    // Start is called before the first frame update

   void Awake()
    {
        Singleton = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthText(int numToAdd) {
        Player.Singleton.UpdateHealth(numToAdd);
        HealthText.text = "" + Player.Singleton.health;

    }

    public void UpdateMoneyText(int numToAdd) {
        Player.Singleton.UpdateMoney(numToAdd);
        MoneyText.text = "" + Player.Singleton.money;
    }

    public void UpdateScoreText(int numToAdd) {
        Player.Singleton.UpdateScore(numToAdd);
        ScoreText.text = "" + Player.Singleton.score;
    }
}
