using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnMouseDown()
    {
        GameObject player = GameObject.Find("Player");
        Collider2D c1 = player.GetComponent<Collider2D>();
        Collider2D c2 = gameObject.GetComponent<Collider2D>();
        ColliderDistance2D d = Physics2D.Distance(c1, c2);
        Debug.Log("Klick partner");
        if (d.distance < 0.2f)
        {
            Debug.Log("Close");
            if (player.GetComponent<PlayerController>().hasCoffee)
            {
                Debug.Log("Has coffee");
                player.GetComponent<PlayerController>().hasCoffee = false;
                if (GameState.instance.firstCoffee)
                {
                    Debug.Log("Got second coffee");
                    GameState.instance.secondCoffee = true;
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(236, 104, 104);
                }
                else
                {
                    Debug.Log("Got first coffee");
                    GameState.instance.firstCoffee = true;
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 104, 104);
                }
            } 
        }
    }
}
