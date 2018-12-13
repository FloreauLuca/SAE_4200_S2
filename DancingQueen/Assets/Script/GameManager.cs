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
    

    private Dictionary<string, int> arrowPriority = new Dictionary<string, int>();
    public Dictionary<string, int> ArrowPriority
    {
        get { return arrowPriority; }
        set { arrowPriority = value; }
    }

    private Dictionary<string, bool> arrowPush = new Dictionary<string, bool>();
    public Dictionary<string, bool> ArrowPush
    {
        get { return arrowPush; }
        set { arrowPush = value; }
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
        arrowPriority.Add("Left", 0);
	    arrowPriority.Add("Up", 0);
	    arrowPriority.Add("Down", 0);
	    arrowPriority.Add("Right", 0);

	    arrowPush.Add("Left", false);
	    arrowPush.Add("Up", false);
	    arrowPush.Add("Down", false);
	    arrowPush.Add("Right", false);
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update () {
        
	    if (Input.GetButtonDown("Left"))
	    {
	        score += arrowPriority["Left"];
	        if (arrowPriority["Left"] != 0)
	        {
	            arrowPush["Left"] = true;
	            arrowPriority["Left"] = 0;
	        }
            scoreText.text = "Score : " + score;
	    }
	    if (Input.GetButtonDown("Up"))
	    {
	        score += arrowPriority["Up"];
	        if (arrowPriority["Up"] != 0)
	        {
	            arrowPush["Up"] = true;
	            arrowPriority["Up"] = 0;
	        }
            scoreText.text = "Score : " + score;
	    }
        if (Input.GetButtonDown("Down"))
        {
            score += arrowPriority["Down"];
            if (arrowPriority["Down"] != 0)
            {
                arrowPush["Down"] = true;
                arrowPriority["Down"] = 0;
            }
            scoreText.text = "Score : " + score;
        }
        if (Input.GetButtonDown("Right"))
        {
            score += arrowPriority["Right"];
            if (arrowPriority["Right"] != 0)
            {
                arrowPush["Right"] = true;
                arrowPriority["Right"] = 0;
            }
            scoreText.text = "Score : " + score;
        }
    }
}
