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
        if (freshQuestIdStack.Count == 0) return new CharacterQuestion("У этого героя нет квестов");

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
                        return new CharacterQuestion("Люди лучше всех остаьных?");
                    case "Y":
                        return new CharacterQuestion("К вам рришли роботы. Че за фигня? Ты должен быть за нас");
                    case "N":
                        return new CharacterQuestion("К вам рришли люди. Че за фигня?Ты должен быть за нас");
                    default:
                        return new CharacterQuestion("Ошибка неправильный stage");
                }
            default:
                return new CharacterQuestion("Ошибка неправильный id");
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
                            return new CharacterAnswer("Люди рады вашему решению, хотя не все на этой планете человечечкой расы");
                        }
                        else
                        {
                            stage = "N";
                            return new CharacterAnswer("Представители других планет танцуют, даже домашние питомцы не рычат на роботов");
                        }
                    case "Y":
                        if (answer)
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("Роботы довольны");
                        }
                        else
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("Роботы будут бунтовать");
                        }
                    case "N":
                        if (answer)
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("Люди довольны");
                        }
                        else
                        {
                            freshQuestIdStack.Remove(id);
                            id = -1;
                            return new CharacterAnswer("Люди будут бунтовать");
                        }
                    default:
                        return new CharacterAnswer("Ошибка неправильный stage");
                }
            default:
                return new CharacterAnswer("Ошибка неправильный id");
        }
        
    }
}


public class RobotKind : MonoBehaviour { }