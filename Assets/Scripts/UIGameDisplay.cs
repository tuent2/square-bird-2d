using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIGameDisplay : MonoBehaviour
{
    [Header("Time and Gold")]
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI gold;
    [Header("Level And Way")]    
    [SerializeField] TextMeshProUGUI currentLv;
    [SerializeField] TextMeshProUGUI nextLv;
    [SerializeField] Slider way;
    public LvManager lvManager;
    int timePlay;
    private float timeElapsed = 0f;

    void Start()
    {   
        currentLv.text =  PlayerPrefs.GetInt("Current_Level")+"";
        nextLv.text = (PlayerPrefs.GetInt("Current_Level")+1)+"";
        timePlay = PlayerPrefs.GetInt("TimePlay");
        gold.text = PlayerPrefs.GetInt("Score")+"";
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1f)
        {
            this.timePlay++;
            timeElapsed = 0f;
            time.text = timePlay +"";
        }
    }

    public string getTimeOfTextMesh(){
        return time.text;
    }

}
