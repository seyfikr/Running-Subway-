using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Trigger : MonoBehaviour
{

    public GameObject Clock;
    MobileControl mobilcont;
    public GameObject Character;
    float volume = 0.09f;
    public AudioClip GoldVoice;
    public GameObject sahan;
    public  int TopGold=0;
    [SerializeField] private TMP_Text GoldText,GoldText2;
    AudioSource aSource;
    LeanTweenScript leantwen;
    Move Move;
    MobileControl MobileControl;
    public Collider Collider;
    public Rigidbody Rigidbody;
    public bool isMagnet = false;
    
    Animator anim;
    public void Start()
    {

        Rigidbody = GetComponent<Rigidbody>();
        Collider= GetComponent<Collider>();
        mobilcont = GetComponent<MobileControl>();
        anim = GetComponent<Animator>();
        
        aSource = GetComponent<AudioSource>();
        leantwen = GetComponent<LeanTweenScript>();
        Move= GetComponent<Move>();
        MobileControl= GetComponent<MobileControl>();
        if (leantwen == null)
        {
            Debug.Log("leantwen is null");
        }
        
        TopGold = PlayerPrefs.GetInt(nameof(TopGold));

    }
    


    public void Update()
    {
        GoldText.text = "Kazanýlan Altýn:"+" "+ TopGold.ToString();
        GoldText2.text = "Kazanýlan Altýn:"+" "+ TopGold.ToString();
        
    }

    public void OnTriggerEnter(Collider other)
    {
     
        if (other.tag == "Enemy")
        {
            //Time.timeScale = 0;
            //sahan.SetActive(true);
            Move.moveSpeed = 0;
            MobileControl.moveSpeed = 0; MobileControl.gravityScale = 0; MobileControl.jumpSpeed = 0;
            anim.SetBool("Fall", true);
            leantwen.GameOverTrigger();
            mobilcont.die = true;


        }
        if (other.tag == "Gold")
        {
        
            TopGold++;
            PlayerPrefs.SetInt(nameof(TopGold),TopGold);
            PlayerPrefs.Save();

            AudioSource.PlayClipAtPoint(GoldVoice,transform.position,volume);

            Destroy(other.gameObject);


        }
        if(other.tag == "clock")
        {
            StartCoroutine(noneCollider());
            Destroy(other.gameObject);
        }
        if (other.tag == "magnet")
        {
            //isMagnet = true;
            StartCoroutine(magnetTime());
            Destroy(other.gameObject);
        }
    }
    IEnumerator noneCollider()
    {
        Clock.SetActive(true);
        Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        Collider.enabled = false;
        yield return new WaitForSeconds(10f);
        Clock.SetActive(false);
        Rigidbody.freezeRotation = true;
        Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;

        Collider.enabled = true;
    }
    IEnumerator magnetTime()
    {
        isMagnet = true;
        yield return new WaitForSeconds(10f);
        isMagnet=false;
    }
}
