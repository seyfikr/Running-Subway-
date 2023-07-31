using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject Continue;
    RoAd1 RoAd1;
    public GameObject Pause, Countiunee, Charecter, StopPanel,heroButton,levelUpButton;
   
    void Start()
    {
        Time.timeScale = 0;
        Continue.SetActive(true);
        RoAd1 = GetComponent<RoAd1>();
        Pause.SetActive(false);
        Countiunee.SetActive(false);
        StopPanel.SetActive(false);
      
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        Continue.SetActive(false);
        Pause.SetActive(true);
        Charecter.SetActive(false);
        StopPanel.SetActive(false);
        heroButton.SetActive(false);
        levelUpButton.SetActive(false);

    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
        RoAd1.planenumber = 0;
        RoAd1.planetransformnumber = 0;
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        Pause.SetActive(false);
        Countiunee.SetActive(true);
        StopPanel.SetActive(true);
    }
    public void Eexit()
    {
        Application.Quit();
    }
}
   