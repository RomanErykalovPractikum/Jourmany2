using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class SlimeCharacter : Character
{
    public SlimeCharacter() : base("Slime", "Galaxy") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("SlimeCharacter");
    }
}

public class Slime : MonoBehaviour { }
