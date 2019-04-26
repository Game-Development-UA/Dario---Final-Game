using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI RoundNum;
    public TextMeshProUGUI TextBox;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI ScoreText;
    public Sprite[] musicSprites = new Sprite[2];
    public Image musicButtonSprite;
    public static UIManager Singleton;

    // Start is called before the first frame update

    void Awake()
    {
        Singleton = this;
        RoundNum.text = "" + 0;
        HealthText.text = "" + Player.Singleton.health;
        MoneyText.text = "" + Player.Singleton.money;
        ScoreText.text = "" + Player.Singleton.score;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthText(int numToAdd, int cost) {
        Player.Singleton.UpdateHealth(numToAdd);
        HealthText.text = "" + Player.Singleton.health;
        UpdateMoneyText(cost);

    }

    public void UpdateMoneyText(int numToAdd) {
        Player.Singleton.UpdateMoney(numToAdd);
        MoneyText.text = "" + Player.Singleton.money;
    }

    public void UpdateScoreText(int numToAdd) {
        Player.Singleton.UpdateScore(numToAdd);
        ScoreText.text = "" + Player.Singleton.score;
    }

    public void UpdateTextBox(string update) {
        TextBox.text = update;
    }

    public void UpdateMusicSprite(bool state){
        if (state == false) {
            musicButtonSprite.sprite = musicSprites[0];
        }
        else {
            musicButtonSprite.sprite = musicSprites[1];
        }
    }

    public void UpdateRound(int val) {
        RoundNum.text = "" + val;
    }

}
