using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinal : MonoBehaviour
{
    public string Name;
    public float health;
    public float enemySpeed;

    private float horizontalSpeed;
    private float verticalSpeed;
    private Transform currCheckPoint;
    private Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCheckPoint(0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Direction.x * enemySpeed * Time.deltaTime, Direction.y * enemySpeed * Time.deltaTime, 0f);
        
    }

    public void UpdateCheckPoint(int numCheckPoint) {
        if (numCheckPoint < Path.Singleton.checkPoints.Count)
        {
            currCheckPoint = Path.Singleton.checkPoints[numCheckPoint];
        }
        Direction = Vector3.Normalize(currCheckPoint.position - this.transform.position);

    }

    public void CheckPosition() {

    }
}
