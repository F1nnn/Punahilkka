using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warp : MonoBehaviour
{
    [Header("TELEPORTTAUS")]
    [Tooltip("Kartta, jonne siitrryt‰‰n.")]
    [SerializeField] private GameObject targetMap;
    [Tooltip("Sijainti, jonne pelihahmo siirtyy")]
    [SerializeField] GameObject exitPoint;


    [Header("ALUETEKSTI")]
    [SerializeField] private bool needText;
    [SerializeField] private string placeName;
    [SerializeField] private GameObject placeTextHolder;
    [SerializeField] private TMP_Text placeText;


    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Start()
    {
        needText = true;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //musta
            collision.gameObject.SetActive(false);
            ScreenFader screenFader = GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>();
            yield return StartCoroutine(screenFader.FadeToBlack());

            //pelaaja liikkuu
            collision.transform.position = exitPoint.transform.GetChild(0).transform.position;
            //kamera liikkuu
            Camera.main.GetComponent<MainCamera>().SetBound(targetMap);

            if (needText)
            {
                StartCoroutine(ShowPlaceName());
            }

            //valkoinen
            collision.gameObject.SetActive(true);
            yield return StartCoroutine (screenFader.FadeToWhite());
        }
    }

    private IEnumerator ShowPlaceName()
    {
        placeTextHolder.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        placeTextHolder.SetActive(false);
    }
}
