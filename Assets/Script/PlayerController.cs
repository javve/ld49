using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public bool hasCoffee = false;
    public bool hasCat = false;
    public bool hasRobe = false;

    private Vector3 moveTarget = Vector3.zero;


    public float speed = 0.3f;
    Vector2 lastClickedPos;
    bool moving;

    // Update is called once per frame
    void Update()
    {
        if (moveTarget != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, Time.deltaTime * 0.1f);
            if (Vector3.Distance(transform.position, moveTarget) < 0.05f)
            {
                moveTarget = Vector3.zero;
                gameObject.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }
            if (moving && (Vector2)transform.position != lastClickedPos)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            }
            else
            {
                moving = false;
            }
        }
        if (moving)
        {
            gameObject.GetComponent<Animator>().SetBool("walking", true);
        } else
        {
            gameObject.GetComponent<Animator>().SetBool("walking", false);

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        moving = false;
        
    }
    public void GetUpFromBed()
    {
        StartCoroutine(HardMoveTo(new Vector3(-0.29f, 0.975f, 0), 2.0f));
    }
    private void OnMouseDown()
    {
        Debug.Log("HEHEHHE");
    }


        IEnumerator HardMoveTo(Vector3 endPosition, float duration)
    {
        float time = 0;
        Vector3 startValue = transform.position;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;

        while (time < duration)
        {
            transform.position= Vector3.Lerp(startValue, endPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

}
