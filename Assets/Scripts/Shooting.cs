using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefabs;



    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerHealtManager.instance.GetCurrentMP() >= PlayerHealtManager.instance.GetMaxMP())
            {
                for (int i = 0; i < 8; i++)
                {
                    Instantiate(projectilePrefabs, transform.position + new Vector3(0, 0, 1), transform.rotation *
                    Quaternion.Euler(new Vector3(0, 0, 45 * i)));
                }
            }

            PlayerHealtManager.instance.HurtPlayerMana((int) PlayerHealtManager.instance.GetMaxMP());
        }
    }
}
