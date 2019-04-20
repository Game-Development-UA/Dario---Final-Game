using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Round
{
    public int[] EnemyRoundNum = new int[3];


    public void SetRoundInfo(int numBike, int numWalk, int numShield) {
        EnemyRoundNum[0] = numBike;
        EnemyRoundNum[1] = numWalk;
        EnemyRoundNum[2] = numShield;
    }
}
public class EnemyManager : MonoBehaviour
{
    public EnemyFinal Enemy1;

  
    
    public EnemyFinal Enemy2;
 
 

    public EnemyFinal Enemy3;

    public List<Round> availableRounds = new List<Round>();
    private int numRounds;

    private EnemyFinal Temp;
    private int enemyTypeCount;

    public float spawnCoordinate_x;
    public float spawnCoordinate_y;
    public float enemySpawnTimer;

    private int round;
    private bool nextRoundStart;


    public List<EnemyFinal> enemyList = new List<EnemyFinal>();
    public static EnemyManager Singleton;

    // Start is called before the first frame update
    void Awake() {
        Singleton = this;

    }

    void Start()
    {
        enemyTypeCount = 0;
        round = 0;
        nextRoundStart = false;
        CreateEnemiesForRounds();
        StartCoroutine(SpawnEnemies(availableRounds[0].EnemyRoundNum[0], availableRounds[0].EnemyRoundNum[1], availableRounds[0].EnemyRoundNum[2]));
    }

    // Update is called once per frame
    void Update()
    {
        if (nextRoundStart) {
            StartRound();
        }
    }

    public void StartRound() {
        nextRoundStart = false;
        StartCoroutine(SpawnEnemies(availableRounds[round].EnemyRoundNum[0], availableRounds[round].EnemyRoundNum[1], availableRounds[round].EnemyRoundNum[2]));

    }

    IEnumerator SpawnEnemies(int numBike, int numWalk, int numShield ) {
        while (enemyTypeCount < numBike + numShield + numWalk) {
            if (enemyTypeCount < numBike) {
                SpawnEnemy(Enemy3);
            }
            else if (enemyTypeCount < numWalk + numBike) {
                SpawnEnemy(Enemy1);
            }
            else if (enemyTypeCount < numShield + numWalk + numBike) {
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

    public int SearchEnemy(EnemyFinal Enemy) {
        for (int i = 0; i < enemyList.Count; i++)
        {  
            if (Enemy == enemyList[i])
            {
                return i;
            }
        }
        return -1;
    }




    public void SearchDeadEnemy() {
        for (int i = 0; i < enemyList.Count; i++) {
            if (enemyList[i].dead) {
                EnemyFinal Temp = enemyList[i];
               // RemoveFromList(Temp);
                enemyList.Remove(Temp);
            }
        }
        if (enemyList.Count == 0) {
            nextRoundStart = true;
            round++;
        }
    }

    public void CreateEnemiesForRounds() {
        for (int i = 0; i < 5; i++) {
            availableRounds.Add(new Round());

            availableRounds[i].SetRoundInfo(4 + i, 2 + i, 2 * i);

            
        }
        /*print("In create");
        for (int j = 0; j < 5; j++) {
            for (int k = 0; k < 3; k++) {
                print("Round: " + j + "Enemy Type: " + k);
                print(availableRounds[j].EnemyRoundNum[k]);
            }
        }*/

    }

}
