using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealtManager : MonoBehaviour
{
    public static PlayerHealtManager instance;

    public string charName;
    public int playerLevel = 1;

    public float currentEXP;
    public float maxEXP = 0;
    public float currentHP = 0;
    [SerializeField]
    private float maxHp = 100;
    public float currentMP = 0;
    [SerializeField]
    private float maxMp = 100;

    public float currentCake;

    public Image playerHealtbar;
    public TMP_Text HPText;

    public Image playerManabar;
    public TMP_Text MPText;

    public Image EXPbar;
    public TMP_Text EXPtext;
    public TMP_Text playerLevelText;

    public float lerpSpeed;


    void Start()
    {
        instance = this;

        currentHP = maxHp;
        currentMP = maxMp;

        maxEXP = Mathf.Floor(100 * playerLevel * Mathf.Pow(playerLevel, 0.5f));
    }

    void Update()
    {
        CheckPlayerStatus();
    }


    private void CheckPlayerStatus()
    {
        if (currentHP != playerHealtbar.fillAmount)
        {
            playerHealtbar.fillAmount = Mathf.Lerp(playerHealtbar.fillAmount, currentHP / maxHp, Time.deltaTime * lerpSpeed);
            HPText.text = "HP: " + Mathf.Round(playerHealtbar.fillAmount * 100) + " / " + maxHp;
        }

        if (currentMP != playerManabar.fillAmount)
        {
            playerManabar.fillAmount = Mathf.Lerp(playerManabar.fillAmount, currentMP / maxMp, Time.deltaTime * lerpSpeed);
            MPText.text = "MP: " + Mathf.Round(playerManabar.fillAmount * 100) + " / " + maxMp;
        }

        if(currentEXP != EXPbar.fillAmount)
        {
            EXPbar.fillAmount = Mathf.Lerp(EXPbar.fillAmount, currentEXP / maxEXP, Time.deltaTime * lerpSpeed);
            EXPtext.text = "XP: " + currentEXP + "/" + maxEXP;
        }
        if(currentEXP >= maxEXP)
        {
            playerLevel += 1;
            playerLevelText.text = playerLevel.ToString();
            maxEXP = Mathf.Floor(100 * playerLevel * Mathf.Pow(playerLevel, 0.5f));
            currentEXP = 0;
            print("JEE LEVEL UP!!!");
        }
    }

    public void AddPlayerHealt(int healtAmmount)
    {
        currentHP += healtAmmount;

        if (currentHP > maxHp)
        {
            currentHP = maxHp;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHP -= damageToGive;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    private void Die()
    {
        print(charName + " kuoli");
    }

    public void AddPlayerMana(int manaAmmount)
    {
        currentMP += manaAmmount;

        if(currentMP > maxMp)
        {
            currentMP = maxMp;
        }
    }

    public void AddPlayerEXP(int EXPammount)
    {
        currentEXP += EXPammount;
    }

    public void HurtPlayerMana(int damageToGive)
    {
        currentMP -= damageToGive;

        if (currentMP <= 0)
        {
            currentMP= 0;
        }
    }

    public void SetMaxHP()
    {
        currentHP = maxHp;
    }

    public void SetMaxMP()
    {
        currentMP = maxMp;
    }
}
