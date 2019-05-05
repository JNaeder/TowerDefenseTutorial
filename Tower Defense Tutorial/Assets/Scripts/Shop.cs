using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager bM;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;

    private void Start()
    {
        bM = BuildManager.buildManager;
    }

    public void PurchaseStandardTurret() {

        Debug.Log("Purchase Standard Turret");
        bM.SetTurretToBuild(standardTurret.prefab);
        }
    
    public void PurchaseMissleLauncher()
    {

        Debug.Log("Purchase Another Turret");
        bM.SetTurretToBuild(missleLauncher.prefab);
    }
}
