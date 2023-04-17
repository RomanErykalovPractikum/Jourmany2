using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DrPiff : MonoBehaviour
{
    public CharacterQuestion DrPiffQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
