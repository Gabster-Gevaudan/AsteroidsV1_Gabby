using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{
    public void ClickPlay()
    {
        SceneManager.LoadScene("SpaceRace");
    }
    public void ClickQuit()
    {
        Application.Quit();
    }
}