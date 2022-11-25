using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    public GameplayController gameplay ; 

    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log(other.tag );

        if(other.tag == "Enemy"){
            gameplay.status = PlayerStatus.Lose ;
        }
        if(other.tag == "Score"){ 
            gameplay.AddScore();
        }
        if(other.tag == "Time"){
            gameplay.AddTime();
        }
        if(other.tag == "Win"){
            gameplay.status = PlayerStatus.Win ;
        }
    }
}
