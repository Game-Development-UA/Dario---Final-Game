using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawn_Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    private float enemyTimer = 0f;
    // public Enemy Enemy;
    // public Enemy Enemy2;
    public GameObject Enemy;
    public GameObject Enemy2;

    public int numWalkEnemies;
    public int numShieldEnemies;
    private GameObject Temp;
    
    public float spawnCoordinate_x;
    public float spawnCoordinate_y;
    public float enemySpawnTimer;

    public bool levelEnd;
    public bool Clicked;
    public int enemyCount1 = 0;
    public int enemyCount2 = 0;

    // public List<Enemy> enemyList = new List<Enemy>();
    public List<GameObject> enemyList = new List<GameObject>();
    

    public void Start() {
        levelEnd = false;
        if (numShieldEnemies == 0) {
            enemyCount2 = 1;
        }
        if (numWalkEnemies == 0) {
            enemyCount1 = 1;
        }
    }

    public void Update() {
        if (Clicked)
        {
            
                if (enemyCount1 < numWalkEnemies)
                {

                    if (enemyTimer > enemySpawnTimer)
                    {
                        SpawnEnemies(Enemy);
                        enemyCount1++;
                        enemyTimer = 0f;
                    }
                }
            
            else if (enemyCount1 >= numWalkEnemies)
            {
                if (enemyCount2 < numShieldEnemies)
                {
                    if (enemyTimer > enemySpawnTimer)
                    {
                        SpawnEnemies(Enemy2);
                        enemyCount2++;
                        enemyTimer = 0f;
                    }
                }
            }
            enemyTimer += Time.deltaTime;
            if (enemyCount1 >= numWalkEnemies) {
                if (enemyCount2 >= numShieldEnemies) {
                    
                    CheckEnd();
                }
            }
            
        }

    }





    public void SpawnEnemies(GameObject EnemyToSpawn) {
        enemyTimer = 0f;
            while (enemyTimer < enemySpawnTimer)
            {
                enemyTimer += Time.deltaTime;
               
            }
            Temp = Instantiate(EnemyToSpawn, new Vector3(spawnCoordinate_x, spawnCoordinate_y, 0), Quaternion.identity);
            enemyList.Add(Temp);
    }

    public void CheckEnd() {
        if (enemyList.Count == 0) {
            levelEnd = true;
        }

    }
}
