using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Zombie,Barricad,TrafficLamb, Cone,Car;
    public Transform Character;
    Move move;
    public  float SpawmDistance=70 ;
    System.Random random = new System.Random();
    void Start()
    {
        InvokeRepeating("ObjectClone", 0, 1.2f);
        move=GetComponent<Move>();   
    }  
    void ObjectClone()
    {
        
        int randomNumber =  random.Next(0, 100);
        int randomNumber2=  random.Next(0, 100);
        int randomNumber3 = random.Next(0, 100);
        int randomNumber4 = random.Next(0, 100);
        int randomNumber5= random.Next(0, 100);
        int randomNumber6= random.Next(0, 100);

        Debug.Log(randomNumber);
        if (randomNumber > 0 && randomNumber < 20 || randomNumber > 30 && randomNumber < 50 || randomNumber > 70 && randomNumber < 75
/*            || randomNumber2 > 0 && randomNumber2 < 20 || randomNumber2 > 30 && randomNumber2 < 50 || randomNumber2 > 70 && randomNumber2 < 75*/)
        {
            Clon(Zombie, -0.3f);

        }
        if (randomNumber > 20 && randomNumber < 30 || randomNumber > 50 && randomNumber < 70 || randomNumber > 90 && randomNumber < 100
/*            || randomNumber2 > 20 && randomNumber2 < 30 || randomNumber2 > 50 && randomNumber2 < 70 || randomNumber2 > 90 && randomNumber2 < 100*/)
        {
            BaricadClon(Barricad, 9f);

        }
        if (randomNumber > 75 && randomNumber < 90|| randomNumber2 > 75 && randomNumber2 < 90)
        {
            Clon(TrafficLamb, -0.3f);
        }
        if (randomNumber3 > 0 && randomNumber3 < 20 || randomNumber3 > 30 && randomNumber3 < 50 || randomNumber3 > 70 && randomNumber3 < 75
/*            || randomNumber4 > 0 && randomNumber4 < 20 || randomNumber4 > 30 && randomNumber4 < 50 || randomNumber4 > 70 && randomNumber4 < 75*/)
        {
            Clon(Zombie, -0.3f);

        }
        if (randomNumber3 > 20 && randomNumber3 < 30 || randomNumber3 > 50 && randomNumber3 < 70 || randomNumber3 > 90 && randomNumber3 < 100
/*            || randomNumber4 > 20 && randomNumber4 < 30 || randomNumber4 > 50 && randomNumber4 < 70 || randomNumber4 > 90 && randomNumber4 < 100*/)
        {
            BaricadClon(Barricad, -0.3f);

        }
        if (randomNumber3 > 75 && randomNumber3 < 90 || randomNumber4 > 75 && randomNumber4 < 90)
        {
            TrafficLambClon(TrafficLamb, -0.3f);
        }
        if (randomNumber5 < 60)
        {
            ConeClon(Cone, -0.3f);
        }
        if (randomNumber5 > 60)
        {
            TrafficLambClon(TrafficLamb,-0.3f);
        }
        if(randomNumber6 > 50)
        {
            ConeClon(Car, -0.3f);
        }
        
        
        if (randomNumber6 < 50)
        {
            ConeClon(Cone, -0.3f);
        }
    }

    public void Clon(GameObject Object, float y_coordinate)
    {
        GameObject NewClon = Instantiate(Object);
        //float rightcordinate = 4f;
        //float leftcordinate = -3.8f;
        //float middelecordinate = 0.06f;
        //int rastsayi = Random.Range(0, 100);
        int rastsayi = random.Next(0, 100);
        int ClonZombiePos= Random.Range(-4, 4);
        if (rastsayi < 30)
        {
            NewClon.transform.position = new Vector3(ClonZombiePos, y_coordinate, Character.position.z + SpawmDistance);
        }
        else if (rastsayi > 30&& rastsayi < 70)
        {
            NewClon.transform.position = new Vector3(ClonZombiePos, y_coordinate, Character.position.z + SpawmDistance);
        }
        else if ( rastsayi > 70)
        {
            NewClon.transform.position = new Vector3(ClonZombiePos, y_coordinate, Character.position.z + SpawmDistance);
        }
        Destroy(NewClon, 15f);
    
    }
  void BaricadClon(GameObject Object , float y_coordinate)    
    {
        float Barricadrightcordinate = 1;
        float Barricadleftcordinate = -3;
        GameObject NewClon = Instantiate(Object);
        int rastsayi = random.Next(0, 100);
        //int rastsayi = Random.Range(0, 100);

        if (rastsayi < 50)
        {
            NewClon.transform.position = new Vector3(Barricadrightcordinate, y_coordinate, Character.position.z + SpawmDistance);
        }
        else if (rastsayi > 50)
        {
            NewClon.transform.position = new Vector3(Barricadleftcordinate, y_coordinate, Character.position.z + SpawmDistance);
        }
    
        Destroy(NewClon, 15f);
    }
    void ConeClon(GameObject Object, float y_coordinate)
    {
        float Barricadrightcordinate = 2.77f;
        float Barricadleftcordinate = -5f;
        float BarricadMiddelecordinate = -1.26f;
        GameObject NewClon = Instantiate(Object);
        int rastsayi = random.Next(0, 100);
        //int rastsayi = Random.Range(0, 100);

        if (rastsayi < 30)
        {
            NewClon.transform.position = new Vector3(Barricadrightcordinate, y_coordinate, Character.position.z + SpawmDistance);
        }
        else if (rastsayi > 30&&rastsayi<60)
        {
            NewClon.transform.position = new Vector3(Barricadleftcordinate, y_coordinate, Character.position.z + SpawmDistance);
        }
        else if (rastsayi < 100&&rastsayi>60)
        {
            NewClon.transform.position = new Vector3(BarricadMiddelecordinate, y_coordinate, Character.position.z + SpawmDistance);
        }

        Destroy(NewClon, 15f);
    }
    void TrafficLambClon(GameObject Object, float y_coordinate)
    {
        float Barricadrightcordinate = 4.5f;
        float Barricadleftcordinate = -3f;
        float BarricadMiddelecordinate = 0.5f;
        GameObject NewClon = Instantiate(Object);
        int rastsayi = random.Next(0, 100);
        //int rastsayi = Random.Range(0, 100);

        if (rastsayi < 30)
        {
            NewClon.transform.position = new Vector3(Barricadrightcordinate, y_coordinate, Character.position.z + SpawmDistance);
        }
        else if (rastsayi > 30 && rastsayi < 60)
        {
            NewClon.transform.position = new Vector3(Barricadleftcordinate, y_coordinate, Character.position.z + SpawmDistance);
        }
        else if (rastsayi < 100 && rastsayi > 60)
        {
            NewClon.transform.position = new Vector3(BarricadMiddelecordinate, y_coordinate, Character.position.z + SpawmDistance);
        }

        Destroy(NewClon, 15f);
    }

}
