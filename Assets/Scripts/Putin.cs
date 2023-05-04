using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;



public class Putin : MonoBehaviour
{

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
        public KingStateStruct kingState;
        public GovermentStateStruct govermentState;
    }

    public struct KingStateStruct
    {
        public bool sick;
        public bool madness;
        public bool delight;

        public bool Ok()
        {
            if (sick || madness|| delight) return false; else return true;
        }

        public override string ToString()
        {
            string s = "";
            if ( Ok() ) return "ОК";
            if ( sick ) s += "Болен ";
            if ( madness) s += "Безумен ";
            if ( delight ) s += "Восторг ";
            return s.Trim();

        }
    }

    public struct GovermentStateStruct
    {
        public bool war;
        public bool epidemy;
        public bool revolt;

        public bool Ok()
        {
            if (war || epidemy || revolt) return false; else return true;
        }

        public override string ToString()
        {
            string s = "";
            if ( Ok() ) return "ОК";
            if ( war ) s += "Война ";
            if ( epidemy ) s += "Эпидемия ";
            if ( revolt) s += "Бунт ";
            return s.Trim();

        }
    }



    private const int HEROES_COUNT = 18;
    public GameObject[] heroes = new GameObject[HEROES_COUNT]; //GameObject
    public Character[] characters = new Character[HEROES_COUNT];  //Классы реализующие логику через виртуальные методы

    public GameObject buttonYes;
    public GameObject buttonNo;
    public GameObject buttonOk;
    public GameObject buttonOk2;

    public GameObject mainText;
    public GameObject characterName;
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
    public GameObject govermentState;

    private int heroNumber;
    private GameState gameState;
    private List<int> heroesHistory = new List<int>();

    CharacterAnswerStruct answerFromCharacter; //структура ответа от перса присутсвует в Answer 
    List<string> postAnswerList = new List<string>(); //доделать смотри ниже 

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
        gameState.kingState = new KingStateStruct() { sick = true, madness = true, delight = false };
        gameState.govermentState = new GovermentStateStruct() { war = true , epidemy = true, revolt = true };

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

        heroes[heroNumber].SetActive(false);

        do
        {
            heroNumber = Random.Range(0, HEROES_COUNT);
            Debug.Log(heroNumber);

        }
        while ((heroesHistory.Count != 0) && (heroesHistory[heroesHistory.Count - 1] == heroNumber));

        heroNumber = 0; //DELETE
        heroesHistory.Add(heroNumber);
        heroes[heroNumber].SetActive(true);

        characterName.GetComponent<Text>().text = characters[heroNumber].characterName;
        union.GetComponent<Text>().text = characters[heroNumber].union;
        mainText.GetComponent<Text>().text = characters[heroNumber].Question().questionString;


    }

    public void Answer(bool answer)
    {
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
        buttonOk.SetActive(true);

        answerFromCharacter = characters[heroNumber].Answer(answer);
        mainText.GetComponent<Text>().text = answerFromCharacter.answerString;

    }

    public void PostAnswer()
    {
        mainText.GetComponent<Text>().text = new PostAnswerStruct("Дело сделано!").postAnswerString; // потом убрать

        PostProcessAnswerFromCharacter();
        UpdateGameStatus();
        PreparePostAnswer();


        buttonOk.SetActive(false);
        buttonOk2.SetActive(true);
    }

    private void PostProcessAnswerFromCharacter()
    {
        //обнуляем
        postAnswerList.Clear();
        //resources
        gameState.food += answerFromCharacter.diffGameState.diffFood;
        if (answerFromCharacter.diffGameState.diffFood > 0) postAnswerList.Add("Пищи стало больше: +" + answerFromCharacter.diffGameState.diffFood);
        if(answerFromCharacter.diffGameState.diffFood < 0) postAnswerList.Add("Запасы еды уменьшаются: " + answerFromCharacter.diffGameState.diffFood);
        gameState.money += answerFromCharacter.diffGameState.diffMoney;
        if (answerFromCharacter.diffGameState.diffMoney > 0) postAnswerList.Add("Доходы выросли: +" + answerFromCharacter.diffGameState.diffMoney);
        if (answerFromCharacter.diffGameState.diffMoney < 0) postAnswerList.Add("Расходы возросли: " + answerFromCharacter.diffGameState.diffMoney);
        gameState.techno += answerFromCharacter.diffGameState.diffTechno;
        if (answerFromCharacter.diffGameState.diffTechno > 0) postAnswerList.Add("Технологии идут вперед: +" + answerFromCharacter.diffGameState.diffTechno);
        if (answerFromCharacter.diffGameState.diffTechno < 0) postAnswerList.Add("Технологии отстают в развитии: " + answerFromCharacter.diffGameState.diffTechno);
        gameState.pollen += answerFromCharacter.diffGameState.diffPollen;
        if (answerFromCharacter.diffGameState.diffPollen > 0) postAnswerList.Add("Пополнение запасов пыльцы: +" + answerFromCharacter.diffGameState.diffPollen);
        if (answerFromCharacter.diffGameState.diffPollen < 0) postAnswerList.Add("Сокращение запасов пыльцы : " + answerFromCharacter.diffGameState.diffPollen);//Синоним уменьшилось
        //union
        gameState.workers += answerFromCharacter.diffGameState.diffWorkers;
        if (answerFromCharacter.diffGameState.diffWorkers > 0) postAnswerList.Add("Отношение Трудового Братства: +" + answerFromCharacter.diffGameState.diffWorkers);
        if (answerFromCharacter.diffGameState.diffWorkers < 0) postAnswerList.Add("Отношение Трудового Братства: " + answerFromCharacter.diffGameState.diffWorkers);
        gameState.pets += answerFromCharacter.diffGameState.diffPets;
        if (answerFromCharacter.diffGameState.diffPets > 0) postAnswerList.Add("Отношение Братьев Меньших: +" + answerFromCharacter.diffGameState.diffPets);
        if (answerFromCharacter.diffGameState.diffPets < 0) postAnswerList.Add("Отношение Братьев Меньших: " + answerFromCharacter.diffGameState.diffPets);
        gameState.robots += answerFromCharacter.diffGameState.diffRobots;
        if (answerFromCharacter.diffGameState.diffRobots > 0) postAnswerList.Add("Отношение Роботов: +" + answerFromCharacter.diffGameState.diffRobots);
        if (answerFromCharacter.diffGameState.diffRobots < 0) postAnswerList.Add("Отношение Роботов: " + answerFromCharacter.diffGameState.diffRobots);
        gameState.gloves += answerFromCharacter.diffGameState.diffGloves;
        if (answerFromCharacter.diffGameState.diffGloves > 0) postAnswerList.Add("Отношение Золотой Перчатки: +" + answerFromCharacter.diffGameState.diffGloves);
        if (answerFromCharacter.diffGameState.diffGloves < 0) postAnswerList.Add("Отношение Золтой Перчатки: " + answerFromCharacter.diffGameState.diffGloves);
        gameState.scientists += answerFromCharacter.diffGameState.diffScientists;
        if (answerFromCharacter.diffGameState.diffScientists > 0) postAnswerList.Add("Отношение Исследователей: +" + answerFromCharacter.diffGameState.diffScientists);
        if (answerFromCharacter.diffGameState.diffScientists < 0) postAnswerList.Add("Отношение Исследователей: " + answerFromCharacter.diffGameState.diffScientists);
        gameState.galaxy += answerFromCharacter.diffGameState.diffGalaxy;
        if (answerFromCharacter.diffGameState.diffGalaxy > 0) postAnswerList.Add("Отношение Космических Обитателей: +" + answerFromCharacter.diffGameState.diffGalaxy);
        if (answerFromCharacter.diffGameState.diffGalaxy < 0) postAnswerList.Add("Отношение Космических Обитателей: " + answerFromCharacter.diffGameState.diffGalaxy);
        //king state
        //sick
        //
        if ((answerFromCharacter.diffGameState.diffKingSick == 1) && gameState.kingState.sick) //обнулить счетчик болезни м.б SickStruct
        {
            
        }; 
        if ((answerFromCharacter.diffGameState.diffKingSick == 1) && gameState.kingState.Ok()) gameState.kingState.sick = true; //доделать, передать инфу/сообщение в PostAnwser()
        if ((answerFromCharacter.diffGameState.diffKingSick == 1) && gameState.kingState.madness) gameState.kingState.sick = true; //доделать, передать инфу/сообщение в PostAnwser()
        if ((answerFromCharacter.diffGameState.diffKingSick == -1) && gameState.kingState.sick) gameState.kingState.sick = false;  //доделать, передать инфу/сообщение в PostAnwser() 
        if ((answerFromCharacter.diffGameState.diffKingSick == 1) && gameState.kingState.delight) gameState.kingState.delight = false;
        //madness
        if ((answerFromCharacter.diffGameState.diffKingMadness == 1) && gameState.kingState.madness) { }; //обнулить счетчик Безумия м.б MadnessStruct
        if ((answerFromCharacter.diffGameState.diffKingMadness == 1) && gameState.kingState.Ok()) gameState.kingState.madness = true; //доделать, передать инфу/сообщение в PostAnwser()
        if ((answerFromCharacter.diffGameState.diffKingMadness == 1) && gameState.kingState.sick) gameState.kingState.madness = true; //доделать, передать инфу/сообщение в PostAnwser()
        if ((answerFromCharacter.diffGameState.diffKingMadness == -1) && gameState.kingState.madness) gameState.kingState.madness = false;  //доделать, передать инфу/сообщение в PostAnwser()
        //delight
        if ((answerFromCharacter.diffGameState.diffKingDelight== 1) && gameState.kingState.delight) { }; //обнулить счетчик болезни м.б DelightStruct 
        if ((answerFromCharacter.diffGameState.diffKingDelight == 1) && gameState.kingState.Ok()) gameState.kingState.delight = true; //доделать, передать инфу/сообщение в PostAnwser()
        if ((answerFromCharacter.diffGameState.diffKingDelight == 1) && gameState.kingState.sick) gameState.kingState.sick = false;
        if ((answerFromCharacter.diffGameState.diffKingDelight == -1) && gameState.kingState.delight) gameState.kingState.delight = false;
        //goverment state  
        if (answerFromCharacter.diffGameState.diffWar == 1) { }; //доделать, передать инфу/сообщение в PostAnwser()
        if (answerFromCharacter.diffGameState.diffWar == -1) { }; //доделать, передать инфу/сообщение в PostAnwser()
    }

    private void PreparePostAnswer() 
    {
        foreach (string line in postAnswerList)
        {
           
        }

            
    }

    private void UpdateGameStatus()
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

        kingState.GetComponent<Text>().text = gameState.kingState.ToString();
        govermentState.GetComponent<Text>().text = gameState.govermentState.ToString();
    }

    
}



