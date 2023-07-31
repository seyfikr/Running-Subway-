using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RoAd1 : MonoBehaviour
{

    public GameObject plane1, plane2;
    public static int planenumber;
    public static int planetransformnumber;
    public Transform Player;
    public void Start()
    {
        planenumber = 0; planetransformnumber = 0;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Character"))
        {
           
            planenumber++;
            planetransformnumber++;

            if (planetransformnumber>1 && planenumber % 2 != 0)
            {
                //zpos2 += 1678.6f;
                plane2.transform.position = new Vector3(-0.2286f, -0.30999f,Player.transform.position.z+960.6f);

            }
             if (planetransformnumber > 1 && planenumber % 2 == 0)
            {
                
     
                //zpos1+= 1678.6f;
                plane1.transform.position = new Vector3(-0.2286f, -0.30999f, Player.transform.position.z + 1020.6f);
    
            }
            //else if (key3==true  )
            //{
              
            //} 
            //else if( key4==true )
            //{
            //    zpos3 += 1259.5f;
            //    plane3.transform.position = new Vector3(-0.2286f, -0.30999f, zpos3);
            //    key4 = false;key2 = true;
            //    Debug.Log(zpos3);
            //    Debug.Log("as");
            //}
           
        }
        //IEnumerator waitforsecond()
        //{
        //    yield return new WaitForSeconds(1);
        //    zpos += 1259.5f;
        //}
    }
}
