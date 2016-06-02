using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    GameObject PauzeUI;

    [SerializeField]
    bool PauzeEnabled = false;
    // Use this for initialization
    void Start ()
    {
        PauzeUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInputs();
	}

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PauzeEnabled)
            {
                PauzeScreenEnabled();
            }
            else if(PauzeEnabled)
            {
                PauzeScreenDisabled();
            }
            
        }
        
    }
    public void PauzeScreenEnabled()
    {
        PauzeEnabled = true;
        PauzeUI.SetActive(true);
        Time.timeScale = 0;   
    }

    public void PauzeScreenDisabled()
    {
        PauzeUI.SetActive(false);
        Time.timeScale = 1;
        PauzeEnabled = false;
    }

    public void MainMenu(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
