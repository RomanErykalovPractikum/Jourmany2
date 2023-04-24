using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class KrakenCharacter : Character
{
    public KrakenCharacter() : base("Kraken", "Galaxy", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("KrakenCharacter");
    }
}

public class Kraken : MonoBehaviour { }