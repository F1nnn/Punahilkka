using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    private Animator anim;

    public bool IsFading {  get;  set; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator FadeToWhite()
    {
        IsFading = true;
        anim.SetTrigger("FadeToWhite");
        while (IsFading)
        {
            yield return null;
        }
    }

    public IEnumerator FadeToBlack() 
    { 
        IsFading = true;
        anim.SetTrigger("FadeToBlack");
        while (IsFading)
        {
            yield return null;
        }
    }

    public void FadeAnimationComplete() => IsFading = false;
}
