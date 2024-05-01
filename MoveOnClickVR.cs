using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClickVR : MonoBehaviour
{
    public GameObject objectToMove; // The object you want to move and scale.
    public Vector3 startPosition; // Starting position.
    public Vector3 startRotation; // Starting rotation.
    public Vector3 startScale; // Starting scale.
    public Vector3 endPosition; // The end position to move to.
    public Vector3 endRotation; // The end rotation to rotate to.
    public Vector3 endScale; // The end scale.
    public float speed = 5f; // How fast the object moves and scales.

    // Set the start position, rotation, and scale when the script starts
    void Start()
    {
        objectToMove.transform.position = startPosition;
        objectToMove.transform.rotation = Quaternion.Euler(startRotation);
        objectToMove.transform.localScale = startScale;
    }

    // This function can be called to move and scale the object to the target.
    public void MoveToTarget()
    {
        StartCoroutine(MoveToTargetCoroutine());
    }

    private IEnumerator MoveToTargetCoroutine()
    {
        Quaternion targetRotation = Quaternion.Euler(endRotation);
        while (Vector3.Distance(objectToMove.transform.position, endPosition) > 0.1f ||
               Quaternion.Angle(objectToMove.transform.rotation, targetRotation) > 0.1f ||
               Vector3.Distance(objectToMove.transform.localScale, endScale) > 0.01f)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, endPosition, speed * Time.deltaTime);
            objectToMove.transform.rotation = Quaternion.RotateTowards(objectToMove.transform.rotation, targetRotation, speed * Time.deltaTime);
            objectToMove.transform.localScale = Vector3.MoveTowards(objectToMove.transform.localScale, endScale, speed * Time.deltaTime);
            yield return null;
        }
    }
}