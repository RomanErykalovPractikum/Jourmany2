using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class PetDogCharacter : Character
{
    public PetDogCharacter() : base("Joy", "Pets", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("PetDogCharacter");
    }
}

public class PetDog : MonoBehaviour { }
