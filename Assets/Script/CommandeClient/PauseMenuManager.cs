using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager instance;
    
    public GameObject pauseMenu;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one PauseMenuManager in scene!");
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isPause)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.isPause)
        {
            Resume();
        }
    }

    public void QuitLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        GameManager.instance.isPause = false;
        Time.timeScale = 1;
        
        SceneManager.LoadScene("SelectLevel");
    }
    

    public void Resume()
    {
        pauseMenu.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        GameManager.instance.isPause = false;
        Time.timeScale = 1;
    }
    
    public void Pause()
    {
        GameManager.instance.isPause = true;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        Time.timeScale = 0;
    }
}
