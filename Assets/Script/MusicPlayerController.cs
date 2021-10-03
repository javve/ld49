using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerController : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameState.instance.music) { return; }

        GameObject player = GameObject.Find("Player");
        Collider2D c1 = player.GetComponent<Collider2D>();
        Collider2D c2 = gameObject.GetComponent<Collider2D>();
        ColliderDistance2D d = Physics2D.Distance(c1, c2);

        if (d.distance < 0.1f)
        {
            GameState.instance.music = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }


    private void OnMouseOver()
    {
        GameObject.Find("MusicTooltip").GetComponent<Text>().enabled = true;
    }
    private void OnMouseExit()
    {
        GameObject.Find("MusicTooltip").GetComponent<Text>().enabled = false;
    }
}
