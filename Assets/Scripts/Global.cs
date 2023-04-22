using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;



//Global
public class Character
{
    public string name;
    public string union;

    //����� ����
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
        ///����� ����
        DefineQuest(); //���� ����� ���� ����� ������ ������, ����� � ������ ������ ������!!!!
        //
        return new CharacterQuestion("������! ����� �� �������� ������");
    }

    public virtual CharacterAnswer Answer(bool answer)
    {
        if (answer) 
        {
            //����� ����
            NextStudyQuestOrFinish();//���� ����� ������� ����� ��
            //
            return new CharacterAnswer("������! ����� �� �� �������� ������");
        }
        else
        {
            //����� ����
            NextStudyQuestOrFinish();
            //
            return new CharacterAnswer("������! ����� ��� �� �������� ������");
        }
    }

    //����� ����
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

    public List<QuestStruct> allCharacterQuests = new List<QuestStruct>(1); //��������!!!

    public void DefineQuest() { }
    public void NextStudyQuestOrFinish() { }
    public void InitAllQuests(string s) { } //����� �� ����� ��������� �� ������� � allQuests
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


