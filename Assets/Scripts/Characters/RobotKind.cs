using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static Putin;

public class RobotKindCharacter : Character
{
    //-------------------------
    string Q0 = "Люди лучше всех остаьных?";
        string A0Y = "Люди рады вашему решению, хотя не все на этой планете человечечкой расы";
        DiffGameStateStruct D0Y = new DiffGameStateStruct (0, 0, 0, 0, /**/ 1, -1, -1, 1, 1, -1 /**/, 0, 0, 0, /**/ 0, 0, 0);
        string A0N = "Представители других планет танцуют, даже домашние питомцы не рычат на роботов";
        DiffGameStateStruct D0N = new DiffGameStateStruct(0, 0, 0, 0, /**/ -1, 1, 1, -1, -1, 1 /**/, 0, 0, 0, /**/ 0, 0, 0);
    string Q1Y = "К вам рришли роботы. Че за фигня? Ты должен быть за нас";
        string A0YY = "Роботы довольны";
        DiffGameStateStruct D0YY = new DiffGameStateStruct(0, 0, 0, 0, /**/ -1, 1, 1, -1, -1, 1 /**/, 0, 0, 0, /**/ 0, 0, 0);
        string A0YN = "Роботы будут бунтовать";
        DiffGameStateStruct D0YN = new DiffGameStateStruct (0, 0, 0, 0, /**/ 1, -1, -1, 1, 1, -1 /**/, 0, 0, 0, /**/ 0, 0, 0);
    string Q1N = "К вам рришли люди. Че за фигня?Ты должен быть за нас";
        string A0NY = "Люди довольны";
        DiffGameStateStruct D0NY = new DiffGameStateStruct (0, 0, 0, 0, /**/ 1, -1, -1, 1, 1, -1 /**/, 0, 0, 0, /**/ 0, 0, 0);
        string A0NN = "Люди будут бунтовать";
        DiffGameStateStruct D0NN = new DiffGameStateStruct(0, 0, 0, 0, /**/ -1, 1, 1, -1, -1, 1 /**/, 0, 0, 0, /**/ 0, 0, 0);
    //------------------------

    public RobotKindCharacter() : base("Alice", "Robots", 1) { }

    public override CharacterQuestionStruct Question()
    {
        if (freshQuestIdStack.Count == 0) return new CharacterQuestionStruct("У этого героя нет квестов");

        if (id == -1) //если квестов не назначено
        {
            id = Random.Range(0, freshQuestIdStack.Count);
        };

        switch (id)
        {
            case 0:
                switch (stage)
                {
                    case "": return new CharacterQuestionStruct(Q0);

                    case "Y": return new CharacterQuestionStruct(Q1Y);

                    case "N": return new CharacterQuestionStruct(Q1N);

                    default:
                        Debug.LogError("Неправильный stage");
                        return new CharacterQuestionStruct("Ошибка неправильный stage в Question");
                }
            default:
                Debug.LogError("Неправильный id");
                return new CharacterQuestionStruct("Ошибка неправильный id в Question");
        }
    }

    public override CharacterAnswerStruct Answer(bool answer)
    {
        switch (id)
        {
            case 0:
                switch (stage)
                {
                    case "":
                        if (answer) { stage = "Y"; return new CharacterAnswerStruct(A0Y, D0Y); }
                        else { stage = "N"; return new CharacterAnswerStruct(A0N, D0N); }

                    case "Y":
                        freshQuestIdStack.Remove(id);
                        id = -1;
                        if (answer) { return new CharacterAnswerStruct(A0YY, D0YY); }
                        else { return new CharacterAnswerStruct(A0YN, D0YN); }

                    case "N":
                        freshQuestIdStack.Remove(id);
                        id = -1;
                        if (answer) { return new CharacterAnswerStruct(A0NY, D0NY); }
                        else { return new CharacterAnswerStruct(A0NN, D0NN); }

                    default:
                        Debug.LogError("Неправильный stage");
                        return new CharacterAnswerStruct("Ошибка неправильный stage в Answer", ERROR_DIFF_GAME_STATUS);
                }
            default:
                Debug.LogError("Неправильный id");
                return new CharacterAnswerStruct("Ошибка неправильный id в Answer", ERROR_DIFF_GAME_STATUS);
        }
        
    }
}


public class RobotKind : MonoBehaviour { }