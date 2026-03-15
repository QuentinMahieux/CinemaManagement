using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    public GameObject mainCamera;
    public CinemachineCamera cinemachineCamera;

    [Header("Interface")] 
    public TMP_Text nameLevel;
    
    [Header("Start Game")]
    public GameObject startGameInterface;
    public Image imageLevel;
    public TMP_Text bestScore;
    public TMP_Text nextScore;
    
    [Header("Lock")]
    public GameObject lockInterface;
    public Image imageLock;
    public TMP_Text stepLock;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one Camera Follower in the scene");
            Destroy(gameObject);
        }
        
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartFollow(Transform target, LevelData levelData, StationMetro station)
    {
        mainCamera.gameObject.SetActive(false);
        cinemachineCamera.Follow = target;

        RefreshInterface();
        nameLevel.text = levelData.levelName;

        if (station.isLock)
        {
            AffichageInterfaceLock(station);
        }
        else
        {
            AfficheInterfaceStart(levelData);
        }
        
    }

    public void StopFollow()
    {
        mainCamera.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void PressStartButton()
    {
        GameManager.instance.StartLevel();
    }

    void RefreshInterface()
    {
        startGameInterface.gameObject.SetActive(false);
        lockInterface.gameObject.SetActive(false);
    }

    void AffichageInterfaceLock(StationMetro station)
    {
        lockInterface.gameObject.SetActive(true);

        stepLock.text = PointCointer.instance.numberStar + "/" + station.nbrUnlock;
    }
    
    void AfficheInterfaceStart(LevelData levelData)
    {
        startGameInterface.gameObject.SetActive(true);

        
        imageLevel.sprite = levelData.sprite;
        

        bestScore.text = SaveLevel.instance.GetInt(levelData.levelName).ToString();

        nextScore.gameObject.SetActive(false);
        foreach (int pallier in levelData.starsPallier)
        {
            if (SaveLevel.instance.GetInt(levelData.levelName) <= pallier)
            {
                nextScore.gameObject.SetActive(true);
                nextScore.text = pallier.ToString();
                break;
            }
        }
    }
}
