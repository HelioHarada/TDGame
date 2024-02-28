using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemySpawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemeis = 8;
    [SerializeField] private float enemyPerSencond = 0.5f;
    [SerializeField] private float timeBeteweenWaves = 5f;
    [SerializeField] private float dificultScale = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 15f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    // lvl
    private int currentWave = 1;
    private float timeSinceLastSpawn;
    [SerializeField] private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float eps; //Enemy per second;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update(){
        if(!isSpawning) return;
        
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / eps ) && enemiesLeftToSpawn > 0)
        {
            enemiesLeftToSpawn--;
            enemiesAlive++;
            SpawnEnemy();
            timeSinceLastSpawn=0;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn ==0)
        {
            EndWave();
        }
    }

    private IEnumerator StartWave()
    {   
        yield return new WaitForSeconds(timeBeteweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemysPerWaves();
        eps = EnemysPerSecond();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn=0;
        currentWave++;
        Debug.Log(currentWave);
        StartCoroutine(StartWave());
    }



    // private void StartWave()
    // {   
    //     isSpawning = true;
    //     enemiesLeftToSpawn = baseEnemeis;
    // }

    private void EnemyDestroyed()
    {       
        enemiesAlive--;
    }

 

    private void SpawnEnemy()
    { 
       
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);

        GameObject prefabToSpawn = enemyPrefabs[index];

        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);


    }

    private int EnemysPerWaves()
    {
        return baseEnemeis = Mathf.RoundToInt(baseEnemeis * Mathf.Pow(currentWave, dificultScale));
    }

    private float EnemysPerSecond()
    {
        return  Mathf.Clamp(enemyPerSencond * Mathf.Pow(currentWave, dificultScale), 0f,enemiesPerSecondCap);
    }

    
}
