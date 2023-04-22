using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class MrLeeCharacter : Character
{
    public MrLeeCharacter() : base("Mr Lee", "Trade Union", 3) { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("MrLeeCharacter");
    }
}

public class MrLee : MonoBehaviour { }