using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class RobotSloppyCharacter : Character
{
    public RobotSloppyCharacter() : base("Intercom", "Robots", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("RobotSloppyCharacter");
    }
}

public class RobotSloppy : MonoBehaviour { }
