using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Entity;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private String playerName;
    private int playerFinalScore;

    private String highestScoringPlayer = "Anonymous";
    private int highestScore = 0;

    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }

    public int PlayerFinalScore
    {
        get => playerFinalScore;
        set => playerFinalScore = value;
    }

    public string HighestScoringPlayer
    {
        get => highestScoringPlayer;
        set => highestScoringPlayer = value;
    }

    public int HighestScore
    {
        get => highestScore;
        set => highestScore = value;
    }

    private void Start()
    {
        LoadHighScore();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHighestScore(int newHighScore)
    {
        highestScore = newHighScore;
        highestScoringPlayer = playerName;
    }

    public void SaveHighScore()
    {
        HighScoreData highScoreData = new HighScoreData();
        highScoreData.playerName = highestScoringPlayer;
        highScoreData.highestScore = highestScore;
        
        string json = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        try
        {
            string path = Application.persistentDataPath + "/savefile.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

                if (data != null)
                {
                    highestScoringPlayer = data.playerName;
                    highestScore = data.highestScore;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

}
