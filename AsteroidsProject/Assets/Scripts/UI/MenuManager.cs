using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    GameObject MainMenuPanel;
    [SerializeField]
    GameObject OptionsPanel;
    [SerializeField]
    GameObject CreditsPanel;

    void Start()
    {
        
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OptionsShow(bool value)
    {
        if(value)
        {
            MainMenuPanel.SetActive(false);
            OptionsPanel.SetActive(true);
        } 
        if(!value)
        {
            MainMenuPanel.SetActive(true);
            OptionsPanel.SetActive(false);
        }      

    }

    public void ChangeGraphics(int value)
    {
        if(value == 1)
        {
            QualitySettings.currentLevel = QualityLevel.Fastest;
        }
        if(value == 2)
        {
            QualitySettings.currentLevel = QualityLevel.Fast;
        }

        if(value == 3)
        {
            QualitySettings.currentLevel = QualityLevel.Simple;
        }
        if(value == 4)
        {
            QualitySettings.currentLevel = QualityLevel.Good;
        }
        if(value == 5)
        {
            QualitySettings.currentLevel = QualityLevel.Beautiful;
        }
        if(value == 6)
        {
            QualitySettings.currentLevel = QualityLevel.Fantastic;
        }
    }

    public void CreditsShow(bool value)
    {
        if(value)
        {
            MainMenuPanel.SetActive(false);
            CreditsPanel.SetActive(true);
        }
        if(!value)
        {
            MainMenuPanel.SetActive(true);
            CreditsPanel.SetActive(false);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
