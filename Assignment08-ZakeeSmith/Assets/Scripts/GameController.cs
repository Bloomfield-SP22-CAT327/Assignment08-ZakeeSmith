using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    void Awake()
    {
        if(PlayerPrefs.HasKey("score"))
        {
            GetScore();

        }
        else
        {
            NewGame();
        }
    }

   
    void Update()
    {
        scoreText.text = "Points Collected : " + score;

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Deleted Score!");
            Delete();
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Saved Score!");
            SaveWhatYouHave();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restarted Game!");
            SceneManager.LoadScene("Game");
        }
    }

    public void AddPoints()
    {
        score += 15;
    }

    void NewGame()
    {
        if(PlayerPrefs.HasKey("score"))
        {
            Delete();
        }
        score = 0;
        SaveWhatYouHave();
    }

    void SaveWhatYouHave()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    void Delete()
    {
        PlayerPrefs.DeleteKey("score");
        score = 0;
        SaveWhatYouHave();
    }

    void GetScore()
    {
        score = PlayerPrefs.GetInt("score");
    }
}
