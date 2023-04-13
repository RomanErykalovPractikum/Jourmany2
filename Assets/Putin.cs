using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Putin : MonoBehaviour
{

    

    public GameObject[] heroes = new GameObject[3];
    public GameObject buttonYes;
    public GameObject buttonNo;
    public GameObject buttonOk;
    public GameObject mainText;

    private Dictionary<int, string> indexHeroes = new Dictionary<int, string>()
    {
        [0] = "Lepry",
        [1] = "Ninja",
        [2] = "Dark"
    };
    private enum Stage { question, waitingForPushYesNoButton, answer , waitingForPushOkButton };
    private Stage gameStage = Stage.question;
    private GameObject hero;
    private int heroNumber;

    void Awake()
    {

        foreach (GameObject hero in heroes)
        {
            hero.SetActive(false);
        }
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        buttonOk.SetActive(false);
        Question();
    }

    public void Question()
    {
        buttonOk.SetActive(false);
        if (!(hero is null)) hero.SetActive(false);
        heroNumber = Random.Range(0, 3);
        hero = heroes[heroNumber];
        hero.SetActive(true);
        mainText.GetComponent<Text>().text = GameObject.Find(indexHeroes[heroNumber]).GetComponent<HeroScript>().Question(heroNumber);
        gameStage = Stage.waitingForPushYesNoButton;
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);
    }

    public void Answer(bool answer)
    {
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        gameStage = Stage.answer;
        mainText.GetComponent<Text>().text = GameObject.Find(indexHeroes[heroNumber]).GetComponent<HeroScript>().Answer(heroNumber, answer);
        buttonOk.SetActive(true);
        gameStage = Stage.waitingForPushOkButton;
    }
}



