﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateShotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    

    // Update is called once per frame
     void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Ship"){
            Destroy(gameObject);
        }
        
    }
}
