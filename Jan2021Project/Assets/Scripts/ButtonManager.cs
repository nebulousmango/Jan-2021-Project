using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public string S_LevelOne;
    public string S_LevelTwo;

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(S_LevelOne);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(S_LevelTwo);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}