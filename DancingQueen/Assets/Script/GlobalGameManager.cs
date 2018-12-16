using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour {

    private static GlobalGameManager instance;
    public static GlobalGameManager Instance
    {
        get { return instance; }
    }

    private int perfectCount;
    public int PerfectCount
    { get { return perfectCount; } set { perfectCount = value; } }
    private int goodCount;
    public int GoodCount
    { get { return goodCount; } set { goodCount = value; } }
    private int okCount;
    public int OkCount
    { get { return okCount; } set { okCount = value; } }
    private int wrongCount;
    public int WrongCount
    { get { return wrongCount; } set { wrongCount = value; } }
    private int comboMax;
    public int ComboMax
    { get { return comboMax; } set { comboMax = value; } }
    private int score;
    public int Score
    { get { return score; } set { score = value; } }
    private int difficulty;
    public int Difficulty
    { get { return difficulty; } set { difficulty = value; } }

    // Use this for initialization
    void Start () {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
