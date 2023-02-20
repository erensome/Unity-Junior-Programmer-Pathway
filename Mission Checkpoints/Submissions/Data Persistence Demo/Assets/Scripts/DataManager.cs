using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentUserName;
    private int HighScore;
    private string HighScoreName;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    
    [Serializable]
    public class SaveData
    {
        public string userName;
        public int highScore;
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScore = data.highScore;
            HighScoreName = data.userName;
        }
    }

    public int GetHighScore()
    {
        return HighScore;
    }

    public string GetHighScoreName()
    {
        return HighScoreName;
    }
    
    public void SaveHighScore(string m_Username, int m_Points)
    {
        if (m_Points > HighScore)
        {
            SaveData data = new SaveData();
            data.highScore = m_Points;
            data.userName = m_Username;
            HighScore = m_Points;
            HighScoreName = m_Username;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
        }
    }
}
