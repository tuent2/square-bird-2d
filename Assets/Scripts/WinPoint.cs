using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class WinPoint : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    UIGameDisplay time;
    
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        // lvManager = GameObject.Find("Lv Manager").GetComponent<LvManager>();
       
    //    time = GameObject.Find("PlayingCanvas") 
        
    }

    // Update is called once per frame
    void Update()
    {   
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" ){
            time = GameObject.Find("PlayingCanvas").GetComponent<UIGameDisplay>();
            int timeValue;
            int.TryParse(time.getTimeOfTextMesh(),out timeValue);
            PlayerPrefs.SetInt("TimePlay",timeValue);
            Debug.Log(GameObject.Find("PlayingCanvas")  );
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score") + 13);
            PlayerPrefs.SetInt("Current_Level", (PlayerPrefs.GetInt("Current_Level")+1));
            StartCoroutine(routine: NewLevel());
        }
    }

    IEnumerator NewLevel(){
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(0);
    }
}
