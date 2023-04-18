using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static Putin;

public class RobotKindCharacter : Character
{
    public RobotKindCharacter() : base("Alice", "Robots") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("RobotKindCharacter");
    }
}


public class RobotKind : MonoBehaviour { }