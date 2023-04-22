using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class MrsRightCharacter : Character
{
    public MrsRightCharacter() : base("Anna", "Trade Union", 3) { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("MrsRightCharacter");
    }
}

public class MrsRight : MonoBehaviour { }