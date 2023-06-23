using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animator;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    public ParticleSystem explosionPlayer;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float speed;
    public float jumpForce;
    public bool isGround = true;
    public bool gameOver=false;
    public float gravityModifier;
    public Joystick joystick;



    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier;
        animator=GetComponent<Animator>();  
        playerAudio = GetComponent<AudioSource>();  
        
        
    }

    void Update()
    {
        Move();

        //if (Input.GetKeyDown(KeyCode.Space) && isGround)
        //{
        //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //    isGround = false;
        //    animator.SetBool("Jump", true);
        //    dirtSplatter.Stop();
        //    playerAudio.PlayOneShot(jumpSound, 1.0f);

        //}

        if (isGround==true)
        {
            animator.SetBool("Jump", false);
        }


        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
 
    }

    public void Move()
    {
        
        
        if (gameOver == false)
        {
            float Vertical = joystick.Vertical;
            float Horizontal = joystick.Horizontal;

            animator.SetFloat("V", Vertical);
            animator.SetFloat("H", Horizontal);


            Vector3 movemnet = new Vector3(Horizontal, 0, Vertical);
            transform.Translate(movemnet * Time.deltaTime * speed); 


            if (Vertical > 0)
            {
                if (!dirtSplatter.isPlaying) dirtSplatter.Play();
            }

            else if (Vertical == 0)
            {
                dirtSplatter.Stop();   
            }

        }
        
    }

    public void Jump()
    {
        if (isGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("Jump", true);
            isGround = false;
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("obstacle"))

        {
            
            animator.SetBool("Dying",true);
            isGround=false;
            gameOver = true;
            StartCoroutine(Wait(4f));
            explosionPlayer.Play();
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
            

        }

        else
        {
            animator.SetBool("Dying", false);
        }
       
        
    }

    public IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(4);
    }

}
