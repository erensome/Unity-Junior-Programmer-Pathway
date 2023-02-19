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
    public string userName;
    private int HighScore;
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
        }
    }

    public int GetHighScore()
    {
        return HighScore;
    }

    public void SaveHighScore(int m_Points)
    {
        if (m_Points > HighScore)
        {
            SaveData data = new SaveData();
            data.highScore = m_Points;
            HighScore = m_Points;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
        }
    }
}
