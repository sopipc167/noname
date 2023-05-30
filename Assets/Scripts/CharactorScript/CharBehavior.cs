using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharBehavior : MonoBehaviour
{
    int speed = 5;
    public int health = 200;
    public int stm = 100;
    int atk = 10;
    Rigidbody2D rid;
    SpriteRenderer rend;
    Vector2 speedvec;
    PhotonView v;
    public GameObject canvas;
    bool runnAble;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        runnAble = true;
        rid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        rid.velocity = Vector2.zero;
        speedvec = new Vector2(0, 0);
        v = GetComponent<PhotonView>();
        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<UIcontroller>().setPlayer(this.gameObject);
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GetComponentsInChildren<BoxCollider2D>()[1]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(v.IsMine)
        {
            speedvec = Vector2.zero;
            if (Input.GetKey(KeyCode.S) && runnAble)
            {
                speed = 10;
                stm -= 2;
                if (stm<1)
                {
                    StartCoroutine(waitForRun());
                }
            }
            else if (stm<100)
            {
                speed = 5;
                stm += 3;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speedvec.x = -speed;
                anim.SetBool("isMoving", true);
                anim.SetInteger("movDir", 1);
                rend.flipX = false;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("isMoving", false);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speedvec.x = speed;
                anim.SetBool("isMoving", true);
                anim.SetInteger("movDir", 1);
                rend.flipX = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("isMoving", false);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speedvec.y = speed;
                anim.SetBool("isMoving", true);
                anim.SetInteger("movDir", 2);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetBool("isMoving", false);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                speedvec.y = -speed;
                anim.SetBool("isMoving", true);
                anim.SetInteger("movDir", 0);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("isMoving", false);
            }
            rid.velocity = speedvec;
        }
    }
    IEnumerator waitForRun()
    {
        speed = 5;
        runnAble = false;
        yield return new WaitForSeconds(1.0f);
        runnAble = true;
    }
}
