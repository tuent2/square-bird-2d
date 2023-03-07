using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public Canvas loadingCanvas;
    public Canvas playingCavas;
    public GameObject startPoint;
    public GameObject player;
    public GameObject clone;
    public FollowingCamera mainCamera;
    public GameObject AudioPlayer;
    AudioSource AudioPlayerSoure1;
    private void Awake()
    {
        playingCavas.gameObject.SetActive(false);
    }

    void Start()
    {
            AudioPlayerSoure1 =AudioPlayer.GetComponent<AudioSource>();
    }
    public void startPlay()
    {
        mainCamera.setMainCameraMove(true);
        loadingCanvas.gameObject.SetActive(false);
        playingCavas.gameObject.SetActive(true);

        clone = Instantiate(player, startPoint.transform.position, Quaternion.identity);

    }

    public void settingPlayMusic()
    {

        if (AudioPlayerSoure1 != null)
        {
            if (AudioPlayerSoure1.mute == true)
            {
                AudioPlayerSoure1.mute = false;
            }
            else
            {
                AudioPlayerSoure1.mute = true;
            }
        }

    }

}
