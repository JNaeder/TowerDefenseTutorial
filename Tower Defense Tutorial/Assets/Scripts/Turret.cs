using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{


    Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    public Transform turretHead;
    public GameObject bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.01f, 0.5f);
    }


    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject e in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, e.transform.position);
            if (distanceToEnemy < shortestDist) {
                shortestDist = distanceToEnemy;
                nearestEnemy = e;
            }
        }


        if (nearestEnemy != null && shortestDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            return; 
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(turretHead.rotation, lookRot, Time.deltaTime * turnSpeed).eulerAngles;
        turretHead.rotation = Quaternion.Euler(0, rot.y, 0);

        if(fireCountdown <= 0) {
            Shoot();
            fireCountdown = 1f / fireRate;
         
           }

        fireCountdown -= Time.deltaTime;


    }



    void Shoot() {

        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        BulletScript bulletGO = newBullet.GetComponent<BulletScript>();
        if(bulletGO != null) {
            bulletGO.SetTarget(target);
          }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
