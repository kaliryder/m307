using UnityEngine;

public class LightsOffController : MonoBehaviour
{
    public Light directionalLight;
    public Light[] pointLights;
    public Light spotlight;
    public GameObject canvas;

    void Start()
    {
        // Ensure the spotlight and canvas are disabled at start
        if (spotlight != null)
            spotlight.enabled = false;

        if (canvas != null)
            canvas.SetActive(false);
    }

    // Call this function to change the lighting and canvas visibility
    public void ActivateSpotlight()
    {
        // Turn off the directional light
        if (directionalLight != null)
            directionalLight.enabled = false;

        // Turn off all point lights
        foreach (Light light in pointLights)
        {
            if (light != null)
                light.enabled = false;
        }

        // Turn on the spotlight
        if (spotlight != null)
            spotlight.enabled = true;

        // Enable the canvas
        if (canvas != null)
            canvas.SetActive(true);
    }
}
