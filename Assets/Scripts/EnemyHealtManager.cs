using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealtManager : MonoBehaviour
{
    [SerializeField]
    private string enemyName;
    [SerializeField]
    private float EnemyMaxHP = 100f;
    [SerializeField]
    private float enemyCurrentHP;

    public Image enemyHealtbar;
    public float lerpSpeed;

    void Start()
    {
        enemyCurrentHP = EnemyMaxHP;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            HurtEnemy(5);
        }

        checkEnemyStatus();
    }

    private void HurtEnemy(int DamageToTake)
    {
        enemyCurrentHP -= DamageToTake;

        if (enemyCurrentHP <= 0)
        {
            enemyCurrentHP = 0;
            Die();
        }
    }

    private void checkEnemyStatus()
    {
        if (enemyCurrentHP != enemyHealtbar.fillAmount)
        {
            enemyHealtbar.fillAmount = Mathf.Lerp(enemyHealtbar.fillAmount, enemyCurrentHP / EnemyMaxHP, Time.deltaTime * lerpSpeed);
        }
    }

    private void Die()
    {
        print(enemyName + " kuoli");
        Destroy(gameObject, 0.5f);
    }
}
