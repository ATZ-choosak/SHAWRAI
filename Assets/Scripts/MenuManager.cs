using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject loadUI;

    [SerializeField]
    private TextMeshProUGUI loadText;
    public void Play()
    {
        loadUI.SetActive(true);
        StartCoroutine(load());
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator load()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

        while (!asyncLoad.isDone)
        {
            loadText.text = $"LOADING..{(int)(asyncLoad.progress * 100)}%";
            yield return null;
        }
    }
}
