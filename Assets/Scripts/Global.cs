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
    protected List<int> freshQuestIdStack = new List<int>(); // !!!!!!!!!!!!!!! Если король заболел то с долей вероятности выполняем лечение но не меняем id и stage отогда скрипт продолжится

    public Character (string characterName, string union, int numberOfQuests)
    {
        this.characterName = characterName;
        this.union = union; 
        this.numberOfQuests = numberOfQuests;
        id = -1;
        stage = "";
        for (int i = 0; i < numberOfQuests; i++) { freshQuestIdStack.Add(i); }
    }

    public virtual CharacterQuestion Question()
    {
        return new CharacterQuestion("Ошибка! Ответ из базового класса");
    }

    public virtual CharacterAnswer Answer(bool answer)
    {
        if (answer) 
        {
            return new CharacterAnswer("Ошибка! Ответ ДА из базового класса");
        }
        else
        {
            return new CharacterAnswer("Ошибка! Ответ НЕТ из базового класса");
        }
    }

  }

public struct CharacterQuestion
{
    public string questionString;
    public CharacterQuestion(string questionString)
    {
        this.questionString = questionString;
    }
}

public struct CharacterAnswer
{
    public string answerString;
    public CharacterAnswer(string answerString)
    {
        this.answerString = answerString;
    }
}

public struct PostAnswer
{
    public string postAnswerString;
    public PostAnswer(string postAnswerString)
    {
        this.postAnswerString = postAnswerString;
    }
}

public class Global : MonoBehaviour { }


