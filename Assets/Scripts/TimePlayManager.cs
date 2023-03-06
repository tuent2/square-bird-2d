using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayManager : MonoBehaviour
{
    int timePlay;
    void Awake()
    {
        if(!PlayerPrefs.HasKey(key: "TimePlay")){
            this.timePlay = 0;
        }
        else {
            this.timePlay = PlayerPrefs.GetInt("TimePlay");
        }
    }
    public void setTimePlay(int value){
        timePlay = value;
    }

    public int getTimePlay (){
        return timePlay;
    }
}
