using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;
    

    private  GameObject turretToBuild;


    private void Awake()
    {
        if(buildManager != null) {
            Debug.LogError("More than one Build Manager Exists");
            Destroy(gameObject);
          }
        buildManager = this;
    }


    public void SetTurretToBuild(GameObject newTurret) {
        turretToBuild = newTurret;
     
       }


    public GameObject GetTurretToBuild() {

        return turretToBuild;    
       }
}