using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CMFollowingCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        
        player = GameObject.Find("Player0"+"(Clone)");
        Debug.Log(player);
        virtualCamera.Follow = player.transform;
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =new Vector3(0,2.73f,-10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
    }
}
