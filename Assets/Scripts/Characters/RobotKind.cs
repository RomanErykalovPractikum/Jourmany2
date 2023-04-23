using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static Putin;

public class RobotKindCharacter : Character
{
    //-------------------------
    string Q0 = "���� ����� ���� ��������?";
        string A0Y = "���� ���� ������ �������, ���� �� ��� �� ���� ������� ������������ ����";
        DiffGameStateStruct D0Y = new DiffGameStateStruct (0, 0, 0, 0, /**/ 1, -1, -1, 1, 1, -1 /**/, 0, 0, 0, /**/ 0, 0, 0);
        string A0N = "������������� ������ ������ �������, ���� �������� ������� �� ����� �� �������";
        DiffGameStateStruct D0N = new DiffGameStateStruct(0, 0, 0, 0, /**/ -1, 1, 1, -1, -1, 1 /**/, 0, 0, 0, /**/ 0, 0, 0);
    string Q1Y = "� ��� ������ ������. �� �� �����? �� ������ ���� �� ���";
        string A0YY = "������ ��������";
        DiffGameStateStruct D0YY = new DiffGameStateStruct(0, 0, 0, 0, /**/ -1, 1, 1, -1, -1, 1 /**/, 0, 0, 0, /**/ 0, 0, 0);
        string A0YN = "������ ����� ���������";
        DiffGameStateStruct D0YN = new DiffGameStateStruct (0, 0, 0, 0, /**/ 1, -1, -1, 1, 1, -1 /**/, 0, 0, 0, /**/ 0, 0, 0);
    string Q1N = "� ��� ������ ����. �� �� �����?�� ������ ���� �� ���";
        string A0NY = "���� ��������";
        DiffGameStateStruct D0NY = new DiffGameStateStruct (0, 0, 0, 0, /**/ 1, -1, -1, 1, 1, -1 /**/, 0, 0, 0, /**/ 0, 0, 0);
        string A0NN = "���� ����� ���������";
        DiffGameStateStruct D0NN = new DiffGameStateStruct(0, 0, 0, 0, /**/ -1, 1, 1, -1, -1, 1 /**/, 0, 0, 0, /**/ 0, 0, 0);
    //------------------------

    public RobotKindCharacter() : base("Alice", "Robots", 1) { }

    public override CharacterQuestionStruct Question()
    {
        if (freshQuestIdStack.Count == 0) return new CharacterQuestionStruct("� ����� ����� ��� �������");

        if (id == -1) //���� ������� �� ���������
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
                        Debug.LogError("������������ stage");
                        return new CharacterQuestionStruct("������ ������������ stage � Question");
                }
            default:
                Debug.LogError("������������ id");
                return new CharacterQuestionStruct("������ ������������ id � Question");
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
                        Debug.LogError("������������ stage");
                        return new CharacterAnswerStruct("������ ������������ stage � Answer", ERROR_DIFF_GAME_STATUS);
                }
            default:
                Debug.LogError("������������ id");
                return new CharacterAnswerStruct("������ ������������ id � Answer", ERROR_DIFF_GAME_STATUS);
        }
        
    }
}


public class RobotKind : MonoBehaviour { }