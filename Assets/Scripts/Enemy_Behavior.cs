using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform Enemy;
    public float enemySpeed;

    public float horizontalSpeed = 0f;
    public float verticalSpeed = 0f;
    public Collider2D hitCollider;
    private RaycastHit2D hit;
    void Start()
    {
        verticalSpeed = -(enemySpeed * Time.deltaTime);
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(horizontalSpeed, verticalSpeed, 0f));
    }

    void FixedUpdate() {
        

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //LowerCollisionSize();
       

        Vector2 off = new Vector2(this.transform.position.x, this.transform.position.y + 0.6f);
        Vector2 lowOff = new Vector2(this.transform.position.x, this.transform.position.y - 0.6f);
        if (verticalSpeed < 0f)
        {
            hit = Physics2D.Raycast(off, Vector2.right);
           
            if (hit.distance > 1)
            {

                horizontalSpeed = Mathf.Abs(verticalSpeed);
            }
            else {
                horizontalSpeed = verticalSpeed;
            }
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, 0f);
            verticalSpeed = 0f;
        }

        else if (verticalSpeed > 0f)
        {
            hit = Physics2D.Raycast(lowOff, Vector2.right);
          
            if (hit.distance < 1)
            {
                horizontalSpeed = -verticalSpeed;
            }
            else
            {
                horizontalSpeed = Mathf.Abs(verticalSpeed);
            }
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f, 0f);
            verticalSpeed = 0f;
        }

        else if (horizontalSpeed > 0f) {
           
            hit = Physics2D.Raycast(off, Vector2.up);
    
            if (hit.distance < 1)
            {
                verticalSpeed = -horizontalSpeed;   
            }
            else {
                
                verticalSpeed = horizontalSpeed;
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
            }
            else
            {
                verticalSpeed = Mathf.Abs(horizontalSpeed);
            }
            this.transform.position = new Vector3(this.transform.position.x - 0.1f, this.transform.position.y, 0f);
            horizontalSpeed = 0f;
        }


    }

   


}
