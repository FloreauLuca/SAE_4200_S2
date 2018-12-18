using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private GameObject currentCanvas;
    [SerializeField] private GameObject optionCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject selectCanvas;
    [SerializeField] private GameObject titleCanvas;
    [SerializeField] private GameObject instructionCanvas;
    // Use this for initialization
    void Start ()
    {
        currentCanvas = titleCanvas;
        selectCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        instructionCanvas.SetActive(false);
        //optionCanvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OptionButton()
    {
        currentCanvas.SetActive(false);
        currentCanvas = optionCanvas;
        currentCanvas.SetActive(true);
    }

    public void PlayButton()
    {
        currentCanvas.SetActive(false);
        currentCanvas = instructionCanvas;
        currentCanvas.SetActive(true);
    }

    public void InstructionButton()
    {
        currentCanvas.SetActive(false);
        currentCanvas = selectCanvas;
        currentCanvas.SetActive(true);
    }

    public void MenuButton()
    {
        currentCanvas.SetActive(false);
        currentCanvas = menuCanvas;
        currentCanvas.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void EasyButton()
    {
        SceneManager.LoadScene("EasyScene");
        GlobalGameManager.Instance.Difficulty = 1;
    }
    public void HardButton()
    {
        SceneManager.LoadScene("SampleScene");
        GlobalGameManager.Instance.Difficulty = 2;
    }
    public void ExtremButton()
    {
        SceneManager.LoadScene("ExtremeScene");
        GlobalGameManager.Instance.Difficulty = 3;
    }

}
