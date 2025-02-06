using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!\n");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
