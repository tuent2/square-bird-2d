using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int Score;
    void Start()
    {
        if(!PlayerPrefs.HasKey(key: "Score")){
            this.Score = 0;
        }
        else {
            this.Score = PlayerPrefs.GetInt("Score");
        }
    }
}
