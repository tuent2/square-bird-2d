using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class WinPoint : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    [SerializeField] TextMeshProUGUI time; 
    
    // public LvManager lvManager;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        // lvManager = GameObject.Find("Lv Manager").GetComponent<LvManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" ){
            int timeValue;
            int.TryParse(time.text,out timeValue);
            PlayerPrefs.SetInt("TimePlay",timeValue);
            PlayerPrefs.SetInt("Current_Level", (PlayerPrefs.GetInt("Current_Level")+1));
            StartCoroutine(routine: NewLevel());
        }
    }

    IEnumerator NewLevel(){
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(0);
    }
}
