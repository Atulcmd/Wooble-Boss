using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CMF;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;

    [Header("Game UI")]
    public GameObject GameWinUI;
    public GameObject GameOverUI;
    public GameObject GamePanelUI;

    public Text currentText;

    public bool GameEnd;
    int CurrentLevel;
    AudioSource audio;
    GameObject Player;
    public GameObject[] Level;

    int currentCash, totalCash;
    public Text CurrentCashText,TotalCashText;

    bool IsEnd;


    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        Instantiate(Level[CurrentLevel]);
    }

    void Start()
    {
        currentCash = 0;
        IsEnd = false;
        UpdateCash();
        GameEnd = false;
        audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        //  CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        currentText.text = "FLOOR " + (CurrentLevel);
        TotalCashText.text = ""+PlayerPrefs.GetInt("Score", 0);
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGameOver() {
        if (!IsEnd)
        {
            Player.GetComponent<CharacterKeyboardInput>().useRawInput = false;
            IsEnd = true;
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver() {
        
        Adcontrol.instance.ShowAds();
        yield return new WaitForSeconds(1f);
        audio.Stop();
        GameOverUI.SetActive(true);
        GamePanelUI.SetActive(false);

    }

    public void StartGameWin()
    {
        if(!IsEnd){
            PlayerPrefs.SetInt("Level", CurrentLevel + 1);
            IsEnd = true;
            StartCoroutine(GameWin());
        }

    }

    IEnumerator GameWin()
    {
        audio.Stop();
        GamePanelUI.SetActive(false);
        totalCash = PlayerPrefs.GetInt("Score", 0);
        PlayerPrefs.SetInt("Score", totalCash + currentCash);
        Adcontrol.instance.ShowAds();
        yield return new WaitForSeconds(2f);
        GameWinUI.SetActive(true);


    }

    public void AddScore() {
        currentCash = currentCash+10;
        UpdateCash();
    }

    void UpdateCash() {
        CurrentCashText.text = ""+currentCash;
    }

    public void ReloadLevel() {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
