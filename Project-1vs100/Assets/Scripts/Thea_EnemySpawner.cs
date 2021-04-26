using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thea_EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private int enemiesRemainingToSpawn;
    [HideInInspector] public int enemiesRemaining;
    public GameObject youWin;
    
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        enemiesRemaining = 100;
    }

    void Update()
    {
       if(enemiesRemaining <= 0)
        {
            youWin.SetActive(true);
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2.5f);
        for (enemiesRemainingToSpawn = 100; enemiesRemainingToSpawn > 0; enemiesRemainingToSpawn--)
        {
            //https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
            Instantiate(enemyPrefab, new Vector3(-17, 0, Random.Range(-8, 4)), Quaternion.Euler(0,90,0));
        }
        
    }
}
