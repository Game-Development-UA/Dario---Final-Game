using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public float spawnCoordinate_x;
    public float spawnCoordinate_y;
    public float enemySpawnTimer;

    public int round;
    public bool nextRoundStart;
    public int roundWaitTime;
    public int totalRounds;


    public List<EnemyFinal> enemyList = new List<EnemyFinal>();
    public static EnemyManager Singleton;

    // Start is called before the first frame update
    void Awake() {
        Singleton = this;

    }

    void Start()
    {
     
        round = 0;
        nextRoundStart = false;
        CreateEnemiesForRounds();
        Invoke("StartRound", 2);
        //StartCoroutine(SpawnEnemies(availableRounds[0].EnemyRoundNum[0], availableRounds[0].EnemyRoundNum[1], availableRounds[0].EnemyRoundNum[2]));
    }

    // Update is called once per frame
    void Update()
    {
        if (round == totalRounds) {
            SceneManager.LoadScene(4);
        }
        if (nextRoundStart) {
            if (round < availableRounds.Count) {
                print("Round: " + round);
                nextRoundStart = false;
                Invoke("StartRound", 2);
            }
        }
    }

    public void StartRound() {
        print("Round: " + round);
        nextRoundStart = false;
        print(availableRounds[round].EnemyRoundNum[0]);
        StartCoroutine(SpawnEnemies(availableRounds[round].EnemyRoundNum[0], availableRounds[round].EnemyRoundNum[1], availableRounds[round].EnemyRoundNum[2]));
        

    }

    IEnumerator SpawnEnemies(int numBike, int numWalk, int numShield ) {
        int enemyTypeCount = 0;
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
        if (round > 5) {    //Make the enemies faster after round 5
            Temp.enemySpeed = Temp.enemySpeed * 1.15f;
        }
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




    public void SearchDeadEnemy()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].dead)
            {
                EnemyFinal Temp = enemyList[i];
                // RemoveFromList(Temp);

                enemyList.Remove(Temp);
                /* if (enemyList[i].dead) {
                     if (!enemyList[i].removed)
                         {
                         enemyList[i].removed = true;
                         }
                 }
             }*/
            }
            if (enemyList.Count == 0)
            {
                nextRoundStart = true;
                round++;
            }
        }
    }

    public void CreateEnemiesForRounds() {
        List<int> enemyNum = new List<int>();
        for (int i = 0; i < totalRounds; i++) {
            availableRounds.Add(new Round());
            //List<int> enemyNum = new List<int>();
            enemyNum.Add(4 + i);
            //int x = 4 + i;
            enemyNum.Add(2 + i);
            //int y = 2 + i;
            enemyNum.Add(2 * (i - 1));
            //int z = 2 * (i - 1);
            for (int j = 0; j < enemyNum.Count; j++) {
                print(enemyNum[2]);
                if (enemyNum[j] < 0) {
                    enemyNum[j] = 0;
                }
            }
            availableRounds[i].SetRoundInfo(enemyNum[0], enemyNum[1], enemyNum[2]);

            enemyNum.Clear();
        }

    }

}
