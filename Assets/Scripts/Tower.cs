using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    public float fireRate;
    public float xCoordinate;
    public float yCoordinate;
    public float range;
    public int damage;
    public string name;
    public int cost;
    public int Level;
    public Spawn_Enemies EnemyManager;
    //public List<Enemy> TargetList = new List<Enemy>();
    public List<GameObject> TargetList = new List<GameObject>();
    private GameObject toDelete;
    public Vector3 towerPosition;
    public Projectile currProjectile;
    private Projectile tempProjectile;
    private bool enemyManagerExists = false;
    private float interpolationValue = 0f;
    private bool shot;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI ScoreText;
    public Player player;

    public Initiate levelInfo;

    void Start()
    {
        towerPosition = new Vector3(xCoordinate, yCoordinate, 0f);
        player = GameObject.FindWithTag("player").GetComponent<Player>();
        HealthText = GameObject.Find("Health Number").GetComponent<TextMeshProUGUI>();
        MoneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        ScoreText = GameObject.Find("Score - Text").GetComponent<TextMeshProUGUI>();
        levelInfo = GameObject.FindWithTag("Initiate").GetComponent<Initiate>();
       
        EnemyManager = levelInfo.currEnemySpawner.GetComponent<Spawn_Enemies>();
        if (EnemyManager != null)
        {
            enemyManagerExists = true;
        }
        shot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyManagerExists)
        {
            if (EnemyManager.enemyList.Count > 0)
            {
                DeleteEnemies();    //Deletes Enemies from Enemy List (and target list) if their health <= 0
                FindEnemy();        //Adds enemies to Target List based on distance
                checkTargets();     //Checks if the target is too far and removes from target list if so
                Fire();             //if there are targets, instantiates projectile
               
            }
        }
    }

    public void FindEnemy() {

        for(int i = 0; i < EnemyManager.enemyList.Count; i++) {
            if (!TargetList.Contains(EnemyManager.enemyList[i])) {
              
                if ((EnemyManager.enemyList[i].transform.position - towerPosition).magnitude < range) {
                    TargetList.Add(EnemyManager.enemyList[i]);
                }
            

            }

        }

    }

    public void checkTargets()
    {
        
        for (int i = 0; i < TargetList.Count; i++)
        {
            if (TargetList[i] == null) {
                TargetList.Remove(TargetList[i]);
            }
            else if ((TargetList[i].transform.position - towerPosition).magnitude > range) 
            {
                TargetList.Remove(TargetList[i]);
            }
        }
    }

    public void Fire() {
        if (!shot) {
            if (TargetList.Count > 0) {
                tempProjectile = Instantiate<Projectile>(currProjectile, new Vector3(towerPosition.x, towerPosition.y, 0), Quaternion.identity);
                
                //tempProjectile.InstantiateProjectile(TargetList, this);
                shot = true;

            }
        }

       

    }

    public void UpdateShot(bool shotBool) {
        shot = shotBool;
    }



    public void DeleteEnemies() {
        for (int z = 0; z < EnemyManager.enemyList.Count; z++)
        {
            if (EnemyManager.enemyList[z].GetComponent<Enemy>().health <= 0f)
            {
                UpdatePlayerInfo(EnemyManager.enemyList[z]);
                toDelete = EnemyManager.enemyList[z];
                if (TargetList.Contains(toDelete)) {
                    TargetList.Remove(toDelete);
                }
                EnemyManager.enemyList.Remove(toDelete);

                Destroy(toDelete.gameObject);

            }
        }

    }

    public void UpdatePlayerInfo(GameObject enemyDestroyed) {
        Enemy enemyRef = enemyDestroyed.GetComponent<Enemy>();
        if (enemyRef.Name == "Basic") {
            player.score += 20;
            player.money += 5;
            MoneyText.text = "" + player.money;
            ScoreText.text = "" + player.score;

        }
        else if (enemyRef.Name == "Shield") {
            player.score += 40;
            player.money += 15;
            MoneyText.text = "" + player.money;
            ScoreText.text = "" + player.score;
        }

    }

    public void UpdateEnemyManager(Spawn_Enemies updateToEnemyManager) {
        EnemyManager = updateToEnemyManager;
    }
}
