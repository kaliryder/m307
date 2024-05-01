using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Light lightSource;
    public bool startChanging = false; // Control variable to start changing colors
    float hue = 0.0f;

    void Start()
    {
        lightSource = GetComponent<Light>();
        lightSource.enabled = false;  // Ensure the light is off when the game starts
    }

    void Update()
    {
        if (startChanging)
        {
            hue += Time.deltaTime * 0.1f; // Adjust the speed of color change here
            if (hue > 1) hue = 0.0f; // Reset hue to loop the colors
            lightSource.color = Color.HSVToRGB(hue, 1, 1);
        }
    }

    // Call this function to start the light show
    public void StartLightShow()
    {
        lightSource.enabled = true; // Turn on the light
        startChanging = true;
    }
}

