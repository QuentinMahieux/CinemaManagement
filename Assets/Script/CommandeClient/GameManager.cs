using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public LevelData levelSelect;
    
    
    
    [Header("Pause")]
    public bool isPause;
    
    [Header("Settings")]
    [Header("Language")]
    public LanguageData language;
    public List<LanguageData> languageList;

    [Header("Performance")] 
    public int currentFPS = 60;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one GameManager in scene.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        //Language
        if (language)
        {
            SaveLevel.instance.SetString("languageSetting", language.id);
        }
        int languageId = SaveLevel.instance.GetInt("languageSetting");
        foreach (LanguageData l in languageList)
        {
            if (l.id == languageId)
            {
                language = l;
            }
        }
        
        //FPS
        SaveLevel.instance.SetString("FPSSetting", currentFPS);
        currentFPS = SaveLevel.instance.GetInt("FPSSetting");

    }

    public void StartLevel()
    {
        LevelData newlevelSelect = MetroController.instance.actualStation.levelData;
        levelSelect = newlevelSelect;

        MetroController.instance.SetCoordonee();
        
        SceneManager.LoadScene(newlevelSelect.levelName);
    }

    void OnApplicationQuit()
    {
        if (MetroController.instance)
        {
            MetroController.instance.SetCoordonee();
        }
    }

    public void ChangeLanguage(LanguageData newLanguage)
    {
        language = newLanguage;
        SaveLevel.instance.NewInt( "languageSetting", language.id);
    }

    public void ChangeFPS(int newvalue)
    {
        SaveLevel.instance.NewInt("FPSSetting", newvalue);
        currentFPS = newvalue;
    }
}
