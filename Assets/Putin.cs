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
    private enum Stage { question, waitingForAnswer, answer , waitingForNextQuestion };
    private Stage gameStage = Stage.question;
    private GameObject hero;
    private int heroNumber;

    void Start()
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

    void Question()
    {
        //Inactivate old hero

        //new hero, question buttons
        heroNumber = Random.Range(0, 3);
        GameObject hero = heroes[heroNumber];
        mainText.GetComponent<Text>().text = GameObject.Find(indexHeroes[heroNumber]).GetComponent<HeroScript>().Question(heroNumber);
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);
        gameStage = Stage.waitingForAnswer;
    }

    void Update()
    {
        if (gameStage == Stage.waitingForAnswer || gameStage == Stage.waitingForNextQuestion ) { return; };


    }

    public void OnClickYesNo (bool answer)
    {
        gameStage = Stage.answer;
        mainText.GetComponent<Text>().text = GameObject.Find(indexHeroes[heroNumber]).GetComponent<HeroScript>().Answer(heroNumber, answer);
    }
}



