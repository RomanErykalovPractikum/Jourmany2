using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class MrLee : MonoBehaviour
{
    public CharacterQuestion MrLeeQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
