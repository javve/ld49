using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartnerController : MonoBehaviour
{
    public bool followPlayer;
    private GameObject player;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 0.3f)
            {
                float step = 0.3f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            }
        }
    }


    private void OnMouseDown()
    {
        Debug.Log("Klick partner");
        if (Vector3.Distance(transform.position, player.transform.position) > 0.3f)
        {
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
            else
            {
                if (GameState.instance.CanHelp())
                {
                    followPlayer = true;
                }
            }
        }
    }

    public void GoToKitchen()
    {
        followPlayer = false;
        GameState.instance.atTable = true;
        StartCoroutine(HardMoveTo(new Vector3(0.063f, -0.568f, 0), 2.0f));
    }
    


    IEnumerator HardMoveTo(Vector3 endPosition, float duration)
    {
        float time = 0;
        Vector3 startValue = transform.position;
        //gameObject.GetComponent<Rigidbody2D>().simulated = false;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startValue, endPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
        //gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }
}
