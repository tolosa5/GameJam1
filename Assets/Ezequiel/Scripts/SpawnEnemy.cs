using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int[] choseEnemy;
    private int _randomizeEnemy;


    void Start()
    {
        _randomizeEnemy = Random.Range(0, 4);
        Instantiate(enemies[_randomizeEnemy], transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
