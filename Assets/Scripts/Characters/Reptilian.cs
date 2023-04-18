using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class ReptilianCharacter : Character
{
    public ReptilianCharacter() : base("Zakhrsh", "Galaxy") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("ReptilianCharacter");
    }
}

public class Reptilian : MonoBehaviour { }