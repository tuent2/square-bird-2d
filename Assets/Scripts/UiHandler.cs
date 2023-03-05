using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public Canvas loadingCanvas;
    public Canvas playingCavas;
    
    public GameObject startPoint;
    public GameObject player;
    private void Awake() {
        playingCavas.gameObject.SetActive(false);
    }
    private void Start() {
        
    }
    public void startPlay()
    {
        loadingCanvas.gameObject.SetActive(false);
        playingCavas.gameObject.SetActive(true);

        Instantiate(player,startPoint.transform.position, Quaternion.identity);
    
    }
}
