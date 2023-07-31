using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MobileControl : MonoBehaviour
{
    public float minSwipeDistance = 50f;
    int Score;
    [SerializeField] private TMP_Text ScoreText,ScoreText2;
  
    private bool isSwipe = false;
    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;
    private Rigidbody rb;
    [SerializeField] public float moveSpeed = 200;
    public float jumpSpeed = 45f;
    public float gravityScale = 270f;
    private float slideSpeed = 53f;
    private int laneIndex = 0;
    Animator anim;
    private Spawner spawner;
    public AudioClip JumpVoice;
    AudioSource aSource;
    float volume = 0.8f;
    public bool die=false;
   

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        spawner = GetComponent<Spawner>();
        Score = 0;
        aSource = GetComponent<AudioSource>();
        

    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Force);
        rb.AddForce(Physics.gravity * gravityScale * Time.fixedDeltaTime, ForceMode.Force);
        if (moveSpeed > 150 && moveSpeed < 230)
        {
            Score++;
        }
        if (moveSpeed > 230 && moveSpeed < 280)
        {
            Score += 2;
        }
        if (moveSpeed > 280 && moveSpeed < 350)
        {
            Score += 3;
        }
        if (moveSpeed > 350)
        {
            Score += 4;
        }
        ScoreText.text = "Score:" + " " + Score.ToString();
        ScoreText2.text = "Score:" + " " + Score.ToString();
        if (Score > 1500)
        {
            SceneManager.LoadScene(1);
            Debug.Log("sa");
        }

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
               

                // Set swipe start position
                isSwipe = true;
                swipeStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isSwipe)
            {
                // Set swipe end position
                swipeEndPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended && isSwipe)
            {
                // Calculate swipe distance and direction
                float swipeDistance = Vector2.Distance(swipeStartPosition, swipeEndPosition);
                if (swipeDistance > minSwipeDistance)
                {
                    if (die == false)
                    {
                        Vector2 swipeDirection = swipeEndPosition - swipeStartPosition;
                        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                        {
                            // Horizontal swipe
                            if (swipeDirection.x > 0)
                            {
                                // Right swipe

                                if (laneIndex != 1)
                                {
                                    rb.AddForce(Vector3.right * slideSpeed, ForceMode.Impulse);
                                    laneIndex++;
                                    moveSpeed += 5;
                                    AudioSource.PlayClipAtPoint(JumpVoice, transform.position, volume);



                                }
                            }
                            else
                            {
                                // Left swipe

                                if (laneIndex != -1)
                                {
                                    rb.AddForce(Vector3.left * slideSpeed, ForceMode.Impulse);
                                    laneIndex--;
                                    moveSpeed += 5;
                                    AudioSource.PlayClipAtPoint(JumpVoice, transform.position, volume);

                                }
                            }
                        }
                        else
                        {
                            // Vertical swipe
                            if (swipeDirection.y > 0 && rb.velocity.y == 0f)
                            {
                                // Up swipe
                                
                                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                                StartCoroutine(jump());
                                
                                AudioSource.PlayClipAtPoint(JumpVoice, transform.position, volume);
                            }
                            else if (swipeDirection.y < 0 && rb.velocity.y == 0f)
                            {
                                // Down swipe

                                rb.AddForce(Vector3.down * jumpSpeed, ForceMode.Impulse);
                                StartCoroutine(loop());
                            }
                            


                        }
                    }
                    
                }

                isSwipe = false;
                swipeStartPosition = swipeEndPosition = Vector2.zero;
            }
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
