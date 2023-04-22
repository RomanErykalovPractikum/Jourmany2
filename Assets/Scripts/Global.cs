using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;



//Global
public class Character
{
    public string name;
    public string union;

    //проба пера
    public int questNumber;
    public int nextStage = 0b01;
    //

    public Character (string name, string union)
    {
        this.name = name;
        this.union = union; 
    }

    public virtual CharacterQuestion Question()
    {
        ///проба пера
        DefineQuest(); //либо новый либо взять нужную стадию, квест с камнем всегда первый!!!!
        //
        return new CharacterQuestion("Ошибка! Ответ из базового класса");
    }

    public virtual CharacterAnswer Answer(bool answer)
    {
        if (answer) 
        {
            //проба пера
            NextStudyQuestOrFinish();//если финиш удаляем квест из
            //
            return new CharacterAnswer("Ошибка! Ответ ДА из базового класса");
        }
        else
        {
            //проба пера
            NextStudyQuestOrFinish();
            //
            return new CharacterAnswer("Ошибка! Ответ НЕТ из базового класса");
        }
    }

    //проба пера
    public struct QuestReaction
    {
        int temp; //??????? 
    }

    public struct QuestFormula //next behavior in the "pool"
    {
        int temp; //??????? 
    }

    public struct QuestStruct
    {
        public int id;
        public string question;
        public string answerYes;
        public string answerNo;
        public QuestFormula questFormulaYes;
        public QuestFormula questFormulaNo;
        public QuestReaction questReactionYes;
        public QuestReaction questReactionNo;
    }

    public List<QuestStruct> allCharacterQuests = new List<QuestStruct>(1); //добавить!!!

    public void DefineQuest() { }
    public void NextStudyQuestOrFinish() { }
    public void InitAllQuests(string s) { } //берем из файла записваем по очереди в allQuests
    //
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


