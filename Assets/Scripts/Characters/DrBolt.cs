using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DrBoltCharacter : Character
{
    public DrBoltCharacter() : base("Asst. Bolty", "Scientist", 3) { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("DrBoltCharacter");
    }
}

public class DrBolt : MonoBehaviour { }