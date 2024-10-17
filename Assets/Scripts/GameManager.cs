using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]float timeCooldown;
    public Transform[] spawnPoints;
    public GameObject[] enemy;
    [SerializeField] bool choose = false;
    [SerializeField] GameObject player;
    int spawnChosed;
    int enemyChosed;
    void Start()
    {
        timeCooldown = 0;
    }

    void Update()
    {
        timeCooldown += Time.deltaTime;

        while(timeCooldown >= 2f)
        {
            spawnChosed = ReturnValueSpawn();
            enemyChosed = ReturnValueEnemy();
            SpawnEnemy();
            timeCooldown = 0;
        } 
    }
    void SpawnEnemy()
    {
        Instantiate(enemy[enemyChosed], spawnPoints[spawnChosed].position, Quaternion.identity);
        choose = true;
    }

    int ReturnValueSpawn()
    {
        return spawnChosed = Random.Range(0, spawnPoints.Length);
    }
    int ReturnValueEnemy()
    {
        return enemyChosed = Random.Range(0, enemy.Length);
    }
}
