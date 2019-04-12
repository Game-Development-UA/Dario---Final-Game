using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Initiate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemySpawner;
    public GameObject EnemySpawner2;
    public GameObject EnemySpawner3;

    public GameObject currEnemySpawner;
    private Tower[] towers;

    public TextMeshProUGUI TextBox;
    public bool Clicked;
    public bool levelOver;
    public int level;


    public void Start() {
        Clicked = false;
        levelOver = false;
        level = 1;
    }
    public void InitiateGameObject() {
        if (!Clicked)
        {
            if (level == 1)
            {
                currEnemySpawner = Instantiate(EnemySpawner, new Vector3(10, 10, 0), Quaternion.identity);
                
            }
            if (level == 2) {
                currEnemySpawner = Instantiate(EnemySpawner2, new Vector3(10, 10, 0), Quaternion.identity);
                
            }
            if (level == 3)
            {
                currEnemySpawner = Instantiate(EnemySpawner3, new Vector3(10, 10, 0), Quaternion.identity);

            }
            TextBox.text = "Hover over a tower icon to learn its details. \nClick on the tower to purchase it. \n\nClick on the music icon to turn music on or off.";
            UpdateTowers();
            currEnemySpawner.GetComponent<Spawn_Enemies>().Clicked = true;
            Clicked = true;
            levelOver = false;
            
        }
    }

    public void updateClicked(bool Bool) {
        Clicked = Bool;
    }

    public void Update() {

        if (currEnemySpawner.GetComponent<Spawn_Enemies>().levelEnd == true) {
            if (!levelOver)
            {
                if (level == 3) {
                    SceneManager.LoadScene(4);
                }
                TextBox.text = "Congratulations! Click on the Start Button to start the next level!";
                currEnemySpawner.GetComponent<Spawn_Enemies>().Clicked = false;
                Clicked = false;
               
                level++;
                levelOver = true;
            }
            
        }

    }

    public void UpdateTowers() {
        towers = FindObjectsOfType<Tower>();
        if (towers != null) {
            foreach (Tower currtower in towers) {
                currtower.UpdateEnemyManager(currEnemySpawner.GetComponent<Spawn_Enemies>());
            }
        }
    }
}
