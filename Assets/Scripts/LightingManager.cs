using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways] //Execute certain methods in this class while we're not running the game and we're in the unity editor
public class LightingManager : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //variables
    [SerializeField, Range(0,48)] private float TimeOfDay; //Keeps track of time of day. Original was 24. Doubled to 48 to allow more Day


    private void Update()
    {
        if (Preset == null) //Check if we have assigned the preset.
            return;

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 48; //Clamp between 0-24
            UpdateLighting(TimeOfDay / 48f); //Original was 24f, doubled to 48f to allow more Day
        }
        else
        {
            UpdateLighting(TimeOfDay / 48f); //Original was 24f, doubled to 48f to allow more Day
        }

        if (Input.GetKey(KeyCode.Escape)) //Quits Level on ESCAPE press
        {
            Application.Quit();
        }
    }

    private void UpdateLighting(float timePercent) //Change the lighting settings depending on the time of day. Takes an input variables that ranges from 0 to 1. Set the render using the gradients in the presets depending on the time of day.
    {

        RenderSettings.ambientLight = Preset.AmbientColour.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColour.Evaluate(timePercent);

        if (DirectionalLight != null) //Checks if we have assigned our directional light. Change the colour and set the rotation.
        {
            DirectionalLight.color = Preset.DirectionalColour.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170, 0));
        }
    }

    private void OnValidate() //Gets called everytime we reload the script or change something in inspector. Checks that we haven't already set our directional light. If we forget to set that variable, searches for first directional light in the scene
    {
        if (DirectionalLight != null)
            return;
        
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
