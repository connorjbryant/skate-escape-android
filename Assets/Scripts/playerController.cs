using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject explosion;
    public Joystick joystick;


    //Start variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    [SerializeField] private string sceneName;


    //public int coins = 0;

    //Finite state machine
    private enum State {idle, running, jumping, falling, hurt, grind, grind2, grind3}
    private State state = State.idle;

    //Inspector variables
    [SerializeField] private LayerMask ground;
    //[SerializeField] private float speed = 7f;
    //[SerializeField] private float jumpForce = 9f;
    //[SerializeField] private int coins = 0;
    //[SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private AudioSource coin;
    [SerializeField] private AudioSource footstep;
    //[SerializeField] private int health;
    //[SerializeField] private Text healthAmount;

    /*void Awake()
    {
        if (!explosion) explosion = this.gameObject;

        DontDestroyOnLoad(explosion);
    }*/

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
        //healthAmount.text = health.ToString();
        //footstep = GetComponent<AudioSource>();
    }

    public static void DontDestroyChildOnLoad(GameObject child)
    {
        Transform parentTransform = child.transform;

        // If this object doesn't have a parent then its the root transform.
        while (parentTransform.parent != null)
        {
            // Keep going up the chain.
            parentTransform = parentTransform.parent;
        }
        GameObject.DontDestroyOnLoad(parentTransform.gameObject);
    }

    public void ScaleToTarget(Vector3 targetScale, float duration)
    {
        StartCoroutine(ScaleToTargetCoroutine(targetScale, duration));
    }


    private void Update()
    {
        if(state != State.hurt)
        {
            Movement();
        }

        transform.rotation = Quaternion.Euler(0, 0, PermanentUI.perm.rotationspeed);

        AnimationState();
        anim.SetInteger("state", (int)state); //sets animation based on Enumator state
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScaleToTarget(new Vector3(0.5f, 0.3f, 1f), 1f);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ScaleToTarget(new Vector3(2.5f, 2.5f, 1f), 1f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Rigidbody2D>().gravityScale = -0.4f;
            StartCoroutine(TornadoFunction());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(RainbowColor());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        }


    }

    public void Shrink()
    {
        ScaleToTarget(new Vector3(0.5f, 0.3f, 1f), 1f);
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slope1")
        {
            PermanentUI.perm.rotationspeed = -45;


        }

        if (collision.tag == "Slope2")
        {
            PermanentUI.perm.rotationspeed = 45;

        }

        if (collision.tag == "SlopeReset")
        {
            PermanentUI.perm.rotationspeed = 0;

        }

        if (collision.tag == "Tornado")
        {
            GetComponent<Rigidbody2D>().gravityScale = -0.4f;
            StartCoroutine(TornadoFunction());
            //anim.SetBool("grind", false);
        }


        if (collision.tag == "Shop2")
        {
            GetComponent<SpriteRenderer>().color = Color.black;

            //anim.SetBool("grind", false);
        }

        if (collision.tag == "Grind")
        {
            anim.SetBool("grind", true);
            state = State.grind;

            //anim.SetBool("grind", false);
        }

        //First grind

        if (collision.tag == "Default")
        {
            anim.SetBool("grind", false);
        }

        //Grind two

        if (collision.tag == "Grind2")
        {
            anim.SetBool("grind2", true);
            state = State.grind2;

            //anim.SetBool("grind", false);
        }


        if (collision.tag == "Grind2Reset")
        {
            anim.SetBool("grind2", false);
        }

        //Third grind

        if (collision.tag == "Grind3")
        {
            anim.SetBool("grind3", true);
            state = State.grind3;

            //anim.SetBool("grind", false);
        }

        if (collision.tag == "Grind3Reset")
        {
            anim.SetBool("grind3", false);
        }

        if (collision.tag == "Collectable")
        {
            
            coin.Play();
            GameObject expl = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(expl, 1); // delete the explosion after 3 seconds

            PermanentUI.perm.coins += 1;
            PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
        }

        if (collision.tag == "Powerup")
        {
            Destroy(collision.gameObject);
            PermanentUI.perm.jumpForce = 15f;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }

        if (collision.tag == "Powerup2")
        {
            Destroy(collision.gameObject);
            ScaleToTarget(new Vector3(0.5f, 0.3f, 1f), 1f);
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }

        if (collision.tag == "Powerup3")
        {
            Destroy(collision.gameObject);
            ScaleToTarget(new Vector3(2.5f, 2.5f, 1f), 1f);
            PermanentUI.perm.jumpForce = 15f;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }

        if (collision.tag == "Powerup4")
        {
            Destroy(collision.gameObject);
            ScaleToTarget(new Vector3(0.2f, 1f, 1f), 1f);
            PermanentUI.perm.jumpForce = 15f;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }

        if (collision.tag == "Powerup5")
        {
            Destroy(collision.gameObject);
            //ScaleToTarget(new Vector3(1f, 1f, 10f), 1f);
            PermanentUI.perm.speed = 25f;
            //jumpForce = 15f;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }

        if (collision.tag == "Powerup6")
        {
            Destroy(collision.gameObject);
            ScaleToTarget(new Vector3(0.1f, 0.1f, 0.1f), 1f);
            //PermanentUI.perm.jumpForce = 15f;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        

        if(other.gameObject.tag == "Enemy")
        {
            enemy enemy = other.gameObject.GetComponent<enemy>();
            if(state == State.jumping)
            {
                enemy.JumpedOn();
                //Destroy(other.gameObject);
                Jump();
            }
            else
            {
                state = State.hurt;
                HandleHealth();
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //right
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    //left
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
        }

        
    }

    private void HandleHealth()
    {
        PermanentUI.perm.health -= 1;
        PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
        if (PermanentUI.perm.health <= 0)
        {
            PermanentUI.perm.Reset();
            SceneManager.LoadScene(sceneName);
        }
    }

    private void Movement()
    {
        float hDirection = PermanentUI.perm.joystick.Horizontal * PermanentUI.perm.speed;

        /*for(int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPosition);
        }*/

        float verticalMove = PermanentUI.perm.joystick.Vertical;


        //moving left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-PermanentUI.perm.speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        //moving right
        else if (hDirection > 0)
        {
            
            rb.velocity = new Vector2(PermanentUI.perm.speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            //PermanentUI.perm.rotationspeed = 0;
        }

        //jumping
        if (verticalMove >= .1f && coll.IsTouchingLayers(ground))
        {
            Jump();
        }

        
    }

    private void Jump()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, PermanentUI.perm.jumpForce);
        state = State.jumping;
        
    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
            else if(state == State.falling)
            {
                if(coll.IsTouchingLayers(ground))
                {
                    state = State.idle;
                }
            }
        }

        else if(state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }

        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            //moving
            state = State.running;
        }
        
        else
        {
            state = State.idle;
        }

    }

    private void Footstep()
    {
        footstep.Play();
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(3);
        PermanentUI.perm.jumpForce = 9f;
        GetComponent<SpriteRenderer>().color = Color.white;
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

    private IEnumerator RainbowColor()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.magenta;
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (10f * t - 15f) + 20f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        yield return null;
    }
}
