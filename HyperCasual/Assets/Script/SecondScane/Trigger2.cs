using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    
    
    int gold=0;
    Trigger triger;
    public bool isMagnet = false;
    public GameObject Clock;
    mobilControl2 mobilcont;
    public GameObject Character;
    float volume = 0.09f;
    public AudioClip GoldVoice;

    //public int TopGold=0;
    [SerializeField] private TMP_Text GoldText, GoldText2;
    AudioSource aSource;
    LeanTweenScript leantwen;
    Move Move;
    MobileControl MobileControl;
    public Collider Collider;
    public Rigidbody Rigidbody;
    Animator anim;
    int currentTopGold;

    Butons2 btn2;
    public object TopGold { get; private set; }

    public void Start()
    {
        GameObject gameManager = GameObject.Find("GameMeneger2");
        btn2 = gameManager.GetComponent<Butons2>();
        
        //btn2 = GetComponent<Butons2>();
        Rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
        mobilcont = GetComponent<mobilControl2>();
        anim = GetComponent<Animator>();
        triger=GetComponent<Trigger>();
        aSource = GetComponent<AudioSource>();
        leantwen = GetComponent<LeanTweenScript>();
        Move = GetComponent<Move>();
        gold = PlayerPrefs.GetInt(nameof(gold));
        if (leantwen == null)
        {
            Debug.Log("leantwen is null");
        }
        currentTopGold=btn2.goldd ;
    }

    public void Update()
    {
        
        GoldText.text = "Kazanýlan Altýn:" + " " + currentTopGold.ToString();
        GoldText2.text = "Kazanýlan Altýn:" + " " + currentTopGold.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            //Time.timeScale = 0;
            //sahan.SetActive(true);
            
            mobilcont.moveSpeed = 0; mobilcont.gravityScale = 0; mobilcont.jumpSpeed = 0;
            anim.SetBool("Fall", true);
            leantwen.GameOverTrigger();
            mobilcont.die = true;


        }
        if (other.tag == "Gold")
        {
            currentTopGold = PlayerPrefs.GetInt(nameof(TopGold));
            currentTopGold++; // Deðeri artýr

            PlayerPrefs.SetInt(nameof(TopGold), currentTopGold); // Artýrýlmýþ deðeri kaydet
            PlayerPrefs.Save();
            
            PlayerPrefs.SetInt(nameof(gold), gold);

            AudioSource.PlayClipAtPoint(GoldVoice, transform.position, volume);

            Destroy(other.gameObject);


        }
        if (other.tag == "clock")
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
        isMagnet = false;
    }
}
