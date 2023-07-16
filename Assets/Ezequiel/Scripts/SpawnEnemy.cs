using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private int _randomizeEnemy;


    void Start()
    {
        _randomizeEnemy = Random.Range(0, enemies.Length);
        Instantiate(enemies[_randomizeEnemy], transform.position, Quaternion.identity);
    }
}
