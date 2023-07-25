using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreBank scoreBank;
    

    void Start()
    {
      scoreBank = GetComponent<ScoreBank>();
        scoreBank.OnScoreChanged += UpdateScoreText;
    }

  
    public void UpdateScoreText(int score)
    {
        score = scoreBank.GetScore();
        scoreText.text = score.ToString();
      
    }
}
