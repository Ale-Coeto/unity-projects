using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controlar eventos relacionados al personaje
public class PlayerControl : MonoBehaviour
{
    //Variables
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rig;
    public SpriteRenderer sr;
    private bool inPlatform = false;
    private bool crash = false;
    private bool floor = true;

    Animator animatorController;

    //Obtener la animacion
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    // Al terminar una colision, actualizar las variables de si dejó el piso o una plataforma
    private void OnCollisionExit2D(Collision2D collision)
    {
        crash = false;
        if (collision.gameObject.CompareTag("MainPlatform"))
        {
            floor = false;
            inPlatform = false;
        }

        if (collision.gameObject.CompareTag("Platform") && !floor)
        {

            inPlatform = false;
        }
        
    }

    // Checar si toca el piso o una plataforma 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MainPlatform"))
        {
            floor = true;
            inPlatform = true;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
                inPlatform = true;
        }

        // Checar si la colision fue horizontal (pared -> que no se atore)
        crash = false;
        Vector3 collisionNormal = collision.contacts[0].normal;

        if (Mathf.Abs(collisionNormal.y) < 0.1f)
        {
            crash = true;
        }
    }

    // Checar inputs para saltar o reiniciar el juego
    void Update()
    {
        Debug.Log(inPlatform);
        if (Input.GetKeyDown(KeyCode.UpArrow) && (inPlatform || floor))
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

    // Checar input para movimiento horizontal (si hubo una colision horizontal, no se atora)
    public void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        if (crash)
        {
            return;
        }

        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);
        if (xInput != 0 && rig.velocity.y == 0)
        {
            UpdateAnimation(PlayerAnimation.walk);
        }
        else
        {
            UpdateAnimation(PlayerAnimation.idle);
        }


        // Hacer que nina se gire
        if (rig.velocity.x > 0)
        {
            sr.flipX = false;
        }

        else if (rig.velocity.x < 0)
        {
            sr.flipX = true;
        }
    }

    // Animaciones
    public enum PlayerAnimation
    {
        idle, walk, jump
    }

    // Actualizar la animacion
    void UpdateAnimation(PlayerAnimation nameAnimation)
    {
        switch (nameAnimation)
        {
            case PlayerAnimation.idle:
                animatorController.SetBool("isWalking", false);
                animatorController.SetBool("isJumping", false);
                break;
            case PlayerAnimation.walk:
                animatorController.SetBool("isWalking", true);
                animatorController.SetBool("isJumping", false);
                break;
            case PlayerAnimation.jump:
                animatorController.SetBool("isWalking", false);
                animatorController.SetBool("isJumping", true);
                break;
        }
    }
}
