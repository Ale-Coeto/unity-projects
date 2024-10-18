using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Script to control events related to the player
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rig;
    public SpriteRenderer sr;
    private bool inPlatform = true;

    Animator animatorController;

    //Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inPlatform = false;

        if (collision.gameObject.CompareTag("EditorOnly"))
        {
            inPlatform = true;
        }
        // On collision with bird
        if (collision.gameObject.CompareTag("PlatformFall"))
        {
            // Destroy bird and add points
            GameObject.Destroy(collision.gameObject);
            //GameControl.Instance.uiController.AddPoints(points);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inPlatform = true;
        if (collision.gameObject.CompareTag("Bounds"))
        {
            inPlatform = false;
        }
        
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameControl.Instance.RestartScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inPlatform);
        if (Input.GetKeyDown(KeyCode.UpArrow) && inPlatform)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (rig.velocity.y != 0)
            {
                UpdateAnimation(PlayerAnimation.jump);
            }

            

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameControl.Instance.RestartScene();
        }

    }

    public void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);
        if (xInput != 0 && rig.velocity.y == 0)
        {
            UpdateAnimation(PlayerAnimation.walk);
        } else
        {
            UpdateAnimation(PlayerAnimation.idle);
        }

        if (rig.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1);
        }
        else if (rig.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1);
        }

    }

    public enum PlayerAnimation
    {
        idle, walk, jump
    }

    void UpdateAnimation(PlayerAnimation nameAnimation)
    {
        switch(nameAnimation)
        {
            case PlayerAnimation.idle:
                animatorController.SetBool("isWalking", false);
                animatorController.SetBool("isJumping", false);
                break;

            case PlayerAnimation.jump:
                animatorController.SetBool("isJumping", false);
                animatorController.SetBool("isJumping", true);
                break;

            case PlayerAnimation.walk:
                animatorController.SetBool("isWalking", true);
                animatorController.SetBool("isJumping", false);
                break;

        }
    }
}
