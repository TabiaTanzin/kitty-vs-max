using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 50f;
    private Animator anim;
    private float translation;
    private Rigidbody2D rb;
    public LayerMask WIG;
    public Transform GP;
    public bool G = true;
    public float jumpforce;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        turncat();
        translation = Input.GetAxisRaw("Horizontal");
        // transform.Translate(new Vector3 (translation, 0f, 0f) * Time.deltaTime * speed);
        rb.velocity = new Vector2(translation * Time.deltaTime * speed, rb.velocity.y);

        if (translation > 0 || translation < 0)
        {
            anim.SetFloat("speed", 1);
        }
        if (translation == 0)
        {
            anim.SetFloat("speed", 0);
        }
    }
    void turncat()
    {
        if (translation < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (translation > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    bool isGround()
    {
        if (Physics2D.OverlapCircle(GP.position, 0.03f, WIG))
        {
            return true;
        }
        else
        { return false; }
    }

    void jump()
    {
        if (!isGround())
        {
            return;
        }
        else
        {
            rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
    }
}
