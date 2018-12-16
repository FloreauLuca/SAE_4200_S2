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

    [SerializeField] private GameObject dancer;
    public GameObject Dancer
    {
        get { return dancer; }
        set { dancer = value; }
    }

    [SerializeField] private Sprite fallingSprite;

    [SerializeField] private AudioClip vinyle;
    private AudioSource audioSource;
    [SerializeField] private AudioSource music;

    [SerializeField] private float musicVolume;

    private FMOD.Studio.EventInstance musicFmod;
    private FMOD.Studio.ParameterInstance musicVelo;
    [SerializeField] private string musicEvent;




    // Use this for initialization
    void Start ()
	{
	    instance = this;
	    audioSource = GetComponent<AudioSource>();
	    arrowGameObject.Add("Left", new List<GameObject>());
	    arrowGameObject.Add("Up", new List<GameObject>());
	    arrowGameObject.Add("Down", new List<GameObject>());
	    arrowGameObject.Add("Right", new List<GameObject>());
        scoreText.text = "Score : " + score;
	    musicFmod = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        musicFmod.getParameter("Parameter 1", out musicVelo);
	    musicFmod.start();
	}

    // Update is called once per frame
    void Update()
    {
        //music.volume = musicVolume;
        musicVelo.setValue(score/500f);
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score : " + score;
    }

    public void Fail()
    {
        dancer.GetComponentInChildren<SpriteRenderer>().sprite = fallingSprite;
        audioSource.Play();
        GetComponent<Animator>().SetTrigger("Scratch");
    }
    
}
