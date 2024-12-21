using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public float speed;

    GameObject player;
    Rigidbody2D rb2d;
    Vector3 target, dir;

    [SerializeField]
    private int damageToGive;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            target = player.transform.position;
            dir = (target - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        if (target != Vector3.zero)
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealtManager playerHealtManager = collision.GetComponent<PlayerHealtManager>();
            if (playerHealtManager != null)
                playerHealtManager.HurtPlayer(damageToGive);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
