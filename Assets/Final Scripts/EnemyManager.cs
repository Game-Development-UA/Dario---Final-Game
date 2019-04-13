using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyFinal Enemy1;
    public int numWalkEnemies;
  
    
    public EnemyFinal Enemy2;
    public int numShieldEnemies;
 

    public EnemyFinal Enemy3;
    public int numBikeEnemies;
 

    private EnemyFinal Temp;
    private int enemyTypeCount;

    public float spawnCoordinate_x;
    public float spawnCoordinate_y;
    public float enemySpawnTimer;

    private int level;


    public List<EnemyFinal> enemyList = new List<EnemyFinal>();
    // Start is called before the first frame update
    void Start()
    {
        enemyTypeCount = 0;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartLevel() {


    }

    IEnumerator SpawnEnemies() {
        while (enemyTypeCount < numBikeEnemies + numShieldEnemies + numWalkEnemies) {
            if (enemyTypeCount < numBikeEnemies) {
                SpawnEnemy(Enemy3);
            }
            else if (enemyTypeCount < numWalkEnemies + numBikeEnemies) {
                SpawnEnemy(Enemy1);
            }
            else if (enemyTypeCount < numShieldEnemies + numWalkEnemies + numBikeEnemies) {
                SpawnEnemy(Enemy2);
            }
            enemyTypeCount++;
            yield return new WaitForSeconds(enemySpawnTimer);
        }
        
    }

    public void SpawnEnemy(EnemyFinal EnemyToSpawn){
        Temp = Instantiate(EnemyToSpawn, new Vector3(spawnCoordinate_x, spawnCoordinate_y, 0), Quaternion.identity);
        enemyList.Add(Temp);
    }
}
