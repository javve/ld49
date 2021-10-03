using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    [SerializeField]
    public bool sunlight = false;
    [SerializeField]
    public bool firstCoffee = false;
    [SerializeField]
    public bool secondCoffee = false;
    [SerializeField]
    public bool robe = false;
    [SerializeField]
    public bool cat = false;
    [SerializeField]
    public bool music = false;
    [SerializeField]
    public bool breakfast = false;

    [SerializeField]
    public bool introDone = false;

    private bool endGame = false;

    [SerializeField]
    public Text scoreText;
    [SerializeField]
    public Text playerDialog;
    [SerializeField]
    public Text partnerDialog;


    GameObject player;
    PlayerController playerController;

    private void Start()
    {
        instance = this;
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        if (!introDone)
        {
            StartCoroutine(IntroInfo());
        } else
        {
            playerController.GetUpFromBed();
        }
    }

    void Update()
    {
        int score = GetScore();   
        scoreText.text = score.ToString("F0");

        if (score > 19 && endGame == false)
        {
            Debug.Log("End game!");
            endGame = true;
            StartCoroutine(EndGame());
            //partnerDialog.text = "Bkaaaaa";
        }
    }

    public int GetScore()
    {
        int score = 0;
        if (sunlight) score += 10;
        if (firstCoffee) score += 10;
        if (secondCoffee) score += 10;
        if (robe) score += 10;
        if (cat) score += 10;
        if (music) score += 10;
        if (breakfast) score += 10;
        return score;
    }

    public bool CanHelp()
    {
        return (GetScore() > 10);
    }

    IEnumerator EndGame()
    {
        GameObject.Find("Light").GetComponent<MorningDarkness>().FadeIn();
        yield return StartCoroutine(WriteText(partnerDialog, "I feel that this'll be a good day after all.", 5.0f));
        //yield return;
    }

    IEnumerator IntroInfo()
    {
        yield return StartCoroutine(WriteText(playerDialog, "Morning...", 2.5f));
        yield return StartCoroutine(WriteText(partnerDialog, "....", 5.0f));
        yield return new WaitForSeconds(.5f);
        yield return StartCoroutine(WriteText(playerDialog, "How are you today?", 2.5f));
        yield return StartCoroutine(WriteText(partnerDialog, "Not that great. It's one of those days....", 5.0f));
        partnerDialog.text = "";
        playerDialog.text = "";
        yield return new WaitForSeconds(1.2f);
        yield return StartCoroutine(WriteText(playerDialog, "Oh... I'll see if I can help.", 2.5f));
        yield return new WaitForSeconds(1.5f);
        playerDialog.text = "";
        playerController.GetUpFromBed();

    }

    IEnumerator WriteText(Text text, string dialog, float duration)
    {
        int i = 0;
        string str = "";

        while (i < dialog.Length)
        {
            str = str + dialog[i];
            text.text = str;
            i++;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(.5f);
    }
}
