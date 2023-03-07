using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    
    [Header("collide")]
    [SerializeField] AudioClip collideClip;
    [SerializeField] [Range(0f,1f)] float collideValume =1f ;

    [Header("Drop Eggs")]
    [SerializeField] AudioClip dropEggsClip;
    [SerializeField] [Range(0f,1f)] float dropEggsValume =1f ;

    public UiHandler uiHandler;

    public void playCollideClip(){
        if(collideClip != null){
            AudioSource.PlayClipAtPoint(collideClip,uiHandler.clone.transform.position,collideValume);
        }
    }

    public void playDropEggsClip(){
        if(collideClip != null){
            AudioSource.PlayClipAtPoint(dropEggsClip,uiHandler.clone.transform.position,dropEggsValume);
        }
    }
}
