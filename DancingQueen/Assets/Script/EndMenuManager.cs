using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour {
    private static GlobalGameManager instance;
    public static GlobalGameManager Instance
    {
        get { return instance; }
    }

    private int perfectCount;
    private int goodCount;
    private int okCount;
    private int wrongCount;
    private int comboMax;
    private int score;
    [SerializeField] private TextMeshProUGUI perfectText;
    [SerializeField] private TextMeshProUGUI goodText;
    [SerializeField] private TextMeshProUGUI okText;
    [SerializeField] private TextMeshProUGUI wrongText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Use this for initialization
    void Start ()
    {
        perfectCount = GlobalGameManager.Instance.PerfectCount;
        goodCount = GlobalGameManager.Instance.GoodCount;
        okCount = GlobalGameManager.Instance.OkCount;
        wrongCount = GlobalGameManager.Instance.WrongCount;
        comboMax = GlobalGameManager.Instance.ComboMax;
        score = GlobalGameManager.Instance.Score;

        perfectText.text = "Perfect : " + perfectCount;
        goodText.text = "Good : " + goodCount;
        okText.text = "Ok : " + okCount;
        wrongText.text = "Wrong : " + wrongCount;
        comboText.text = "Combo Max : x" + comboMax;
        scoreText.text = "Score : " + score;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartButton()
    {
        if (GlobalGameManager.Instance.Difficulty == 1)
        {
            SceneManager.LoadScene("EasyScene");
        }
        if (GlobalGameManager.Instance.Difficulty == 2)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (GlobalGameManager.Instance.Difficulty == 3)
        {
            SceneManager.LoadScene("ExtremeScene");
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
