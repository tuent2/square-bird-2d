using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCripts : MonoBehaviour
{
    [SerializeField] float boostSpeed = 4f;
    [SerializeField] float baseSpeed = 2f;
    [SerializeField] GameObject squ;
    [SerializeField] Transform gp;
    BoxCollider2D boxCollider2D;

     Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 playerVerlocity =  new Vector2(baseSpeed,rb2d.velocity.y);
         rb2d.velocity = playerVerlocity;
         if(Input.GetKeyDown("space")){
            rb2d.transform.position = new Vector2 (rb2d.transform.position.x ,rb2d.transform.position.y+1f);   
            Debug.Log(rb2d.transform.position);
            Instantiate(squ,gp.position,transform.rotation);
         }
        //  StartCoroutine(waitALittleTime(transform));
     
     
    }

    IEnumerator waitALittleTime(Transform transform123){
        yield return new WaitForSecondsRealtime(time: 1f);
        Debug.Log(rb2d.transform.position);
        Debug.Log(transform123.position);
        if (rb2d.transform.position == transform123.position){
            SceneManager.LoadScene(0);
        }
    }


}
