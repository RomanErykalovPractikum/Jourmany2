using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class PetCatDogCharacter : Character
{
    public PetCatDogCharacter() : base("Lucy and Buddy", "Pets", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("PetCatDogCharacter");
    }
}

public class PetCatDog : MonoBehaviour { }