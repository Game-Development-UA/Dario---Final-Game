using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinal : MonoBehaviour
{
    public string Name;
    public float health;
    public float enemySpeed;
    public int score;
    public int money;

    private float horizontalSpeed;
    private float verticalSpeed;
    private Transform currCheckPoint;
    private int checkPointNum;
    public Vector3 Direction;

    public bool dead;
    public bool removed;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        Direction = new Vector3(0, -1, 0);
        timer = 0f;
        dead = false;
        UpdateCheckPoint(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Direction.x * enemySpeed * Time.deltaTime, Direction.y * enemySpeed * Time.deltaTime, 0f);
        CheckPosition();
        CheckHealth();
        timer += Time.deltaTime;
    }

    public void UpdateCheckPoint(int numCheckPoint) {
        Vector3 prevDirection = Direction;
        if (numCheckPoint < Path.Singleton.checkPoints.Count)
        {
            currCheckPoint = Path.Singleton.checkPoints[numCheckPoint];
            checkPointNum = numCheckPoint;
        }
        
        Direction = Vector3.Normalize(currCheckPoint.position - this.transform.position);
        RotateSprite(prevDirection);
       // this.transform.GetChild(0).transform.LookAt(currCheckPoint);

    }

    public void CheckPosition() {
        if (Vector3.Magnitude(this.transform.position - currCheckPoint.position) < 0.05) {
            UpdateCheckPoint(checkPointNum + 1);
        }
    }

    public void RotateSprite(Vector3 prevDirection)
    {

       float angle = Mathf.Acos(Vector3.Dot(prevDirection, Direction)) * Mathf.Rad2Deg;

        if (Vector3.Cross(Direction, prevDirection).z > 0) 
        {
            angle = angle * -1;
        }
        print("Angle: " + angle);
        this.transform.GetChild(0).transform.Rotate(0, 0, angle);
    }

    public void CheckHealth() {
        if (this.health <= 0f) {
            print("should be dead");
            dead = true;
            TowerManager.Singleton.RemoveFromAllTowers();
            EnemyManager.Singleton.SearchDeadEnemy();

            if (removed)
            {
                UIManager.Singleton.UpdateScoreText(score);
                UIManager.Singleton.UpdateMoneyText(money);
                Destroy(this.gameObject);

            }
        }
    }
}
