using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float buffer = 10f;
    public float minY = 10f;
    public float maxY = 100f;


    bool doMovement = true;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            doMovement = !doMovement;
          }

        if (!doMovement)
        {
            return;
        }


            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - buffer)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey("s") || Input.mousePosition.y <= buffer)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey("a") || Input.mousePosition.x <= buffer)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey("d") || Input.mousePosition.x > Screen.width - buffer)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }

           float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 250;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;


    }
}
