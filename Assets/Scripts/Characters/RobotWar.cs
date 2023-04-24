using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;


public class RobotWarCharacter : Character
{
    public RobotWarCharacter() : base("Z14", "Robots", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("RobotWarCharacter");
    }
}

public class RobotWar : MonoBehaviour { }

