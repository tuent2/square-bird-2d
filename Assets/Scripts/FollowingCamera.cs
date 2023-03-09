using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] PlayerCripts playerSpeed;
    Rigidbody2D rb2d;
    bool isMoving = false;
     void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isMoving = false;
    }
    void Update()
    {
        if (isMoving == true)
        {
            Vector2 playerVerlocity = new Vector2(playerSpeed.getBaseSpeed()-0.06f, rb2d.velocity.y);
            rb2d.velocity = playerVerlocity;
        }
        if(isMoving == false){
            rb2d.velocity = Vector2.zero;
        }
   

    }

    
    public void setMainCameraMove(bool value){
        isMoving = value;
    }

    public bool getMainCameraMove(){
        return isMoving;
    }
}
