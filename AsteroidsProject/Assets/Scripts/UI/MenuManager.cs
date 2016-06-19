using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    // in Lobby
    [SerializeField]
    GameObject LobbyPanel;
    [SerializeField]
    GameObject Infopanel;
    [SerializeField]
    GameObject OptionsPanel;
    [SerializeField]
    GameObject CreditsPanel;

    bool EnableLobby;

    void Start()
    {
       
            LobbyPanel.SetActive(true);
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
            Infopanel.SetActive(false);
        
 
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
            Infopanel.SetActive(false);
            LobbyPanel.SetActive(false);
        

    }
    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OptionsShow(bool value)
    {
        if(value)
        {
            LobbyPanel.SetActive(false);
            OptionsPanel.SetActive(true);
        } 
        if(!value)
        {
            LobbyPanel.SetActive(true);
            OptionsPanel.SetActive(false);
        }      

    }
    /*
    public void ToggleScreen(bool value)
    {
        if(value)
        {
            Screen.fullScreen = Screen.fullScreen;
        }
        else
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
    */

    public void CreditsShow(bool value)
    {
        if(value)
        {
            LobbyPanel.SetActive(false);
            Infopanel.SetActive(false);
            CreditsPanel.SetActive(true);
        }
        if(!value)
        {
            LobbyPanel.SetActive(true);
            CreditsPanel.SetActive(false);
        }
    }

    public void ShowLobby()
    {
        LobbyPanel.SetActive(true);
        Infopanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        
    }

    public void GotoLobby(bool value)
    {
        if(value)
        {
            EnableLobby = true;
            SceneManager.LoadScene(0);
        }
    }

    public void ShowInfo()
    {
        Infopanel.SetActive(true);
        LobbyPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
