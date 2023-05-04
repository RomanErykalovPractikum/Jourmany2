using System.Collections;
using System.Collections.Generic;
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
        public int sickDaysLeft;
        public int madnessDaysLeft;
        public int delightDaysLeft;

        public void kingStartSick()
        {
            sickDaysLeft = 10;
        }

        public void kingStartMadness()
        {
            madnessDaysLeft = 7;
        }

        public void kingStartDelight()
        {
            delightDaysLeft = 5;
        }

        public void kingStopSick()
        {
            sickDaysLeft = 0;
        }

        public void kingStopMadness()
        {
            madnessDaysLeft = 0;
        }

        public void kingStopDelight()
        {
            delightDaysLeft = 0;
        }

        public bool Ok()
        {
            if ( (sickDaysLeft > 0) || (madnessDaysLeft > 0) || (delightDaysLeft > 0)) return false; else return true;
        }

        public override string ToString()
        {
            string s = "";
            if ( Ok() ) return "ОК";
            if (sickDaysLeft > 0) s += "Болен ";
            if (madnessDaysLeft > 0) s += "Безумен ";
            if (delightDaysLeft > 0) s += "Восторг ";
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

    public struct SickStruct
    {
        public int daysLeft;
        //что за война (? эпидемия, болезнь)
    }

    public struct WarStruct
    {
        public int daysLeft;

    }

    public struct EpidemyStruct
    {
        public int daysLeft;
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
        gameState.kingState = new KingStateStruct() { sickDaysLeft = 2, madnessDaysLeft = 0, delightDaysLeft = 0 };
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
        buttonYes.SetActive(true); //проверка на Delight

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

        //Скорее всего сюда добавить Mad и Delight

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
        if (answerFromCharacter.diffGameState.diffPollen < 0) postAnswerList.Add("Сокращение запасов пыльцы : " + answerFromCharacter.diffGameState.diffPollen);
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
        if ((answerFromCharacter.diffGameState.diffKingSick == 0) && (gameState.kingState.sickDaysLeft > 0)) 
        {
            postAnswerList.Add("Вы болеете");
        };
        if ((answerFromCharacter.diffGameState.diffKingSick == 1) && (gameState.kingState.sickDaysLeft == 0)) 
        {
            gameState.kingState.kingStartSick();
            postAnswerList.Add("Вы заболели");
        };
        if ((answerFromCharacter.diffGameState.diffKingSick == -1) && (gameState.kingState.sickDaysLeft > 0))
        {
            gameState.kingState.kingStopSick();
            postAnswerList.Add("Вы выздоровели");
        };
        if ((answerFromCharacter.diffGameState.diffKingSick == 1) && (gameState.kingState.delightDaysLeft > 0))
        {
            gameState.kingState.kingStopDelight();
            postAnswerList.Add("Вы заболели и не чувствуете душевный подъем");
        }
        //сюда можно добавить daysLeft--, ипроверку выздоровел ли по кол-ву дней
        //madness
        if ((answerFromCharacter.diffGameState.diffKingMadness == 0) && (gameState.kingState.madnessDaysLeft > 0))
        {
            postAnswerList.Add("Вы все еще бузумны");
        }
        if ((answerFromCharacter.diffGameState.diffKingMadness == 1) && (gameState.kingState.madnessDaysLeft > 0)) 
        {
            postAnswerList.Add("Вы еще более бузумны");
            gameState.kingState.kingStartMadness();
        };
        if ((answerFromCharacter.diffGameState.diffKingMadness == 1) && (gameState.kingState.madnessDaysLeft == 0))
        {
            postAnswerList.Add("Вы стали безумны, ваши ответы хаотичны");
            gameState.kingState.kingStartMadness();
        }
        if ((answerFromCharacter.diffGameState.diffKingMadness == -1) && (gameState.kingState.madnessDaysLeft > 0))
        {
            postAnswerList.Add("Ваш разум прояснился");
            gameState.kingState.kingStopMadness();
        }
        //delight
        if ((answerFromCharacter.diffGameState.diffKingDelight == 0) && (gameState.kingState.delightDaysLeft > 0))
        {
            postAnswerList.Add("Вы все еще в восторге");
        }
        if ((answerFromCharacter.diffGameState.diffKingDelight== 1) && (gameState.kingState.delightDaysLeft > 0)) 
        {
            postAnswerList.Add("Вы снова в восторге");
            gameState.kingState.kingStartDelight();
        }
        if ((answerFromCharacter.diffGameState.diffKingDelight == 1) && gameState.kingState.Ok())
        {
            postAnswerList.Add("Вы в восторге от происходящего и не можете никому отказать");
            gameState.kingState.kingStartMadness();  
        }
        if ((answerFromCharacter.diffGameState.diffKingDelight == 1) && (gameState.kingState.sickDaysLeft > 0))
        {
            gameState.kingState.kingStopSick();
            postAnswerList.Add("Неожиданный подъем сил помогает преодолеть вашу болезнь");
        }
        if ((answerFromCharacter.diffGameState.diffKingDelight == -1) && (gameState.kingState.delightDaysLeft > 0))
        {
            postAnswerList.Add("Ваш восторг прошел");
            gameState.kingState.kingStopDelight();
        }
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



