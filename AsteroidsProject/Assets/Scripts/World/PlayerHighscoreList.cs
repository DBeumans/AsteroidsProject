using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHighscoreList : MonoBehaviour {

    public GameObject PlayerScoreEntryPrefab;

    Save _save;
	// Use this for initialization
	void Start () {

        _save = GameObject.FindObjectOfType<Save>();
        
        SetScore();
    }

    void SetScore()
    {
        GameObject go = (GameObject)Instantiate(PlayerScoreEntryPrefab);
        go.transform.SetParent(this.transform);

        //-------------------------------------------------------------

        go.transform.Find("Points").GetComponent<Text>().text = PlayerPrefs.GetFloat("Score").ToString();
        go.transform.Find("Wave").GetComponent<Text>().text = PlayerPrefs.GetFloat("Wave").ToString();
        go.transform.Find("Hours").GetComponent<Text>().text = PlayerPrefs.GetFloat("Hours").ToString();
        go.transform.Find("Minutes").GetComponent<Text>().text = PlayerPrefs.GetFloat("Minutes").ToString();
        go.transform.Find("Seconds").GetComponent<Text>().text = PlayerPrefs.GetFloat("Seconds").ToString();
    }
}
