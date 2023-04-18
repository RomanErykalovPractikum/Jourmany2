using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class MrHubrisCharacter : Character
{
    public MrHubrisCharacter() : base("Mr Hubris", "Trade Union") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("MrHubrisCharacter");
    }
}

public class MrHubris : MonoBehaviour { }