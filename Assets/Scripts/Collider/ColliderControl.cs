using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log(other.tag);
    }

}
