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
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI ScoreText;
    
    void Start()
    {
       
        HealthText = GameObject.Find("Health Number").GetComponent<TextMeshProUGUI>();
        MoneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        ScoreText = GameObject.Find("Score - Text").GetComponent<TextMeshProUGUI>();
        HealthText.text = "" + health;
        MoneyText.text = "" + money;
        ScoreText.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) {
        SceneManager.LoadScene(3);
        }
    }
}
