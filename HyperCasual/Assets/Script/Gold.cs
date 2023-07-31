using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gold : MonoBehaviour
{
    public Transform karakter; // Karakterin Transform bile�eni
    public Transform karakter2; // Karakterin Transform bile�eni

    public float GoldSpeed = 10f; // M�knat�s�n g�c�
    public float GoldSpeed2 = 18f;
    private bool scene1=false;
    private void Start()
    {
        GameObject karakterObjesi = GameObject.FindGameObjectWithTag("Player"); // "KarakterTag" yerine karakterin etiketini kullan�n
        if (karakterObjesi != null)
        {
            karakter = karakterObjesi.transform;
            karakter2 = karakterObjesi.transform;
        }
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "LunarLandscape3D")
        {
            scene1 = true;
        }

    }
    private void FixedUpdate()
    {
        if (scene1 == false)
        {

            if (karakter.GetComponent<Trigger>().isMagnet)
            {
                float mesafe = Vector3.Distance(transform.position, karakter.position);

                // M�knat�s�n etkisi alt�ndaki alt�nlar� hareket ettirin
                if (mesafe <= GoldSpeed)
                {
                    Vector3 yon = (karakter.position - transform.position).normalized;
                    //GetComponent<Rigidbody>().AddForce(yon * mknatisGucu);
                    transform.Translate(yon * GoldSpeed * Time.deltaTime, Space.World);

                }
            }
            if (karakter2.GetComponent<Trigger>().isMagnet)
            {
                float mesafe = Vector3.Distance(transform.position, karakter2.position);

                // M�knat�s�n etkisi alt�ndaki alt�nlar� hareket ettirin
                if (mesafe <= GoldSpeed)
                {
                    Vector3 yon = (karakter2.position - transform.position).normalized;
                    //GetComponent<Rigidbody>().AddForce(yon * mknatisGucu);
                    transform.Translate(yon * GoldSpeed * Time.deltaTime, Space.World);

                }
            }
        }
        if (scene1 == true)
        {
            if (karakter.GetComponent<Trigger2>().isMagnet)
            {
                float mesafe = Vector3.Distance(transform.position, karakter.position);

                // M�knat�s�n etkisi alt�ndaki alt�nlar� hareket ettirin
                if (mesafe <= GoldSpeed)
                {
                    Vector3 yon = (karakter.position - transform.position).normalized;
                    //GetComponent<Rigidbody>().AddForce(yon * mknatisGucu);
                    transform.Translate(yon * GoldSpeed2 * Time.deltaTime, Space.World);

                }
            }
        }
    }

}
