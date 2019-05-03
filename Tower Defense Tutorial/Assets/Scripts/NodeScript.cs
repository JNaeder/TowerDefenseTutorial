using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour
{
    public Color hoverColor;
    public Transform spawnPos;

    Color startColor;
    Renderer rend;
    GameObject currentTurret;

    BuildManager bM;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = GetComponent<Renderer>().material.color;

        bM = BuildManager.buildManager;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
          }

        if (bM.GetTurretToBuild() == null)
        {
            return;
        } 
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(bM.GetTurretToBuild() == null) {
            return;
          }

        if (currentTurret != null) {
            Debug.Log("Already Have Turret Here");
            return;
           }
            GameObject turretToBuild = bM.GetTurretToBuild();
            currentTurret = Instantiate(turretToBuild, spawnPos.position, transform.rotation);

    }
}
