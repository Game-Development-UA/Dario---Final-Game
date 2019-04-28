using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using TMPro;

public class LoadFile : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI agentNum;
    public TextMeshProUGUI time;

    // Start is called before the first frame update

    void Awake() {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string loadedString = File.ReadAllText(Application.dataPath + "/save.txt");
            SaveObject Loaded = JsonUtility.FromJson<SaveObject>(loadedString);
            scoreText.text = "" + Loaded.finalScore;
            agentNum.text = "" + Loaded.numEnemies;
            time.text = "" + Mathf.Round(Loaded.time) + "seconds";

        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
