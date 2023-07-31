using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour
{
    //public Transform target; // Karakterin Transform bileþeni

    private void LateUpdate()
    {
        // Kamerayý karakterin yönüne kilitle
        transform.rotation = Quaternion.Euler(21.5f, 0f, 0f);
    }
}
