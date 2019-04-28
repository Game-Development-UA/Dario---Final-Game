using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    private float timer;
    private bool saved;
    private int numEnemiesDefeated;
    public static Player Singleton;

  

    void Awake() {
        Singleton = this;

    }
    void Start()
    {
        timer = 0f;
        numEnemiesDefeated = 0;

    }

    void Update() {
        timer += Time.deltaTime;

    }
    public void UpdateMoney(int numToAdd) {
        
        money += numToAdd;

    }

    public void UpdateHealth(int num) {
        health += num;
        if (health <= 0) {
            Save();
            SceneManager.LoadScene(3);
        }
    }

    public void UpdateScore(int num) {
        numEnemiesDefeated++;
        score += num;
    }

    public void Save() {
        SaveObject ObjectToSave = new SaveObject
        {
            finalScore = score,
            numEnemies = numEnemiesDefeated,
            time = timer
        };
    string json = JsonUtility.ToJson(ObjectToSave);
        print(json);
    File.WriteAllText(Application.dataPath + "/save.txt", json);

    }

    public void Load() {

    }


}

public class SaveObject
{
    public int finalScore;
    public int numEnemies;
    public float time;

}


