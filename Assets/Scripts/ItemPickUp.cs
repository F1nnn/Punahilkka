using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private int healtAmmount;
    [SerializeField]
    private int manaAmmount;
    [SerializeField]
    private int damageToGive;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("HP"))
            {
                PlayerHealtManager.instance.AddPlayerHealt(healtAmmount);
            }

            if (gameObject.CompareTag("LoseHP"))
            {
                PlayerHealtManager.instance.HurtPlayer(damageToGive);
            }

            if (gameObject.CompareTag("MP"))
            {
                PlayerHealtManager.instance.AddPlayerMana(manaAmmount);
            }

            if (gameObject.CompareTag("LoseMP"))
            {
                PlayerHealtManager.instance.HurtPlayerMana(damageToGive);
            }

            if (gameObject.CompareTag("FullHP"))
            {
                PlayerHealtManager.instance.SetMaxHP();
            }

            if (gameObject.CompareTag("FullMP"))
            {
                PlayerHealtManager.instance.SetMaxMP();
            }

            Destroy(gameObject);
        }
    }
}
