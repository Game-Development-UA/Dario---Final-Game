using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeleteExit : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyFinal toDel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //player.health = player.health - 1;
            //HealthText.text = "" + player.health;
            //UIManager.Singleton.UpdateHealthText(-1, 0);
            EnemyManager.Singleton.enemyList.Remove(col.gameObject.GetComponent<EnemyFinal>());
            if (EnemyManager.Singleton.enemyList.Count == 0)
            {
                EnemyManager.Singleton.nextRoundStart = true;
                EnemyManager.Singleton.round = EnemyManager.Singleton.round + 1;
            }
            Destroy(col.gameObject);
        }
    }
}
