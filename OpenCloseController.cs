using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenCloseController : MonoBehaviour
{
    [SerializeField] private GameObject[] childObjects;
    [SerializeField] private Vector3[] openPositions;
    [SerializeField] private Vector3[] openRotations;
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;

    private Vector3[] closePositions;
    private Vector3[] closeRotations;

    private void Start()
    {
        // Initialize the close positions and rotations based on the current state
        closePositions = new Vector3[childObjects.Length];
        closeRotations = new Vector3[childObjects.Length];

        for (int i = 0; i < childObjects.Length; i++)
        {
            closePositions[i] = childObjects[i].transform.localPosition;
            closeRotations[i] = childObjects[i].transform.localEulerAngles;
        }

        // Setup button listeners
        openButton.onClick.AddListener(() => StartCoroutine(MoveToPositions(openPositions, openRotations, true)));
        closeButton.onClick.AddListener(() => StartCoroutine(MoveToPositions(closePositions, closeRotations, false)));

        // Initially set the close button to not be visible
        closeButton.gameObject.SetActive(false);
    }

    private IEnumerator MoveToPositions(Vector3[] targetPositions, Vector3[] targetRotations, bool opening)
    {
        float time = 0f;
        float duration = 2f; // Duration of the LERP

        // Capture starting positions and rotations
        Vector3[] startPositions = new Vector3[childObjects.Length];
        Vector3[] startRotations = new Vector3[childObjects.Length];

        for (int i = 0; i < childObjects.Length; i++)
        {
            startPositions[i] = childObjects[i].transform.localPosition;
            startRotations[i] = childObjects[i].transform.localEulerAngles;
        }

        while (time < duration)
        {
            time += Time.deltaTime;
            float lerpFactor = time / duration;

            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i].transform.localPosition = Vector3.Lerp(startPositions[i], targetPositions[i], lerpFactor);
                childObjects[i].transform.localEulerAngles = Vector3.Lerp(startRotations[i], targetRotations[i], lerpFactor);
            }

            yield return null;
        }

        // Ensure each object is exactly at the target position and rotation after lerp
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i].transform.localPosition = targetPositions[i];
            childObjects[i].transform.localEulerAngles = targetRotations[i];
        }

        // Toggle the visibility of the buttons after the movement
        openButton.gameObject.SetActive(!opening);
        closeButton.gameObject.SetActive(opening);
    }
}

