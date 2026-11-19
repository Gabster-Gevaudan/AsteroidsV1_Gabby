using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text ScoreTextBox, HiScoreTextBox;
    public GameObject ScorePanel, Celebrate;
    private MoveShip ship;

    private void Start()
    {
        ship = FindFirstObjectByType<MoveShip>();
        gameObject.SetActive (false);
    }

    public void Show(bool celebrateHiScore)
    {
        ScoreTextBox.text = ship._score.ToString();
        HiScoreTextBox.text = ship.GetHighScore().ToString();

        ScorePanel.SetActive (true);
        Celebrate.SetActive(celebrateHiScore);
    }

    public void Hide()
    {
        ScorePanel.SetActive(false);
    }

    public void Reveal()
    {
        gameObject.SetActive(true);
    }

    public void ClickPlayAgain()
    {
        SceneManager.LoadScene("SpaceRace");
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
