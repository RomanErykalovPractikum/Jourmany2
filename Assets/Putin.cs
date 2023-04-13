using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Putin;

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

        //state
        public KingState kingState;
    }

    public GameObject[] heroes = new GameObject[3];
    public GameObject buttonYes;
    public GameObject buttonNo;
    public GameObject buttonOk;
    public GameObject mainText;

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

    private Dictionary<int, string> indexHeroes = new Dictionary<int, string>()
    {
        [0] = "Lepry",
        [1] = "Ninja",
        [2] = "Dark"
    };
    private GameObject hero;
    private int heroNumber;
    private GameState gameState;
    private List<int> heroesHistory = new List<int>();

    void Awake()
    {
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

        Question();
    }

    public void Question()
    {
        UpdateGameStatus();
        buttonOk.SetActive(false);
        if (hero!=null) hero.SetActive(false);

        do
        {
            heroNumber = Random.Range(0, 3);
            Debug.Log(heroNumber);
        }
        while ((heroesHistory.Count != 0) && (heroesHistory[heroesHistory.Count - 1] == heroNumber));

        heroesHistory.Add(heroNumber);
        hero = heroes[heroNumber];
        hero.SetActive(true);
        mainText.GetComponent<Text>().text = GameObject.Find(indexHeroes[heroNumber]).GetComponent<HeroScript>().Question(heroNumber);
        buttonYes.SetActive(true);
        buttonNo.SetActive(true);
    }

    public void Answer(bool answer)
    {
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        mainText.GetComponent<Text>().text = GameObject.Find(indexHeroes[heroNumber]).GetComponent<HeroScript>().Answer(heroNumber, answer);
        buttonOk.SetActive(true);
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



