using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thea_EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
       
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < 100; i++)
        {
            //https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
            Instantiate(enemyPrefab, new Vector3(-17, 0, Random.Range(-8, 4)), Quaternion.Euler(0,90,0));
        }
        
    }
}
