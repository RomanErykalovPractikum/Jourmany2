using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;


public class RobotWarCharacter : Character
{
    public RobotWarCharacter() : base("Z14", "Robots") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("RobotWarCharacter");
    }
}

public class RobotWar : MonoBehaviour { }

