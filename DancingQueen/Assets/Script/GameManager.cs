﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private float score = 0;
    public float Score
    {
        get { return score; }
        set { score = value; }
    }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider scoreSlider;

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

    private int comboMultiplicator = 1;
    private float comboCount = 0;
    [SerializeField] private GameObject comboText;

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

    public bool end = false;

    [SerializeField] private CinemachineVirtualCamera cinemachine;
    private CinemachineBasicMultiChannelPerlin noise;
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
	    noise = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = musicVolume;
        if (end)
        { End();}
    }

    public void AddScore(float point)
    {
        if (point == 1) { okCount++; }
        if (point == 2) { goodCount++; }
        if (point == 3) { perfectCount++; }

        score += point*comboMultiplicator;
        scoreText.text = "Score : " + score;
        scoreSlider.value = score;
    }

    public void Fail()
    {
        wrongCount++;
        dancer.GetComponentInChildren<SpriteRenderer>().sprite = fallingSprite;
        audioSource.Play();
        GetComponent<Animator>().SetTrigger("Scratch");
        ComboCount(false);
    }

    public void ComboCount(bool perfect)
    {
        if (perfect)
        {
            comboCount++;
        }
        else
        {
            comboCount = 1;
        }
        comboMultiplicator = (int)comboCount / 10 + 1;
        if (comboMultiplicator>1)
        {
            comboText.SetActive(true);

            comboText.GetComponent<TextMeshProUGUI>().text = "Combo x " + comboMultiplicator;
            if (comboMultiplicator > comboMax)
                comboMax = comboMultiplicator;
        }
        else
        {
            comboText.SetActive(false);
        }
    }

    public void End()
    {
        
        GlobalGameManager.Instance.Score = (int)score;
        GlobalGameManager.Instance.PerfectCount = perfectCount;
        GlobalGameManager.Instance.GoodCount = goodCount;
        GlobalGameManager.Instance.OkCount = okCount;
        GlobalGameManager.Instance.WrongCount = wrongCount;
        GlobalGameManager.Instance.ComboMax = comboMax;
        SceneManager.LoadScene("EndScene");
    }

    
}
