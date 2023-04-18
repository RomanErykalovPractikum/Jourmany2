using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class PetCatCharacter : Character
{
    public PetCatCharacter() : base("Freckle", "Pets") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("PetCatCharacter");
    }
}

public class PetCat : MonoBehaviour { }