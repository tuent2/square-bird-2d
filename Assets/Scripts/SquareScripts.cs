using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScripts : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    Rigidbody2D rb2d;
    [SerializeField] PlayerCripts playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerVerlocity = new Vector2(playerSpeed.getBaseSpeed(), rb2d.velocity.y);
        rb2d.velocity = playerVerlocity;
    }

    
}
