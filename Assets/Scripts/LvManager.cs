using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvManager : MonoBehaviour
{
    public List<GameObject> map;
    public GameObject finalMap;
    public GameObject startGround;
    
    private int mapcount = 5;
    private int lv = 1;

    void Awake() {
       
    }

    void Start() {
        for (int i = 0 ; i< mapcount; i++){
            Vector3 vectorPosition = new Vector3(((float)(1.72+8.8*i)),7.12f,0);
            Instantiate(map[Random.Range(0,map.Count)]
            ,vectorPosition,Quaternion.identity);
        }
        Vector3 finalMapPosition = new Vector3(((float)(9.6+(mapcount)*8.8)),2.453f,0);
        Instantiate(finalMap,finalMapPosition
            ,Quaternion.identity);
    }
    
    void Update()
    {
        
    }
}
