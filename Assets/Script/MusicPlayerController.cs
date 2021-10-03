using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
