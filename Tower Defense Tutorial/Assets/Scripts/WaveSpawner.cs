using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform startPos;

    public Text countdownTimer;

    public float timeBetweenWaves = 10f;
    float countdown = 2f;

    int waveIndex = 0;


    private void Update()
    {
        if (countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }
        countdown -= Time.deltaTime;
        countdownTimer.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave() {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnNewEnemy();
            yield return new WaitForSeconds(1f);
        }
        
    }



    void SpawnNewEnemy() {
        Instantiate(enemyPrefab, startPos.position, Quaternion.identity);
        
    }

   
}
