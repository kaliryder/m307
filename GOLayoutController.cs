using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GOLayoutController : MonoBehaviour
{
    [SerializeField] private List<GOLayout> gameObjectLayouts;
    [SerializeField] private Button layout1Button, layout2Button, layout3Button;
    private int currentLayout = 1;

    void Start()
    {
        layout1Button.onClick.AddListener(() => StartLerp(1));
        layout2Button.onClick.AddListener(() => StartLerp(2));
        layout3Button.onClick.AddListener(() => StartLerp(3));

        SetLayout(1);
    }

    public void SetLayout(int layoutNumber)
    {
        foreach (var layout in gameObjectLayouts)
        {
            switch (layoutNumber)
            {
                case 1:
                    layout.gameObject.transform.position = layout.layout1Position;
                    layout.gameObject.transform.rotation = Quaternion.Euler(layout.layout1EulerAngles);
                    break;
                case 2:
                    layout.gameObject.transform.position = layout.layout2Position;
                    layout.gameObject.transform.rotation = Quaternion.Euler(layout.layout2EulerAngles);
                    break;
                case 3:
                    layout.gameObject.transform.position = layout.layout3Position;
                    layout.gameObject.transform.rotation = Quaternion.Euler(layout.layout3EulerAngles);
                    break;
            }
        }
    }

    void StartLerp(int targetLayout)
    {
        if (currentLayout != targetLayout)
        {
            StartCoroutine(LerpLayout(currentLayout, targetLayout));
            currentLayout = targetLayout;
        }
    }

    IEnumerator LerpLayout(int fromLayout, int toLayout)
    {
        float time = 0;
        float duration = 2f; // Duration of the LERP
        while (time < duration)
        {
            time += Time.deltaTime;
            float lerpFactor = time / duration;
            foreach (var layout in gameObjectLayouts)
            {
                Vector3 fromPosition, toPosition;
                Quaternion fromRotation, toRotation;

                // Determine the start and end positions/rotations based on the layout numbers
                switch (fromLayout)
                {
                    case 1:
                        fromPosition = layout.layout1Position;
                        fromRotation = Quaternion.Euler(layout.layout1EulerAngles);
                        break;
                    case 2:
                        fromPosition = layout.layout2Position;
                        fromRotation = Quaternion.Euler(layout.layout2EulerAngles);
                        break;
                    default: // Assuming case 3 if none of the above
                        fromPosition = layout.layout3Position;
                        fromRotation = Quaternion.Euler(layout.layout3EulerAngles);
                        break;
                }

                switch (toLayout)
                {
                    case 1:
                        toPosition = layout.layout1Position;
                        toRotation = Quaternion.Euler(layout.layout1EulerAngles);
                        break;
                    case 2:
                        toPosition = layout.layout2Position;
                        toRotation = Quaternion.Euler(layout.layout2EulerAngles);
                        break;
                    default: // Assuming case 3 if none of the above
                        toPosition = layout.layout3Position;
                        toRotation = Quaternion.Euler(layout.layout3EulerAngles);
                        break;
                }

                // Perform the interpolation
                Vector3 newPosition = Vector3.Lerp(fromPosition, toPosition, lerpFactor);
                Quaternion newRotation = Quaternion.Lerp(fromRotation, toRotation, lerpFactor);

                // Set the GameObject's new position and rotation
                layout.gameObject.transform.position = newPosition;
                layout.gameObject.transform.rotation = newRotation;

                // Output the debug logs
                Debug.Log($"from: {fromLayout} to: {toLayout} [LerpLayout] {layout.gameObject.name} is moving from {fromPosition} to {toPosition}, current interpolated position: {newPosition}");
                Debug.Log($"from: {fromLayout} to: {toLayout} [LerpLayout] {layout.gameObject.name} is rotating from {fromRotation.eulerAngles} to {toRotation.eulerAngles}, current interpolated rotation: {newRotation.eulerAngles}");
            }
            yield return null;
        }
        SetLayout(toLayout); // Snap to the exact final position and rotation
    }
}

