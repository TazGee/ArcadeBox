using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject pressAnyKeyUI;
    public GameObject mainMenuUI;
    public Animator transitionUIAnimator;

    bool activatedMenu;

    void Start()
    {
        activatedMenu = false;
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
    }

    void DeactivatePressAnyKey()
    {
        pressAnyKeyUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
