using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : TowerParent
{
    public float fireRate;
    public int damage;
    public Projectile currProjectile;
    private bool shot;
    // Start is called before the first frame update
    void Start()
    {
        TowerManager.Singleton.AddTower(this);
    }

    // Update is called once per frame
    void Update()
    {
        FindTargets();
        Fire();
    }

    public void Fire()
    {
        if (!shot)
        {
            if (TargetList.Count > 0)
            {
                Projectile tempProjectile = Instantiate<Projectile>(currProjectile, new Vector3(towerPosition.x, towerPosition.y, 0), Quaternion.identity);

                tempProjectile.InstantiateProjectile(TargetList, this);
                shot = true;

            }
        }

    }
    public void UpdateShot(bool shotBool)
    {
        shot = shotBool;
    }
}
