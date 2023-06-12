using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : GenericSingleton<TitleScreen>
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject titlePanel;
    [SerializeField] GameObject titleCam;
    GameObject player;

    public bool onTitle = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoadRuntimeMethod()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        player = GameObject.Find("Player");

        if (PlayerPrefs.GetInt("loadedTitle", 0) != 1)
        {
            SwitchToTitle();
        }
    }

    IEnumerator ShuffleIslands()
    {
        while (true)
        {
            IslandSpawning.Instance.ResetSave();
            IslandSpawning.Instance.GenerateIslands();

            if (!onTitle)
            {
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void SwitchToTitle()
    {
        // reset
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("loadedTitle", 1);

        onTitle = true;

        mainPanel.SetActive(false);
        titlePanel.SetActive(true);
        player.SetActive(false);
        titleCam.SetActive(true);

        StartCoroutine(ShuffleIslands());

        ResourceManager.Instance.AddResource("Tree", 100);
        ResourceManager.Instance.AddResource("Rock", 100);
        ResourceManager.Instance.AddResource("DungeonCoins", 100);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
    }

    public void EndTitle()
    {
        StopCoroutine(ShuffleIslands());

        mainPanel.SetActive(true);
        titlePanel.SetActive(false);
        player.SetActive(true);
        titleCam.SetActive(false);

        onTitle = false;
    }
}
