using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class SlimeCharacter : Character
{
    public SlimeCharacter() : base("Slime", "Galaxy", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("SlimeCharacter");
    }
}

public class Slime : MonoBehaviour { }
