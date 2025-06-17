using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    [Header("Reference")]
    public GameManager manager;

    bool paused;
    bool settings;

    void Start()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        paused = false;
        settings = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !settings && manager.igraPocela)
        {
            ChangePause();
        }
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ChangePause()
    {
        if(paused)
        {
            pauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }
    }

    public void ShowSettings(bool state)
    {
        settingsMenu.SetActive(state);
        settings = state;
    }
}
