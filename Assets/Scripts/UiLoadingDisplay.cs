using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiLoadingDisplay : MonoBehaviour
{
    [Header("Music")]
    public GameObject audioPlayer;
    AudioSource audioSource;
    [SerializeField] TextMeshProUGUI musicOff;
    void Start()
    {
        audioSource = audioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void setTextMeshMusic()
    {
        if (audioSource.mute == true)
        {
            musicOff.enabled = false;
        }
        else
        {
            musicOff.enabled = true;
        }
    }
}
