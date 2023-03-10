using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCripts : MonoBehaviour
{
    [SerializeField] float baseSpeed = 4f;
    [SerializeField] GameObject square;
    [SerializeField] Transform gp;
    [SerializeField] ParticleSystem groundParticleSystem;
    BoxCollider2D boxCollider2D;
    // public bool isMoving = false;
    RaycastHit2D hit;

    Rigidbody2D rb2d;
    AudioPlayer audioPlayer;
    Animator animator;
    FollowingCamera followingCamera;
    UiHandler UiHandler;
    
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        followingCamera = FindAnyObjectByType<FollowingCamera>();
        UiHandler = FindAnyObjectByType<UiHandler>();
    }


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerVerlocity = new Vector2(baseSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVerlocity;
        // if (Input.GetKeyDown("space"))
        // {

        //     this.hit = Physics2D.Raycast(rb2d.transform.position + new Vector3(0,1f,0)  , Vector3.up, 0.5f);
        //     if (this.hit.collider == null)
        //     {
        //         rb2d.transform.position = new Vector2(rb2d.transform.position.x, rb2d.transform.position.y + 1f);
        //         Instantiate(square, gp.position, transform.rotation);
        //         audioPlayer.playDropEggsClip();
        //     }
        // }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            this.hit = Physics2D.Raycast(rb2d.transform.position + new Vector3(0, 1f, 0), Vector3.up, 0.5f);
            if (this.hit.collider == null)
            {
                rb2d.transform.position = new Vector2(rb2d.transform.position.x, rb2d.transform.position.y + 1f);
                Instantiate(square, gp.position, transform.rotation);
                audioPlayer.playDropEggsClip();
                
                if(UiHandler.isVibrate){
                    Handheld.Vibrate();
                }
                
                

            }
        }
    }

    // private void OnMouseDown() {
    //         this.hit = Physics2D.Raycast(rb2d.transform.position + new Vector3(0,1f,0)  , Vector3.up, 0.5f);
    //         if (this.hit.collider == null)
    //         {
    //             rb2d.transform.position = new Vector2(rb2d.transform.position.x, rb2d.transform.position.y + 1f);
    //             Instantiate(square, gp.position, transform.rotation);
    //             audioPlayer.playDropEggsClip();
    //         }
    // }

    public float getBaseSpeed()
    {
        return baseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Block"))
        {
            Handheld.Vibrate();
            // this.rb2d.AddForceAtPosition((Vector2.left + Vector2.up) * 2f, base.transform.position, ForceMode2D.Impulse);
            animator.SetBool("isDead",true);
            followingCamera.setMainCameraMove(false);
            audioPlayer.playCollideClip();
            StartCoroutine(routine: NewLevel());
        }
        if(other.gameObject.tag.Equals("Prevent")){
            groundParticleSystem.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Prevent")){
            groundParticleSystem.Stop();
        }
    }
    IEnumerator NewLevel()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(0);
    }

}
