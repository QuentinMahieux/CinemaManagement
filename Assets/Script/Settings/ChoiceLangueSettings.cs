using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceLangueSettings : MonoBehaviour
{
    public static ChoiceLangueSettings instance;

    public TMP_Text textNameLangue;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There are two settings instances of ChoiceLangueSettings.");
            Destroy(gameObject);
        }
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
    public GameObject allButton;
    void Start()
    {
        CloseChoiceLangue(GameManager.instance.language);
    }

    public void OpenChoiceLangue()
    {
        allButton.SetActive(true);
    }
    

    public void CloseChoiceLangue(LanguageData newLanguage)
    {
        allButton.SetActive(false);
        GameManager.instance.ChangeLanguage(newLanguage);
        textNameLangue.text = GameManager.instance.language.name;
        
    }
    
}
