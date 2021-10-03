using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CatController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private GameObject bedroom;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        bedroom = GameObject.Find("Bedroom");
    }

    private void Update()
    {
        if (playerController.hasCat)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 0.3f)
            {
                float step = 0.3f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            }
            //if (Vector3.Distance(transform.position, bedroom.transform.position) < 0.1f)
            //{
                
            //}
        }
    }
    private void OnMouseDown()
    {
        if (GameState.instance.cat) { return; }

        Collider2D c1 = player.GetComponent<Collider2D>();
        Collider2D c2 = gameObject.GetComponent<Collider2D>();
        ColliderDistance2D d = Physics2D.Distance(c1, c2);

        if (d.distance < 0.1f)
        {
            playerController.hasCat = true;

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Bedroom")
        {
            playerController.hasCat = false;
            GameState.instance.cat = true;
            StartCoroutine(HardMoveTo(new Vector3(0.039f, 0.87f, 0), 2.0f));

        }
    }


    IEnumerator HardMoveTo(Vector3 endPosition, float duration)
    {
        float time = 0;
        Vector3 startValue = transform.position;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startValue, endPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }
}