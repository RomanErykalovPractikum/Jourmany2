using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DonSnitchCharacter : Character
{
    public DonSnitchCharacter() : base("Don Snitch", "Gold Gloves") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("DonSnitchCharacter");
    }
}

public class DonSnitch : MonoBehaviour { }