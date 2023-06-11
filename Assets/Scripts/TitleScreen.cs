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

    private void Start()
    {
        player = GameObject.Find("Player");
        SwitchToTitle();
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
        //SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        onTitle = true;

        mainPanel.SetActive(false);
        titlePanel.SetActive(true);
        player.SetActive(false);
        titleCam.SetActive(true);

        StartCoroutine(ShuffleIslands());
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
