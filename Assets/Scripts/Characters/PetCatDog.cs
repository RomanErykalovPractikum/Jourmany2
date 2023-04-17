using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class PetCatDog : MonoBehaviour
{
    public CharacterQuestion PetCatDogQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
