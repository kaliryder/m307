using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GOLayout
{
    public GameObject gameObject;
    public Vector3 layout1Position;
    public Vector3 layout1EulerAngles; // Store Euler angles instead of Quaternion
    public Vector3 layout2Position;
    public Vector3 layout2EulerAngles;
    public Vector3 layout3Position;
    public Vector3 layout3EulerAngles;

    // Properties to get the Quaternion from Euler angles
    public Quaternion Layout1Rotation => Quaternion.Euler(layout1EulerAngles);
    public Quaternion Layout2Rotation => Quaternion.Euler(layout2EulerAngles);
    public Quaternion Layout3Rotation => Quaternion.Euler(layout3EulerAngles);
}
