using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class PetCat : MonoBehaviour
{
    public CharacterQuestion PetCatQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
