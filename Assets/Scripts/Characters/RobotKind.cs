using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static Putin;

public class RobotKindCharacter : Character
{
    public RobotKindCharacter() : base("Alice", "Robots", 1) { }

    public override CharacterQuestion Question()
    {
        if (freshQuestIdStack.Count == 0) return new CharacterQuestion("� ����� ����� ��� �������");

        if (id == -1)
        {
            id = Random.Range(0, freshQuestIdStack.Count);
        };

        switch (id)
        {
            case 0:
                switch (stage)
                {
                    case "":
                        return new CharacterQuestion("���� ����� ���� ��������?");
                    case "Y":
                        return new CharacterQuestion("� ��� ������ ������. �� �� �����? �� ������ ���� �� ���");
                    case "N":
                        return new CharacterQuestion("� ��� ������ ����. �� �� �����?�� ������ ���� �� ���");
                    default:
                        return new CharacterQuestion("������ ������������ stage");
                }
            default:
                return new CharacterQuestion("������ ������������ id");
        }
    }


    public override CharacterAnswer Answer(bool answer)
    {
        switch (id)
        {
            case 0:
                switch (stage)
                {
                    case "":
                        if (answer)
                        {
                            stage = "Y";
                            return new CharacterAnswer("���� ���� ������ �������, ���� �� ��� �� ���� ������� ������������ ����");
                        }
                        else
                        {
                            stage = "N";
                            return new CharacterAnswer("������������� ������ ������ �������, ���� �������� ������� �� ����� �� �������");
                        }
                    case "Y":
                        if (answer)
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("������ ��������");
                        }
                        else
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("������ ����� ���������");
                        }
                    case "N":
                        if (answer)
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("���� ��������");
                        }
                        else
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("���� ����� ���������");
                        }
                    default:
                        return new CharacterAnswer("������ ������������ stage");
                }
            default:
                return new CharacterAnswer("������ ������������ id");
        }
        
    }
}


public class RobotKind : MonoBehaviour { }