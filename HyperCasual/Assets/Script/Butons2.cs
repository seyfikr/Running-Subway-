using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class Butons2 : MonoBehaviour
{
    mobilControl2 mblcnt2;
    mobilControl2 mblcnt21;
    mobilControl2 mblcnt22;
    public Image[] images;
    public float imageDelay = 1f;
    private int currentIndex = 0;
    private Coroutine sequenceCoroutine;
    public Image[] images2;
    public float imageDelay2 = 1f;
    private int currentIndex2 = 0;
    private Coroutine sequenceCoroutine2;
    int fastSlidercount;
    public int goldd=0;
    [SerializeField]
    private TMP_Text goldText,goldText2;
    public GameObject heroPanel,levelPanel;
    public GameObject hero1,hero2,hero3,buy1,buy2,sec1,sec2;
    Trigger2 triger2;
    public object TopGold { get; private set; }



    void Start()
    {
        

        GameObject gameManager = GameObject.FindWithTag("Player");
        
        mblcnt2 = gameManager.GetComponent<mobilControl2>();
        
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }
        foreach (Image image in images2)
        {
            image.gameObject.SetActive(false);
        }
        
        
        goldd = PlayerPrefs.GetInt(nameof(TopGold));
        heroPanel.SetActive(false);
        triger2 = GetComponent<Trigger2>();


    }
    public void OnButtonClickedincrase()
    {
        if (goldd > 50)
        {
            if (currentIndex < images.Length)
            {
                images[currentIndex].gameObject.SetActive(true);
                currentIndex++;
            }
            goldd -= 50;
            mblcnt2.moveSpeed += 10;
           
        }

    }
    public void OnButtonClickedincrase2()
    {
        if (goldd > 75)
        {
            if (currentIndex2 < images2.Length)
            {
                images2[currentIndex2].gameObject.SetActive(true);
                currentIndex2++;
            }
            goldd -= 75;
            mblcnt2.jumpSpeed += 5;
            
        }

    }
    public void OnButtonClickeddecrease()
    {
        mblcnt2.moveSpeed -= 10;
        if (sequenceCoroutine != null)
        {
            StopCoroutine(sequenceCoroutine);
        }

        if (currentIndex > 0)
        {
            currentIndex--;
            images[currentIndex].gameObject.SetActive(false);
        }


    }
    public void OnButtonClickeddecrease2()
    {
        mblcnt2.jumpSpeed -= 5;

        if (sequenceCoroutine2 != null)
        {
            StopCoroutine(sequenceCoroutine2);
        }

        if (currentIndex2 > 0)
        {
            currentIndex2--;
            images2[currentIndex2].gameObject.SetActive(false);
        }


    }
    void Update()
    {
        //fastSlider.value = fastSlidercount;
        //hero1.GetComponent<Trigger2>().TopGold = gold;
        //hero2.GetComponent<Trigger2>().TopGold = gold;
        //hero3.GetComponent<Trigger2>().TopGold = gold;
        
        goldText.text = "Altýn:" + " " + goldd.ToString();
        goldText2.text = "Altýn:" + " " + goldd.ToString();


    }
 

    public void HeroPanel()
    {
        heroPanel.SetActive(true);
    }
    public void HeroPanelExit()
    {
        heroPanel.SetActive(false);
        levelPanel.SetActive(false);
    }
    public void LevelPanel()
    {
        levelPanel.SetActive(true); 
    }
    public void Buy1()
    {
      hero1.SetActive(false);
      hero2.SetActive(true);
      hero3.SetActive(false);
      goldd -= 50;
      buy1.SetActive(false);
      sec1.SetActive(true); 
      
    }
    public void Buy2()
    {
        hero1.SetActive(false);
        hero2.SetActive(false);
        hero3.SetActive(true);
        goldd -= 75;
        buy2.SetActive(false);
        sec2.SetActive(true);
    }
    public void Sec1()
    {
        hero1.SetActive(false);
        hero2.SetActive(true);
        hero3.SetActive(false);
       
    }
    public void Sec2()
    {
        hero1.SetActive(false);
        hero2.SetActive(false);
        hero3.SetActive(true);

    }


}
