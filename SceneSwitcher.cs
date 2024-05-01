using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Button goButton; // Assign this in the inspector
    public string sceneNameToLoad = "m307"; // Change the scene name to the one you want to load

    void Start()
    {
        if (goButton != null)
        {
            goButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("Button not assigned in the inspector.");
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}

