using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGalleryController : MonoBehaviour
{
    [SerializeField] private Sprite[] images; // The array of images to be displayed.
    [SerializeField] private Image displayImage; // The UI Image component where the images will be displayed.
    [SerializeField] private Button backButton; // The 'back' button to go to the previous image.
    [SerializeField] private Button nextButton; // The 'next' button to go to the next image.

    private int currentIndex = 0; // The index of the currently displayed image.

    private void Start()
    {
        // Initialize the gallery display with the first image, if available.
        if (images.Length > 0)
        {
            displayImage.sprite = images[currentIndex];
        }
        
        // Ensure the buttons are only interactable when appropriate.
        UpdateButtonInteractability();

        // Add the listeners for the button clicks.
        backButton.onClick.AddListener(GoToPreviousImage);
        nextButton.onClick.AddListener(GoToNextImage);
    }

    private void GoToNextImage()
    {
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
            displayImage.sprite = images[currentIndex];
            UpdateButtonInteractability();
        }
    }

    private void GoToPreviousImage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            displayImage.sprite = images[currentIndex];
            UpdateButtonInteractability();
        }
    }

    private void UpdateButtonInteractability()
    {
        // The back button is interactable when the current index is greater than 0.
        backButton.interactable = currentIndex > 0;

        // The next button is interactable when the current index is less than the last index.
        nextButton.interactable = currentIndex < images.Length - 1;
    }
}

