using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class Kraken : MonoBehaviour
{
    public CharacterQuestion KrakenQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
