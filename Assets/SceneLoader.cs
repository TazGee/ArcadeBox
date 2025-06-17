using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider loadingSlider;
    public GameObject loadingScreen;

    public void LoadScene(int scena)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(scena));
    }

    IEnumerator LoadSceneAsync(int i)
    {
        AsyncOperation ucitavanje = SceneManager.LoadSceneAsync(i);

        while(!ucitavanje.isDone)
        {
            float progress = Mathf.Clamp01(ucitavanje.progress / .9f);

            loadingSlider.value = progress;

            yield return null;
        }
    }
}
