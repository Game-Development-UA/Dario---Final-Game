using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    private float projectileSpeed;
    
    private float timeToHit;
    private GameObject currTarget;
    private Tower parentTower;
    private List<GameObject> StoreTargetList = new List<GameObject>();
    private float startDistance;
    private float interpolationValue;
    private Enemy enemyReference;


    //interpolation values
    public Vector3 targetFinalPosition;
    private Vector3 targetPosition;
    private Vector3 shotDirection;
    private Vector3 startPosition;
    private bool hit;

    void Start()
    {
        interpolationValue = 0f;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currTarget != null)
        {
            if (!hit)
            {
                HitTarget();


                //interpolationValue += (projectileSpeed * 0.1f * Time.deltaTime);
            }
        }
        else {
            hit = true;
            parentTower.UpdateShot(false);
            Destroy(this.gameObject);
       }
    }

    public void HitTarget() {

       
        if (currTarget != null)
        {
            shotDirection = currTarget.transform.position - this.transform.position;
            if ((this.transform.position - currTarget.transform.position).magnitude > 0.15f)
            {
                this.transform.Translate(shotDirection.normalized * Time.deltaTime * projectileSpeed, Space.World);
            }
            else if ((this.transform.position - currTarget.transform.position).magnitude < 0.15f)
            {
                enemyReference = currTarget.GetComponent<Enemy>();
                enemyReference.health = enemyReference.health - damage;
                hit = true;
                parentTower.UpdateShot(false);
                Destroy(this.gameObject);
            }
        }
        else {
            parentTower.UpdateShot(false);
            Destroy(this.gameObject);
        }


    }


    public void InstantiateProjectile(List<GameObject> TargetList, Tower currTower) {
        if (TargetList.Count > 0) {
            currTarget = TargetList[0];

        }
        parentTower = currTower;
        shotDirection = currTarget.transform.position - parentTower.towerPosition;
        shotDirection.Normalize();
        shotDirection = shotDirection / 10f;
        startPosition = parentTower.transform.position + shotDirection;
        this.transform.position = startPosition;
        projectileSpeed = 2f + parentTower.fireRate / 50f;
    }
    

    

}
