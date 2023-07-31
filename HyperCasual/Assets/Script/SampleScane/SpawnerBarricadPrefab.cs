using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBarricadPrefab : MonoBehaviour
{
    int Spawm ;
    public  static int SpawmnDistance;
    public static int SpawmLevel;
    public int randomNumber;
    float timer = 0f;
    float interval = 1.5f;
    bool SpawnKey=false;
    public Transform Character;
    Move move;


   
    public GameObject Baricad1, Baricad2, Baricad3, Baricad4, Baricad5,Baricad6;
    System.Random random = new System.Random();
    void Start()
    {
     
        InvokeRepeating("ObjectClone", 0, 1.2f);
        move = GetComponent<Move>();
        SpawmLevel = 0;
        Spawm = -25;
        SpawmnDistance = 47;



    }
    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            randomNumber = random.Next(1, 8);
       
            timer = 0f;
            SpawnKey = true;
       
        }
    }
    public void ObjectClone()
    {
        if (randomNumber == 2 && SpawnKey == true)
            {
                Clon(Baricad1, -0.3f);
            SpawnKey = false;
            }

            if (randomNumber == 6&& SpawnKey == true)
            {
                Clon(Baricad2, -0.3f);
              SpawnKey = false;
            }
            if (randomNumber == 3 && SpawnKey == true)
            {
                Clon(Baricad3, -0.3f);
            SpawnKey = false;
        }
            if (randomNumber == 4 && SpawnKey == true)
            {
            SpawnKey = false;
            Clon(Baricad4, -0.3f);
            }
            if (randomNumber == 5 && SpawnKey == true)
            {
            SpawnKey = false;
            Clon(Baricad5, -0.3f);
            }
        if (randomNumber == 7 && SpawnKey == true)
        {
            SpawnKey = false;
            Clon(Baricad6, -0.3f);
        }


    }
    public void Clon(GameObject Object, float y_coordinate)
    {
       
      
        GameObject NewClon = Instantiate(Object);

        if (SpawmLevel == 0)
        {
            NewClon.transform.position = new Vector3(0.18f, y_coordinate,Spawm);
            Destroy(NewClon, 35f);
            SpawmLevel++;
          
        }
  
        if(SpawmLevel > 0)
        {
            NewClon.transform.position = new Vector3(0.18f, y_coordinate, Spawm+ SpawmnDistance);
            Destroy(NewClon, 35f);
            SpawmnDistance += 70;
            
            //Debug.Log(SpawmnDistance + "spawmD");
           
            

        }
    }
}
