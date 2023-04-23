using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DrPlotCharacter : Character
{
    public DrPlotCharacter() : base("Dr Plot", "Scientist", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("DrPlotCharacter");
    }
}

public class DrPlot : MonoBehaviour { }
