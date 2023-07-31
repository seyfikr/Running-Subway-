using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenScript : MonoBehaviour
{
   
    public GameObject gameoverText,gameoverPanel;
    //Trigger Trigger;
    //public void Start()
    //{
    //    Trigger = GetComponent<Trigger>();
    //}
    //public void Update()
    //{
    //    if (Trigger.Die == true)
    //    {
    //        GameOverTrigger();
    //    }
    //}
    public void GameOverTrigger()
    {
        LeanTween.scale(gameoverText, new Vector3(1.5f, 1.5f, 1.5f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(gameoverText, new Vector3(350f, 1000f, 0f), 0.7f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(gameoverText, new Vector3(1f, 1f, 1f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.moveLocal(gameoverText, new Vector3(0f, 1000f, 0f), 0.7f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(gameoverPanel, new Vector3(1f, 1f, 1f), 1.5f).setDelay(1.5f).setEase(LeanTweenType.easeOutCirc);
        //LeanTween.moveLocal(gameoverPanel, new Vector3(0f, -336f, 0f), 0.7f).setDelay(3.5f).setEase(LeanTweenType.easeInOutCirc);
    }
   
   
}
