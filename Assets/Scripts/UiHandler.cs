using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public Canvas loadingCanvas;
    public Canvas playingCavas;
    public GameObject startPoint;
    public GameObject player;
    
    public FollowingCamera mainCamera;
    private void Awake() {
        playingCavas.gameObject.SetActive(false);
    }
    public void startPlay()
    {
        mainCamera.setMainCameraMove(true);
        loadingCanvas.gameObject.SetActive(false);
        playingCavas.gameObject.SetActive(true);

        Instantiate(player,startPoint.transform.position, Quaternion.identity);
    
    }

}
