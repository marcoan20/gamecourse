using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;

    public Image fadeScreen;
    public float fadeSpeed = 1f;

    private bool shouldFadeIn;
    private bool shouldFadeOut;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeIn)
        {
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1f)
            {
                shouldFadeIn = false;
            }
        }

        if(shouldFadeOut)
        {
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));


            if(fadeScreen.color.a == 0f)
            {
                shouldFadeOut = false;
            }
        }
    }

    public void FadeIn()
    {
        shouldFadeIn = true;
        shouldFadeOut = false;
    }

    public void FadeOut()
    {
        shouldFadeIn = false;
        shouldFadeOut = true;
    }
}
