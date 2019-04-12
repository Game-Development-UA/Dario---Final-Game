using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string Name;
    public float health;
    public float enemySpeed;
    float enemyTimer = 0f;
    public float horizontalSpeed = 0f;
    public float verticalSpeed = 0f;
    private Collider2D hitCollider;
    private RaycastHit2D hit;
    private Spawn_Enemies EnemyManager;
    private bool slowed;

    void Start()
    {
        // verticalSpeed = -(enemySpeed * Time.deltaTime);
        verticalSpeed = -enemySpeed;
        EnemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<Spawn_Enemies>();
        slowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(horizontalSpeed * Time.deltaTime , verticalSpeed * Time.deltaTime, 0f));
        
    }

    void FixedUpdate()
    {
        if (!slowed)
        {
            CheckDistances();
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //LowerCollisionSize();

        if (!(col.gameObject.tag == "Enemy"))
        {


            Vector2 off = new Vector2(this.transform.position.x, this.transform.position.y + 0.6f);
            Vector2 lowOff = new Vector2(this.transform.position.x, this.transform.position.y - 0.6f);
            if (verticalSpeed < 0f)
            {
                hit = Physics2D.Raycast(off, Vector2.right);

                if (hit.distance > 1)
                {

                    horizontalSpeed = Mathf.Abs(verticalSpeed);
                    this.transform.GetChild(0).transform.Rotate(0, 0, 90);
                }
                else
                {
                    horizontalSpeed = verticalSpeed;
                    this.transform.GetChild(0).transform.Rotate(0, 0, -90);
                }
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, 0f);
                verticalSpeed = 0f;


            }

            else if (verticalSpeed > 0f)
            {
                Debug.DrawRay(this.transform.position, this.transform.right * 2f, Color.yellow);
                hit = Physics2D.Raycast(lowOff, Vector2.right);

                if (hit.distance < 1)
                {
                    horizontalSpeed = -verticalSpeed;
                    this.transform.GetChild(0).transform.Rotate(0, 0, 90);
                }
                else
                {
                    horizontalSpeed = Mathf.Abs(verticalSpeed);
                    this.transform.GetChild(0).transform.Rotate(0, 0, -90);
                }
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.2f, 0f);
                verticalSpeed = 0f;
            }

            else if (horizontalSpeed > 0f)
            {
               // Debug.DrawRay(this.transform.position, (new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0f) - this.transform.position) * 2f, Color.yellow);

                hit = Physics2D.Raycast(off, Vector2.up);
                print(hit.collider);
                print(hit.collider.name);
                if (hit.distance < 1)
                {
                    verticalSpeed = -horizontalSpeed;
                    this.transform.GetChild(0).transform.Rotate(0, 0, -90);
                }
                else
                {

                    verticalSpeed = horizontalSpeed;
                    this.transform.GetChild(0).transform.Rotate(0, 0, 90);
                }
                horizontalSpeed = 0f;

                this.transform.position = new Vector3(this.transform.position.x - 0.1f, this.transform.position.y, 0f);
            }

            else if (horizontalSpeed < 0f)
            {
                hit = Physics2D.Raycast(off, Vector2.up);
                if (hit.distance < 1)
                {
                    verticalSpeed = horizontalSpeed;
                    this.transform.GetChild(0).transform.Rotate(0, 0, 90);
                }
                else
                {
                    verticalSpeed = Mathf.Abs(horizontalSpeed);
                    this.transform.GetChild(0).transform.Rotate(0, 0, -90);
                }
                this.transform.position = new Vector3(this.transform.position.x - 0.1f, this.transform.position.y, 0f);
                horizontalSpeed = 0f;
            }


        }
    }

    public void CheckDistances() {
        for (int i = 1; i < EnemyManager.enemyList.Count; i++) {
            if (this.gameObject == EnemyManager.enemyList[i]) {

                if ((this.transform.position - EnemyManager.enemyList[i-1].transform.position).magnitude < 0.2f) {
                    if (horizontalSpeed > 0) {
                        horizontalSpeed = horizontalSpeed - (horizontalSpeed / 8f);
                    }
                    else if (horizontalSpeed < 0)
                    {
                        horizontalSpeed = horizontalSpeed + (horizontalSpeed / 8f);
                    }
                    else if (verticalSpeed > 0) {
                        verticalSpeed = verticalSpeed - (verticalSpeed / 8f);
                    }
                    else if (verticalSpeed < 0)
                    {
                        verticalSpeed = verticalSpeed + (verticalSpeed / 8f);
                    }
                }

            }

        }
        slowed = true;
    }

}
