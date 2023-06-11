using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> panelLists = new List<GameObject>();
    int currPanelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPanel()
    {
        GameObject currPanel = panelLists[currPanelIndex];
        currPanel.SetActive(true);
        currPanelIndex++;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
