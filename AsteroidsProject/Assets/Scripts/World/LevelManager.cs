using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    GameObject PauzeUI;

    [SerializeField]
    bool PauzeEnabled = false;


    [SerializeField]
    Text WaveText;
    public Text ScoreText;
    [SerializeField]
    Text ZombiesLeft;
        

    WaveManager _wavemanager;

    // Use this for initialization
    void Start ()
    {
        PauzeUI.SetActive(false);

        _wavemanager = GetComponent<WaveManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInputs();
        ScreenUpdate();

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

    void ScreenUpdate()
    {


        ZombiesLeft.text = "Enemies: " + _wavemanager.CurrentEnemies.ToString(); // naar UI, zodat je het in game kan zien.
        WaveText.text = "Wave: " + _wavemanager.waveCounter.ToString();

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
