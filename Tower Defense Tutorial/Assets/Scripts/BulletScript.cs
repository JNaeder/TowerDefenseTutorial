using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Transform targetPos;

    public GameObject impactEffect;

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
    }


    public void SetTarget(Transform newTarget) {


        targetPos = newTarget;
      
       
         }


    void HitTarget() {
        //Debug.Log("Hit Target!");
        GameObject efectInst = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(efectInst, 2f);
        Destroy(gameObject);
     
       }
}
