using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    public GameplayController gameplay ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "Enemy"){
            gameplay.status = PlayerStatus.Lose ;
        }
    }
}
