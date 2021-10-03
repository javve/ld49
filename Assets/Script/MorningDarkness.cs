using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningDarkness : MonoBehaviour
{
    GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = player.transform.position;
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutR(new Color(0, 0, 0, 0), 4.0f));
    }
    public void FadeIn()
    {
        StartCoroutine(FadeOutR(new Color(0, 0, 0, 1f), 4.0f));
    }


    IEnumerator FadeOutR(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = transform.GetComponent<Renderer>().material.color;

        while (time < duration)
        {
            transform.GetComponent<Renderer>().material.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.GetComponent<Renderer>().material.color = endValue;
    }
}
