using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public Text text;
    [ContextMenu("+Score")]

    public void Start()
    {
        text = GetComponent<Text>();
    }
    public void AddScore(int AddToScore)
    {
        Score = Score + AddToScore;
        text.text = Score.ToString();
    }
}
