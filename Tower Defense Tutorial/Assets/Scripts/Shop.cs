using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager bM;


    private void Start()
    {
        bM = BuildManager.buildManager;
    }

    public void PurchaseStandardTurret() {

        Debug.Log("Purchase Standard Turret");
        bM.SetTurretToBuild(bM.standardTurretPrefab);
        }

    public void PurchaseAnotherTurret()
    {

        Debug.Log("Purchase Another Turret");
        bM.SetTurretToBuild(bM.anotherTurretPrefab);
    }
}
