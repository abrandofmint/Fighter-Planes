using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyPrefab1, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
}
