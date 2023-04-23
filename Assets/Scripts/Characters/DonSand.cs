using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DonSandCharacter : Character
{
    public DonSandCharacter() : base("Don Sand", "Gold Gloves", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("DonSandCharacter");
    }
}

public class DonSand : MonoBehaviour { }
