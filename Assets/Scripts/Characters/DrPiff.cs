using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DrPiffCharacter : Character
{
    public DrPiffCharacter() : base("Dr Piff", "Scientists", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("DrPiffCharacter");
    }
}

public class DrPiff : MonoBehaviour { }
