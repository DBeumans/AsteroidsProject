using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHighscoreList : MonoBehaviour {

    public GameObject PlayerScoreEntryPrefab;

    int lastChangeCounter;

    HighScore _highscore;
	// Use this for initialization
	void Start () {

        _highscore = GameObject.FindObjectOfType<HighScore>();

        lastChangeCounter = _highscore.GetChangeCounter();

	
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        /*
        // enable dit dan bug.
        if(_highscore.GetChangeCounter() == lastChangeCounter)
        {
            // geen change
            return;
        }
        */
        lastChangeCounter = _highscore.GetChangeCounter();

        while(this.transform.childCount >0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);    
        }
        string[] names = _highscore.GetPlayerNames("wave");
        
        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(PlayerScoreEntryPrefab);
            go.transform.SetParent(this.transform);

            go.transform.Find("Points").GetComponent<Text>().text = name;
            go.transform.Find("Wave").GetComponent<Text>().text = _highscore.GetScore(name, "wave").ToString();
            go.transform.Find("Hours").GetComponent<Text>().text = _highscore.GetScore(name, "hours").ToString();
            go.transform.Find("Minutes").GetComponent<Text>().text = _highscore.GetScore(name, "minutes").ToString();
            go.transform.Find("Seconds").GetComponent<Text>().text = _highscore.GetScore(name, "seconds").ToString();


        }

    }
}
