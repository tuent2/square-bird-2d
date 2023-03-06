using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvManager : MonoBehaviour
{
    public List<GameObject> map;
    public GameObject finalMap;
    public GameObject startGround;
    
    int mapcount = 5;
    int lv;

    void Awake() {
       if(!PlayerPrefs.HasKey("Current_Level")){
            
            this.lv =1;
        }
        else {
            this.lv = PlayerPrefs.GetInt("Current_Level");
        }
    }

    void Start() {
        int obstacle = mapcount + lv;
        for (int i = 0 ; i< obstacle; i++){
            Vector3 vectorPosition = new Vector3(((float)(8.71+8.8*i)),7.12f,0);
            Instantiate(map[Random.Range(0,map.Count)]
            ,vectorPosition,Quaternion.identity);
        }
        Vector3 finalMapPosition = new Vector3(((float)(9.6+(obstacle)*8.8)),2.453f,0);
        Instantiate(finalMap,finalMapPosition
            ,Quaternion.identity);
    }
    
    void Update()
    {
        
    }

    public void setLevel(int value){
        lv = lv + value;
    }

    public int getLevel(){
        return lv;
    }
}
