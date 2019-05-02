using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;



    private Transform target;
    private int wavepointIndex = 0;


    private void Start()
    {
        target = Wavepoints.points[wavepointIndex];
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


       
        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {

            GetNextWaypoint();

            }
            


    }

    void GetNextWaypoint() {
        if (wavepointIndex >= Wavepoints.points.Length - 1)
        {
            DestroyImmediate(gameObject);
            return;
        }
        wavepointIndex++;
        target = Wavepoints.points[wavepointIndex];
        

    }


}
