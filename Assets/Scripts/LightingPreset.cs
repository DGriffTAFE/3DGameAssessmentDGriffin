using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="Lighting Preset", menuName ="Scriptables/Lighting Preset", order =1)] //Create an instance of the class as a file in the unity editor when we right click
public class LightingPreset : ScriptableObject //ScriptableObject is a data container that you can use to save large amounts of data, independent of class instances. Share one specific preset between scenes by creating a file.
{
    // Allows to change the colour in the inspector easily.
    public Gradient AmbientColour;
    public Gradient DirectionalColour;
    public Gradient FogColour;

}
