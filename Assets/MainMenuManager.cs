using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject pressAnyKeyUI;
    public GameObject mainMenuUI;
    public Animator transitionUIAnimator;

    [Header("Animation")]
    public Animator settingsAnim;
    public Animator gameListAnim;

    bool activatedMenu;
    bool settings;
    bool gameList;

    void Start()
    {
        activatedMenu = false;
        settings = false;
        gameList = false;

        pressAnyKeyUI.SetActive(true);
        mainMenuUI.SetActive(false);
        transitionUIAnimator.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.anyKeyDown && !activatedMenu)
        {
            ActivateMenu();
        }
    }

    void ActivateMenu()
    {
        activatedMenu = true;

        transitionUIAnimator.gameObject.SetActive(true);
        transitionUIAnimator.Rebind();
        transitionUIAnimator.Update(0f);

        Invoke("DeactivatePressAnyKey", 0.7f);
        mainMenuUI.SetActive(true);
    }

    void DeactivatePressAnyKey()
    {
        pressAnyKeyUI.SetActive(false);
    }

    public void ShowSettings(bool state)
    {
        if (gameList) return;

        settings = state;
        settingsAnim.SetBool("settings", state);
    }

    public void ShowGameList(bool state)
    {
        if (settings) return;

        gameList = state;
        gameListAnim.SetBool("list", state);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
