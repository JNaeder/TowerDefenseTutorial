using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Transform targetPos;

    public GameObject impactEffect;

    public float explosionRadius = 0f;
    public float bulletSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(targetPos == null) {
            Destroy(gameObject);
            return;
         
           }


        Vector3 dir = targetPos.position - transform.position;
        float distanceThisFram = bulletSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFram) {
            HitTarget();
            return;
         
           }


        transform.Translate(dir.normalized * distanceThisFram, Space.World);
        transform.LookAt(targetPos);
    }


    public void SetTarget(Transform newTarget) {


        targetPos = newTarget;
      
       
         }


    void HitTarget() {
        //Debug.Log("Hit Target!");
        GameObject efectInst = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(efectInst, 5f);

        if (explosionRadius > 0f)
        {
            Explode();

        }
        else {
            Damage(targetPos);

        }

        
        Destroy(gameObject);
     
       }



    void Damage(Transform enemy) {

        Destroy(enemy.gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider c in colliders) {
            if (c.gameObject.tag == "Enemy") {
                Damage(c.transform);

            }
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
