using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class PetDog : MonoBehaviour
{
    public CharacterQuestion PetDogQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
