using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ReturnToMainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(0); // Load main menu
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            // Make cursor visible and unlocked
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Find the Exit Button in the scene
            GameObject exitButton = GameObject.Find("ExitButton"); // Use the name of your button
            if (exitButton != null && EventSystem.current != null)
            {
                // Set focus to the exit button
                EventSystem.current.SetSelectedGameObject(exitButton);
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}