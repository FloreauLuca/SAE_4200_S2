using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    private Dictionary<string, List<GameObject>> arrowGameObject = new Dictionary<string, List<GameObject>>();
    public Dictionary<string, List<GameObject>> ArrowGameObject
    {
        get { return arrowGameObject; }
        set { arrowGameObject = value; }
    }

    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    [SerializeField] private TextMeshProUGUI scoreText;
    // Use this for initialization
    void Start ()
	{
	    instance = this;

	    arrowGameObject.Add("Left", new List<GameObject>());
	    arrowGameObject.Add("Up", new List<GameObject>());
	    arrowGameObject.Add("Down", new List<GameObject>());
	    arrowGameObject.Add("Right", new List<GameObject>());
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score : " + score;
    }


}
