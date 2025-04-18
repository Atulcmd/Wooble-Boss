using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {


	public string RateUsUrl,MoreGamesURL;
	public Text CurrentLevelText;
    public GameObject CustomAds;
    [Header("Share")]
    public string Subject;
    public string Body;

    int CurrentLevel;
    public Text Coins;
	

	// Use this for initialization
	void Start () {
      
        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        CurrentLevelText.text = "FLOOR " + CurrentLevel;
        Coins.text = ""+ PlayerPrefs.GetInt("Score", 0);
        Debug.Log("Current char " + PlayerPrefs.GetInt("CURRENT_CHARACTER", 0));
	}


	public void LoadLevel(){

		SceneManager.LoadScene ("Game");
	}


	public void RateUs ()
	{
        Application.OpenURL(RateUsUrl);

    }


    public void MoreGames(){

		Application.OpenURL (MoreGamesURL);
	}


    public void Restart()
    {

        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");

    }

    public void Shop()
    {
        SceneManager.LoadScene("CharacterSelection");

    }
    



}
