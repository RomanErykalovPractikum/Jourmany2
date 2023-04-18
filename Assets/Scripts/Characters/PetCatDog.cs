using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class PetCatDogCharacter : Character
{
    public PetCatDogCharacter() : base("Lucy and Buddy", "Pets") { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("PetCatDogCharacter");
    }
}

public class PetCatDog : MonoBehaviour { }