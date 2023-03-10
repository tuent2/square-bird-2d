using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class WinPoint : MonoBehaviour
{
    UIGameDisplay time;
    UiHandler handler;
    int Music_status1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" ){
            time = GameObject.Find("Playing Canvas").GetComponent<UIGameDisplay>();
            int timeValue;
            int.TryParse(time.getTimeOfTextMesh(),out timeValue);
            PlayerPrefs.SetInt("TimePlay",timeValue);
            Debug.Log(GameObject.Find("PlayingCanvas")  );
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score") + 13);
            PlayerPrefs.SetInt("Current_Level", (PlayerPrefs.GetInt("Current_Level")+1));
            
            // handler = GameObject.Find("Ui Handler").GetComponent<UiHandler>();      
            // if(handler.getMusicStatus() == true){
            //     Music_status1 = 1;
            // }else if (handler.getMusicStatus() == false){
            //     Music_status1 = 0;
            // }
            // PlayerPrefs.SetInt("Music_status",Music_status1);
            StartCoroutine(routine: NewLevel());
        }
    }

    IEnumerator NewLevel(){
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(0);
    }
}
