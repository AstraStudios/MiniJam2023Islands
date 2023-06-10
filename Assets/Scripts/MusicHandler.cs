using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] List<AudioClip> worldMusic = new List<AudioClip>();
    [SerializeField] List<AudioClip> dungeonMusic = new List<AudioClip>();
    AudioSource audioPlayer;
    int currentClipIndex = 0;

    private void Awake()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
        audioPlayer.loop = false;
        PlayNextClip();
    }

    private void PlayNextClip()
    {
        if (SceneManager.GetActiveScene().name == "DungeonScene")
        {
            currentClipIndex = 0;
            audioPlayer.clip = dungeonMusic[currentClipIndex];
        }
        if (worldMusic.Count == 0 && dungeonMusic.Count == 0)
            return;
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            currentClipIndex = Random.Range(0, worldMusic.Count);
            audioPlayer.clip = worldMusic[currentClipIndex];
        }

        currentClipIndex++;
        audioPlayer.Play();
    }

    private void Update()
    {
        if (!audioPlayer.isPlaying)
        {
            PlayNextClip();
        }
    }
}
