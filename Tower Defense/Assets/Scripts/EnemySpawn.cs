using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    public EnemyDemo enemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 4f;
    public Transform spawnLocation;
    private int waveNumber = 0;
    public Transform root;
    public TMP_Text bank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        Debug.Log("Wave Incoming!");
        for(int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        var unit = Instantiate(enemyPrefab, spawnLocation.transform);
        unit.transform.parent = root;
        unit.GetComponent<EnemyDemo>().bank = bank;
    }
}
