using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] public float speed;

    [SerializeField] public UnityEngine.Object heart1;

    [SerializeField] public UnityEngine.Object heart2;

    [SerializeField] public UnityEngine.Object heart3;

    [SerializeField] public UnityEngine.Object gracz;

    private Rigidbody2D body;

    private SpriteRenderer sprite;

    private Animator anim;

    private bool ground;

    private int zliczanie;

    private bool die;

    private bool win;

    private bool attack;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        die = false;
        win = false;
        //attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("ground",ground);
        anim.SetBool("die",die);
        anim.SetBool("win",win);
        anim.SetBool("attack",attack);
        anim.SetBool("run",Input.GetAxis("Horizontal") != 0);

        if(die == false && win == false)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);
        }
        
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            if(die == true)
            {
                transform.localScale = new Vector3(2,2,1);
            }
            else
            {
                transform.localScale = new Vector3(5,5,1);
            }
            
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            if (die == true)
            {
                transform.localScale = new Vector3(2,2,1);
            }
            else
            {
                transform.localScale = new Vector3(-5,5,1);
            }
        }

        //if (Input.GetKey(KeyCode.Space))
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(die == false && win == false)
            {
                Jump();
            }
        }

        switch(zliczanie)
        {
            case 1:
                Destroy(heart1);
                break;
            case 2:
                Destroy(heart2);
                break;
            case 3:
                Destroy(heart3);
                break;
            default:
                break;
        }

        if (Input.GetKey("z"))
        {
            attack = true;
            
        }
    }

    private void Jump()
    {
        if (ground != false)
        {
            body.velocity = new Vector2(body.velocity.x,speed);
        }
        ground = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            ground = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            zliczanie ++;
            StartCoroutine(Invulnerbility());
            if (zliczanie == 3)
            {
                die = true;
            }

        }
        else if (collider.gameObject.tag == "trap")
        {
            die =true;
            zliczanie = 3;
            Destroy(heart1);
            Destroy(heart2);
            Destroy(heart3);
        } else if (collider.gameObject.tag == "finish")
        {
            win = true;
        }
    }

    private IEnumerator Invulnerbility()
    {
        if (zliczanie < 3)
        {
            sprite.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(1);
            sprite.color = Color.white;
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator attack_animations()
    {
        if(attack != false)
        {
            yield return new WaitForSeconds(1);
            attack = false;
        }
    }
}