using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Global
public class Character
{
    public string name;
    public string union;

    public Character (string name, string union)
    {
        this.name = name;
        this.union = union; 
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

public class Global : MonoBehaviour { }

public struct CharacterAnswer
{
    public string answerString;
    public CharacterAnswer(string answerString)
    {
        this .answerString = answerString; 
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