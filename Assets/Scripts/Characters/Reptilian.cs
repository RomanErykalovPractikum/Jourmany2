using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class Reptilian : MonoBehaviour
{
    public CharacterQuestion ReptilianQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
