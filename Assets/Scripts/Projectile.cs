using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damageToGive;

    [SerializeField]
    private int moveSpeed = 5;

    private int timeToWait = 5;


    void Start()
    {
        StartCoroutine(DestroyProjectile());
    }


    void Update()
    {
        //transform.position +- transform.right * Time.deltaTime * moveSpeed;
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(timeToWait);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealtManager enemyHealtManager = collision.GetComponent<EnemyHealtManager>();
            //enemyHealtManager.HurtEnemy(damageToGive);
        }
    }
}
