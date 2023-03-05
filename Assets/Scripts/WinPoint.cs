using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinPoint : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" ){
            StartCoroutine(NewLevel());
        }
    }

    IEnumerator NewLevel(){
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(0);
    }
}
