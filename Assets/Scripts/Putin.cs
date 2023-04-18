using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Putin : MonoBehaviour
{
    public enum KingState
    {
        ok, war, sick, epidemy, madness, delight, revolt
    }
    private Dictionary<KingState, string> conditionString = new Dictionary<KingState, string>()
    {
        [KingState.ok] = "Отлично",
        [KingState.war] = "Война",
        [KingState.sick] = "Болезнь",
        [KingState.epidemy] = "Эпидемия",
        [KingState.madness] = "Безумие",
        [KingState.delight] = "Восторг",
        [KingState.revolt] = "Бунт",
    };

    public struct GameState
    {
        //resources
        public int food;
        public int money;
        public int techno;
        public int pollen;

        //relationships
        public int workers;
        public int pets;
        public int robots;
        public int gloves;
        public int scientists;
        public int galaxy;

        //KingState
        public KingState kingState;
    }

    private const int HEROES_COUNT = 18;
    public GameObject[] heroes = new GameObject[HEROES_COUNT]; //GameObject
    public Character[] characters = new Character[HEROES_COUNT];  //Классы реализующие логику через виртуальные методы

    public GameObject buttonYes;
    public GameObject buttonNo;
    public GameObject buttonOk;
    public GameObject buttonOk2;

    public GameObject mainText;
    public GameObject name;
    public GameObject union;

    public GameObject food;
    public GameObject money;
    public GameObject techno;
    public GameObject pollen;

    public GameObject workers;
    public GameObject pets;
    public GameObject robots;   
    public GameObject gloves;   
    public GameObject scientists;
    public GameObject galaxy;

    public GameObject kingState;

    private int heroNumber;
    private GameState gameState;
    private List<int> heroesHistory = new List<int>();

    void Start()
    {
        characters[0] = new RobotKindCharacter();
        characters[1] = new RobotSloppyCharacter();
        characters[2] = new RobotWarCharacter();
        characters[3] = new PetCatCharacter();
        characters[4] = new PetDogCharacter();
        characters[5] = new PetCatDogCharacter();
        characters[6] = new DonSnitchCharacter();
        characters[7] = new DonSandCharacter();
        characters[8] = new DonnaClipsCharacter();
        characters[9] = new MrLeeCharacter();
        characters[10] = new MrsRightCharacter();
        characters[11] = new MrHubrisCharacter();
        characters[12] = new ReptilianCharacter();
        characters[13] = new SlimeCharacter();
        characters[14] = new KrakenCharacter();
        characters[15] = new DrPiffCharacter();
        characters[16] = new DrBoltCharacter();
        characters[17] = new DrPlotCharacter();

        gameState.food = gameState.money = gameState.techno = gameState.pollen = 10;
        gameState.workers = gameState.pets = gameState.robots = gameState.gloves = gameState.scientists = gameState.galaxy = 5;
        gameState.kingState = KingState.ok;

        foreach (GameObject hero in heroes)
        {
            hero.SetActive(false);
        }

        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        buttonOk.SetActive(false);
        buttonOk2.SetActive(false);

        UpdateGameStatus();

        Question();
    }

    public void Question()
    {
        buttonOk.SetActive(false);
        buttonOk2.SetActive(false);
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);

        if (heroes[heroNumber] != null) heroes[heroNumber].SetActive(false);

        do
        {
            heroNumber = Random.Range(0, HEROES_COUNT);
            Debug.Log(heroNumber);
            
        }
        while ((heroesHistory.Count != 0) && (heroesHistory[heroesHistory.Count - 1] == heroNumber));

        heroesHistory.Add(heroNumber);
        heroes[heroNumber].SetActive(true);

        name.GetComponent<Text>().text = characters[heroNumber].name;
        union.GetComponent<Text>().text = characters[heroNumber].union;
        mainText.GetComponent<Text>().text = characters[heroNumber].Question().questionString;


    }

    public void Answer(bool answer)
    {
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        buttonOk.SetActive(true);

        mainText.GetComponent<Text>().text = characters[heroNumber].Answer(answer).answerString;

    }

    public void PostAnswer()
    {
        mainText.GetComponent<Text>().text = new PostAnswer("Вот и ладненько!").postAnswerString;

        UpdateGameStatus();

        buttonOk.SetActive(false);
        buttonOk2.SetActive(true);
    }

    void UpdateGameStatus()
    {
        food.GetComponent<Text>().text = gameState.food.ToString();
        money.GetComponent<Text>().text = gameState.money.ToString();
        techno.GetComponent<Text>().text = gameState.techno.ToString();
        pollen.GetComponent<Text>().text = gameState.pollen.ToString();

        workers.GetComponent<Text>().text = gameState.workers.ToString();
        pets.GetComponent<Text>().text = gameState.pets.ToString();
        robots.GetComponent<Text>().text = gameState.robots.ToString();
        gloves.GetComponent<Text>().text = gameState.gloves.ToString();
        scientists.GetComponent<Text>().text = gameState.scientists.ToString();
        galaxy.GetComponent<Text>().text = gameState.galaxy.ToString();

        kingState.GetComponent<Text>().text = conditionString[gameState.kingState];
    }
}



