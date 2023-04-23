using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class MrHubrisCharacter : Character
{
    public MrHubrisCharacter() : base("Mr Hubris", "Trade Union", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("MrHubrisCharacter");
    }
}

public class MrHubris : MonoBehaviour { }