using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeMaker : MonoBehaviour
{
    private bool isBrewing = false;
    float brewingStarted;

    [SerializeField]
    public Sprite idleSprite;
    [SerializeField]
    public Sprite brewingSprite;


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
        if (GameState.instance.firstCoffee && GameState.instance.secondCoffee) { return; }


        GameObject player = GameObject.Find("Player");
        Collider2D c1 = player.GetComponent<Collider2D>();
        Collider2D c2 = gameObject.GetComponent<Collider2D>();
        ColliderDistance2D d = Physics2D.Distance(c1, c2);

        if (d.distance < 0.2f)
        {
            if (isBrewing)
            {
                if (Time.time - brewingStarted > 10f)
                {
                    PlayerController p = player.GetComponent<PlayerController>();
                    p.hasCoffee = true;
                    Debug.Log("Has coffee");
                    gameObject.GetComponent<SpriteRenderer>().sprite = idleSprite;
                } else
                {
                    Debug.Log("Wait for it");
                }
            }
            else
            {
                brewingStarted = Time.time;
                isBrewing = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = brewingSprite;
            }
        }


    }

    private void OnMouseOver()
    {
        GameObject.Find("CoffeeTooltip").GetComponent<Text>().enabled = true;
    }
    private void OnMouseExit()
    {
        GameObject.Find("CoffeeTooltip").GetComponent<Text>().enabled = false;
    }
}
