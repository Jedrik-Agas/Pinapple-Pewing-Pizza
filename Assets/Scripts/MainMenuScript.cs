using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] LevelLoaderScript levelLoaderScript;

    public void StartGame()
    {
        levelLoaderScript.Nextevel();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
