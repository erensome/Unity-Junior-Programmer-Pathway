using System;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;
    private void Awake()
    {
        // Only a single instance of the MainManager can ever exist.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    
    [Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
    
    public void SaveColor()
    {
        SaveData myData = new SaveData();
        myData.TeamColor = TeamColor;
            
        string json = JsonUtility.ToJson(myData);
        
        // Application.persistentDataPath that will give you a folder where you can save data that
        // will survive between application reinstall or update.
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        
        if (File.Exists(path))
        {
            // If the file does exist, then the method will read its content with File.ReadAllText: 
            string json = File.ReadAllText(path);
            SaveData myData = myData = JsonUtility.FromJson<SaveData>(json);
            TeamColor = myData.TeamColor;
        }
    }
}

