using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me : MonoBehaviour
{
    static float nowSpeed;
    static float nowdropSpeed;
    static Vector2 moving;
    const float jumpSpeed = 15f;
    const float minSpeed =2f;
    const float maxSpeed = 10f;
    const float maxdropSpeed = 20f;
    const int dir_rotation = -90;
    static float timer;
    static bool isGround;
    static bool isWall;
    static readonly Vector2 checksize = new Vector2(0.5f, 0.8f);
    static bool isJump;
    static Vector2 face=Vector2.right;
    static Vector2 gravity = Vector2.down;
    static int dir = 0;
    static readonly Vector3 rotate = Vector3.back * 90;
    public static Rigidbody2D body;
    static Transform _trans;
    public static int Groundlayer ;

    void Awake()
    {
        nowSpeed = minSpeed;
        moving = face*nowSpeed;
        _trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        body.velocity = moving;
        Groundlayer = LayerMask.NameToLayer("Ground");
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(body.position + gravity*0.25f, checksize, dir_rotation * (dir+1), 1 << Groundlayer);
        isWall = Physics2D.OverlapBox(body.position+ face * 0.25f, checksize, dir_rotation * dir, 1 << Groundlayer);
        if (!isGround)
        {
            if(dir == 0 || dir == 2)
            {
                nowdropSpeed = body.velocity.y;
                if(nowdropSpeed < maxdropSpeed && nowdropSpeed > -maxdropSpeed)
                    nowdropSpeed +=  gravity.y ;
                moving.y =  nowdropSpeed;
                moving.x = 0;
            }
            else
            {
                nowdropSpeed = body.velocity.x;
                if (nowdropSpeed < maxdropSpeed && nowdropSpeed > -maxdropSpeed)
                    nowdropSpeed += gravity.x ;
                moving.x =  nowdropSpeed;
                moving.y = 0;
            }

        }
        else if (isJump)
        {
            moving.x = -gravity.x * jumpSpeed;
            moving.y = -gravity.y * jumpSpeed;
            isJump = false;
        }
        else moving = Vector2.zero;
        if (!isWall)
        {
            moving.x += nowSpeed * face.x;
            moving.y += nowSpeed * face.y;
        }

        if (nowSpeed > minSpeed && Time.time > timer) {
            nowSpeed-= 1f;
            timer = Time.time + 2;
        }
        
        body.velocity = moving;
    }
    public static void Jump()
    {
        if (Control.Me_up && isGround) isJump = true;
    }
    public static void Dash()
    {
        if (!Control.Me_up && !Control.Me_down) {
            timer = Time.time + 2;
            if(nowSpeed<maxSpeed)nowSpeed+=1f;
        }
    }
    public static void ChangeDir()
    {
        if (!Control.Me_down) return;

        _trans.Rotate(rotate);
        ++dir;
        dir %= 4;
        switch (dir)
        {
            case 0:
                 face = Vector2.right;
                 gravity = Vector2.down;
                break;
            case 1:
                face = Vector2.down;
                gravity = Vector2.left;
                break;
            case 2:
                face = Vector2.left;
                gravity = Vector2.up;
                break;
            case 3:
                face = Vector2.up;
                gravity = Vector2.right;
                break;
        }
    }
    const string Untouchable = "Untouchable";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Untouchable))
        {
            Control.game_over.Appear(true);
            Destroy(gameObject);
        }
    }
}
