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

    // Use this for initialization
    void Start ()
    {
        currentCanvas = titleCanvas;
        selectCanvas.SetActive(false);
        menuCanvas.SetActive(false);
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
        SceneManager.LoadScene("SampleScene");
    }
    public void HardButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExtremButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
