using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();

    }
}
