using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class MrHubris : MonoBehaviour
{
    public CharacterQuestion MrHubrisQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
