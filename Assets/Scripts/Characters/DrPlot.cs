using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DrPlot : MonoBehaviour
{
    public CharacterQuestion DrPlotQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
