using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    public float speed = 10.0f;
    public float jumpforce = 10.0f;
    public LayerMask ground;
    private int cherry = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collections"))
        {
            Destroy(collision.gameObject);
            cherry += 1;
        }
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float faceit = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * speed * Time.deltaTime, rb.velocity.y);
        anim.SetFloat("running", Mathf.Abs(faceit));


        if (faceit != 0)
        {
            transform.localScale = new Vector3(faceit, 1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (coll.IsTouchingLayers(ground))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
                anim.SetBool("jumping", true);
            }
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("idel", false);
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }

        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idel", true);
        }
    }
}
