using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{

    public GUIText ScoreGuiText;
    public GUIText HighScoreGuiText;
    private int score;
    private int highScore;

    private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {
	    Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	    if (highScore < score)
	    {
	        highScore = score;
	    }
	    ScoreGuiText.text = score.ToString();
	    HighScoreGuiText.text = "HighScore : " + highScore.ToString();
	}

    private void Initialize()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    public void AddPoint(int point)
    {
        score = score + point;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        Initialize();
    }
}
