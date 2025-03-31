using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2f);
        InvokeRepeating("CreateEnemyTwo", 3, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyPrefab1, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }


    void CreateEnemyTwo()
    {
        Instantiate(enemyPrefab2, new Vector3(Random.Range(-6f, 6f), 8f, 1), Quaternion.identity);
    }
}
