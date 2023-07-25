using UnityEngine;

public class ScoreBank : MonoBehaviour
{
    private int score;

    public int GetScore()
    {
        return score;
    }

    public void AddScoreForMergedCube(int points)
    {
        score += points;
        
        OnScoreChanged?.Invoke(score);
    }

   
    public delegate void ScoreChangedHandler(int newScore);
    public event ScoreChangedHandler OnScoreChanged;
}
