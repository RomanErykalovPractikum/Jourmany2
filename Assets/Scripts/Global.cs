using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


//Global
abstract public class Character
{
    protected int id;
    protected string stage;

    public string characterName;
    public string union;

    private int numberOfQuests;
    protected List<int> freshQuestIdStack = new List<int>(); // !!!!!!!!!!!!!!! ���� ������ ������� �� � ����� ����������� ��������� ������� �� �� ������ id � stage ������ ������ �����������
    protected string path;

    //const
    protected DiffGameStateStruct ERROR_DIFF_GAME_STATUS = new DiffGameStateStruct(0, 0, 0, 0, /**/ 0, 0, 0, 0, 0, 0 /**/, 0, 0, 0, /**/ 0, 0, 0);

    public Character (string characterName, string union, int numberOfQuests)
    {
        this.characterName = characterName;
        this.union = union; 
        this.numberOfQuests = numberOfQuests;
        id = -1;
        stage = "";
        for (int i = 0; i < numberOfQuests; i++) { freshQuestIdStack.Add(i); }
    }

    public virtual CharacterQuestionStruct Question()
    {
        Debug.LogError("������! ����� �� �������� ������");
        return new CharacterQuestionStruct("������! ����� �� �������� ������");
    }

    public virtual CharacterAnswerStruct Answer(bool answer)
    {
        if (answer) 
        {
            Debug.LogError("������! ����� �� �������� ������");
            return new CharacterAnswerStruct("������! ����� �� �� �������� ������", ERROR_DIFF_GAME_STATUS);
        }
        else
        {
            Debug.LogError("������! ����� �� �������� ������");
            return new CharacterAnswerStruct("������! ����� ��� �� �������� ������", ERROR_DIFF_GAME_STATUS);
        }
    }

  }

public struct CharacterQuestionStruct
{
    public string questionString;
    public CharacterQuestionStruct(string questionString)
    {
        this.questionString = questionString;
    }
}

public struct CharacterAnswerStruct
{
    public string answerString;
    public DiffGameStateStruct diffGameState;

    public CharacterAnswerStruct(string answerString, DiffGameStateStruct diffGameState)
    {
        this.answerString = answerString;
        this.diffGameState = diffGameState;
    }
}

public struct DiffGameStateStruct
{
    //resources
    public int diffFood;
    public int diffMoney;
    public int diffTechno;
    public int diffPollen;

    //relationships
    public int diffWorkers;
    public int diffPets;
    public int diffRobots;
    public int diffGloves;
    public int diffScientists;
    public int diffGalaxy;

    //king state
    public int diffKingSick; // -1 �������, 0 �� ������, +1 ����������
    public int diffKingMadness;
    public int diffKingDelight;

    //goverment state
    public int diffWar;
    public int diffEpidemy;
    public int diffRevolt;

    public DiffGameStateStruct(int diffFood, int diffMoney, int diffTechno, int diffPollen, int diffWorkers, int diffPets, int diffRobots, int diffGloves, int diffScientists,
        int diffGalaxy, int diffKingSick, int diffKingMadness, int diffKingDelight, int diffWar, int diffEpidemy, int diffRevolt)
    {
        this.diffFood = diffFood;
        this.diffMoney = diffMoney;
        this.diffTechno = diffTechno;
        this.diffPollen = diffPollen;
        this.diffWorkers = diffWorkers;
        this.diffPets = diffPets;
        this.diffRobots = diffRobots;
        this.diffGloves = diffGloves;
        this.diffScientists = diffScientists;
        this.diffGalaxy = diffGalaxy;
        this.diffKingSick = diffKingSick;
        this.diffKingMadness = diffKingMadness;
        this.diffKingDelight = diffKingDelight;
        this.diffWar = diffWar;
        this.diffEpidemy = diffEpidemy;
        this.diffRevolt = diffRevolt;
    }
}

public struct PostAnswerStruct
{
    public string postAnswerString;
    public PostAnswerStruct(string postAnswerString)
    {
        this.postAnswerString = postAnswerString;
    }
}

public class Global : MonoBehaviour { }


