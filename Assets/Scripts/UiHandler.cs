using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiHandler : MonoBehaviour
{
    [Header("Canvas Loading")]
    public Canvas loadingCanvas;
    [SerializeField] TextMeshProUGUI vibrateOff;
    public bool isVibrate;
    [SerializeField] TextMeshProUGUI musicOff;
    [Header("Canvas playing")]
    public Canvas playingCavas;
    public Slider sliderWay;
    public LvManager lvManager;
    [Header("Character Canvas")]
    [SerializeField] Canvas CharacterCanvas;
    [Header("StartPont")]
    public GameObject startPoint;
    public List<GameObject> player;
    public GameObject clone;
    [Header("Camera")]
    public FollowingCamera mainCamera;
    [Header(header: "Audio")]
    public GameObject AudioPlayer;
    AudioSource AudioPlayerSoure1;
    int characterChoise;
    private void Awake()
    {
        playingCavas.gameObject.SetActive(false);
        CharacterCanvas.gameObject.SetActive(false);


        if (!PlayerPrefs.HasKey("squarebird_selectedchar"))
        {
            this.characterChoise = 0;
        }
        else
        {
            this.characterChoise = PlayerPrefs.GetInt("squarebird_selectedchar");
        }
        clone = Instantiate(player[characterChoise], startPoint.transform.position, Quaternion.identity);
    }

    void Start()
    {
        AudioPlayerSoure1 = AudioPlayer.GetComponent<AudioSource>();
        // if (!PlayerPrefs.HasKey("Music_status"))
        // {
        //     AudioPlayerSoure1.mute = false;
        //     musicOff.enabled = false;
        // }
        // else
        // {
        //     if (PlayerPrefs.GetInt("Music_status") == 1)
        //     {
        //         AudioPlayerSoure1.mute = false;
        //         musicOff.enabled = false;
        //     }
        //     else if (PlayerPrefs.GetInt("Music_status") == 0)
        //     {
        //         AudioPlayerSoure1.mute = true;
        //         musicOff.enabled = true;
        //     }
        // }
        sliderWay.maxValue = lvManager.transform.InverseTransformPoint(GameObject.Find("finalpoint").transform.position).x - startPoint.transform.position.x;
        sliderWay.value = 0;
        isVibrate = true;
        vibrateOff.enabled = false;
        
        
    }

    void Update()
    {
        if (clone != null)
        {
            sliderWay.value = lvManager.transform.InverseTransformPoint(GameObject.Find("finalpoint").transform.position).x - (lvManager.transform.InverseTransformPoint(GameObject.Find("finalpoint").transform.position).x - clone.transform.position.x);
        }

    }
    public void startPlay()
    {
        
        loadingCanvas.gameObject.SetActive(false);
        playingCavas.gameObject.SetActive(true);
        FindObjectOfType<PlayerCripts>().setIsPlaying();
    }

    public void settingPlayMusic()
    {

        if (AudioPlayerSoure1 != null)
        {
            if (AudioPlayerSoure1.mute == true)
            {
                AudioPlayerSoure1.mute = false;
                musicOff.enabled = false;
            }
            else
            {
                AudioPlayerSoure1.mute = true;
                musicOff.enabled = true;
            }
        }

    }

    public bool getMusicStatus()
    {
        return AudioPlayerSoure1.mute;
    }

    public void OpenCharacterCanvas()
    {
        loadingCanvas.gameObject.SetActive(false);
        CharacterCanvas.gameObject.SetActive(value: true);
    }

    public void goBackFromCharacterToLoadingCanvas()
    {
        CharacterCanvas.gameObject.SetActive(value: false);
        loadingCanvas.gameObject.SetActive(true);
    }

    public void choseCharacter(int charId)
    {
        PlayerPrefs.SetInt("squarebird_selectedchar", charId);
        SceneManager.LoadScene(0);
    }

    public void turnOfVibrate()
    {
        if (isVibrate == true)
        {
            isVibrate = false;
            vibrateOff.enabled = true;
        }
        else if (isVibrate == false)
        {
            isVibrate = true;
            vibrateOff.enabled = false;
        }
    }

}
