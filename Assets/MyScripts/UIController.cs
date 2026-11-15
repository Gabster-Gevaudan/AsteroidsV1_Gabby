using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private TMP_Text _scoreText;

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreText.text = "Score: " + _score;
    }
}