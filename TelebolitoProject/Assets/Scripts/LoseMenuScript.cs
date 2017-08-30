using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenuScript : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text maxScoreText;
    //private static Text scoreT;
    //private static Text maxScoreT;
    private int actualScore;

    public int ActualScore
    {
        get
        {
            return actualScore;
        }

        set
        {
            actualScore = value;
        }
    }

    // Use this for initialization
    void Start () {
	
        if(actualScore > SettingsManager.MaxScore)
        {
            SettingsManager.MaxScore = actualScore;
        }
        scoreText.text = actualScore.ToString();
        maxScoreText.text = SettingsManager.MaxScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onHomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void onShareButtonClick()
    {

    }
}
