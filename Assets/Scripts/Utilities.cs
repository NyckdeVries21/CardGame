using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{
    public void GoToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void GoToInfo()
    {
        SceneManager.LoadScene("InfoScene");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToEnd()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    
}
