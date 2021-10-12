using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text score;
    public Text gameoverScore;

    private int currentScore;

    private void Start()
    {
        currentScore = 0;
    }

    private void Update()
    {
        score.text = $"Score : { currentScore.ToString("0") }";
    }

    public void IncreaseCurrentScore(int num)
    {
        currentScore += num;
    }

    public void EndScore()
    {
        gameoverScore.text = $"Score : { currentScore.ToString("0") }";
    }
}
