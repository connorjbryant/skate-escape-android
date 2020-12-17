using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Tornado")
        {
            GetComponent<Rigidbody2D>().gravityScale = -0.4f;
            StartCoroutine(TornadoFunction());
            //anim.SetBool("grind", false);
        }
    }

    private IEnumerator TornadoFunction()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().gravityScale = -0.3f;
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().gravityScale = 1.5f;
    }

    private void Update()
    {
        //transition from jump to fall
        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y < .1)
            {
                anim.SetBool("falling", true);
                anim.SetBool("jumping", false);
            }
        }

        //transition from fall to idle
        if(coll.IsTouchingLayers(ground) && anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            //testing if beyond leftCap
            if (transform.position.x > leftCap)
            {
                //make sure sprite is facing right location
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                //if on ground jump
                if (coll.IsTouchingLayers(ground))
                {
                    //jump
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("jumping", true);
                }

            }
            else
            {
                facingLeft = false;
            }
            //if not face right
        }

        else
        {
            //testing if beyond rightCap
            if (transform.position.x < rightCap)
            {
                //make sure sprite is facing right location
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                //if on ground jump
                if (coll.IsTouchingLayers(ground))
                {
                    //jump
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("jumping", true);
                }

            }
            else
            {
                facingLeft = true;
            }
            //if not face right
        }
    }

    

}
