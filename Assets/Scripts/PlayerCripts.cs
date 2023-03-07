using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCripts : MonoBehaviour
{
    [SerializeField] float baseSpeed = 4f;
    [SerializeField] GameObject square;
    [SerializeField] Transform gp;

    BoxCollider2D boxCollider2D;
    // public bool isMoving = false;
    RaycastHit2D hit;

    Rigidbody2D rb2d;
    AudioPlayer audioPlayer;
    FollowingCamera followingCamera;
    private void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        followingCamera = FindAnyObjectByType<FollowingCamera>();
    }

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerVerlocity = new Vector2(baseSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVerlocity;
        if (Input.GetKeyDown("space"))
        {
            
            this.hit = Physics2D.Raycast(rb2d.transform.position + new Vector3(0,1f,0)  , Vector3.up, 0.5f);
            if (this.hit.collider == null)
            {
                rb2d.transform.position = new Vector2(rb2d.transform.position.x, rb2d.transform.position.y + 1f);
                Instantiate(square, gp.position, transform.rotation);
                audioPlayer.playDropEggsClip();
            }
        }
    }

    public float getBaseSpeed()
    {
        return baseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Block")){
            followingCamera.setMainCameraMove(false);
            audioPlayer.playCollideClip();
            StartCoroutine(routine: NewLevel());
        }
    }

    IEnumerator NewLevel(){
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(0);
    }

}
