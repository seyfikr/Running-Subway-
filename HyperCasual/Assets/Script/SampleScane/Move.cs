using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float moveSpeed = 200;
    private float jumpSpeed = 45f;
    private float gravityScale = 270f;
    private float slideSpeed = 55f;
    private int laneIndex = 0;
    Animator anim;
     private Spawner spawner;
    [SerializeField] private TMP_Text ScoreText,ScoreText2;
    int Score;
    public AudioClip JumpVoice;
    AudioSource aSource;
    float volume = 0.4f;
   
    void Awake()
    {
        aSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
       spawner = GetComponent<Spawner>();
       
        Score = 0;
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Force);
        rb.AddForce(Physics.gravity * gravityScale * Time.fixedDeltaTime, ForceMode.Force);
        if (moveSpeed > 150 && moveSpeed < 230){
            Score++;
        }
        if (moveSpeed > 230 && moveSpeed < 280)
        {
            Score+=2;
        }
        if (moveSpeed > 280 && moveSpeed < 350)
        {
            Score += 3;
        }
        if (moveSpeed > 350)
        {
            Score += 4;
        }
        ScoreText.text = "Score:" +" "+ Score.ToString();
        ScoreText2.text = "Score:" + " " + Score.ToString();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0f)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            StartCoroutine(jump());
            AudioSource.PlayClipAtPoint(JumpVoice, transform.position, volume);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (laneIndex != -1)
            {
                rb.AddForce(Vector3.left * slideSpeed, ForceMode.Impulse);
                laneIndex--;
                moveSpeed += 5;
                AudioSource.PlayClipAtPoint(JumpVoice, transform.position, volume);

            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (laneIndex != 1)
            {
                rb.AddForce(Vector3.right * slideSpeed, ForceMode.Impulse);
                laneIndex++;
                moveSpeed += 5;
                AudioSource.PlayClipAtPoint(JumpVoice, transform.position, volume);
            }

        }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(Vector3.down * jumpSpeed, ForceMode.Impulse);
                StartCoroutine(loop());
            }   
    }
    IEnumerator jump()
    {
        anim.SetBool("jump", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("jump", false);
    }
    IEnumerator loop()
    {
        anim.SetBool("loop", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("loop", false);
    }
}