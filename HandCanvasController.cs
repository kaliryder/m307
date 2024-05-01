using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandCanvasController : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private Image displayImage;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject xrRig;

    [SerializeField] private Sprite[] introImages;
    [SerializeField] private Image introDisplayImage;

    private int introCurrentIndex = 0;

    // Positions
    [SerializeField] private Vector3 introPos;
    [SerializeField] private Vector3 introRotation;
    [SerializeField] private Vector3 prepPos;
    [SerializeField] private Vector3 prepRotation;
    [SerializeField] private Vector3 lmPos;
    [SerializeField] private Vector3 lmRotation;
    [SerializeField] private Vector3 umPos;
    [SerializeField] private Vector3 umRotation;
    [SerializeField] private Vector3 seniorPos;
    [SerializeField] private Vector3 seniorRotation;
    [SerializeField] private Vector3 creditsPos;
    [SerializeField] private Vector3 creditsRotation;

    // Frame indices
    [SerializeField] private int introFrame;
    [SerializeField] private int prepFrame;
    [SerializeField] private int lmFrame;
    [SerializeField] private int umFrame;
    [SerializeField] private int seniorFrame;
    [SerializeField] private int creditsFrame;

    private int currentIndex = 0;

    private void Start()
    {
        xrRig.transform.position = introPos;
        xrRig.transform.rotation = Quaternion.Euler(introRotation);
        displayImage.sprite = images[currentIndex];
        introDisplayImage.sprite = introImages[introCurrentIndex];
        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnNextButtonClick()
    {
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
        }
        else
        {
            currentIndex = 0; // Optionally wrap back to first image.
        }

        if (introCurrentIndex < introImages.Length - 1)
        {
            introCurrentIndex++;
        }
        else
        {
            introCurrentIndex = 0; // Optionally wrap back to first image.
        }

        displayImage.sprite = images[currentIndex];
        introDisplayImage.sprite = introImages[introCurrentIndex];

        // Check if the currentIndex matches any frame index and move the GameObject.
        MoveObjectToPosition(currentIndex);
    }

    private void MoveObjectToPosition(int index)
    {
        if (index == introFrame) {
            xrRig.transform.position = introPos;
            xrRig.transform.rotation = Quaternion.Euler(introRotation);
        }
        else if (index == prepFrame) {
            xrRig.transform.position = prepPos;
            xrRig.transform.rotation = Quaternion.Euler(prepRotation);
        }
        else if (index == lmFrame) {
            xrRig.transform.position = lmPos;
            xrRig.transform.rotation = Quaternion.Euler(lmRotation);
        }
        else if (index == umFrame) {
            xrRig.transform.position = umPos;
            xrRig.transform.rotation = Quaternion.Euler(umRotation);
        }
        else if (index == seniorFrame) {
            xrRig.transform.position = seniorPos;
            xrRig.transform.rotation = Quaternion.Euler(seniorRotation);
        }
        else if (index == creditsFrame) {
            xrRig.transform.position = creditsPos;
            xrRig.transform.rotation = Quaternion.Euler(creditsRotation);
        }
    }
}