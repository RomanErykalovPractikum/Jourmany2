using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DonSandCharacter : Character
{
    public DonSandCharacter() : base("Don Sand", "Gold Gloves", 3) { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("DonSandCharacter");
    }
}

public class DonSand : MonoBehaviour { }
