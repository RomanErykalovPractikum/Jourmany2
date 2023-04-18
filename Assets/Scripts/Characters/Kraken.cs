using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class KrakenCharacter : Character
{
    public KrakenCharacter() : base("Kraken", "Galaxy") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("KrakenCharacter");
    }
}

public class Kraken : MonoBehaviour { }