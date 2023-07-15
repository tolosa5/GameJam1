using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Proyecticles : MonoBehaviour
{
    private float _speed = 5f;
    private Manager _manager;

    private bool _isAttacking = false;

    #region Disparos

    [SerializeField] GameObject bullets;
    [SerializeField] Transform pointInstance;
    [SerializeField] Sprite[] bulletsSprite; //cambiar el sprite de las balas segun el nivel en el que se esta

    #endregion

    private void Start()
    {

    }
    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, _speed * Time.deltaTime);
        
        if (_isAttacking == false)
        {
            StartCoroutine(Shoot());
            _isAttacking = true;
        }

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(bullets, pointInstance.transform.position + Vector3.right * 1f, Quaternion.identity);
        _isAttacking = false;
        //lastShoot = 0;
    }
}
