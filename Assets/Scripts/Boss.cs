using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boss :LifeBase
{
    

    protected  void Start()
    {
        //desabilitar boss
        
        
    }

    // Update is called once per frame
    public  void Update()
    {
       
    }
    public   void instanceBoss()
    {
        Debug.Log("Instaciou o Boss");
        Instantiate(this,this.transform.position,this.transform.rotation);

    }
   
    
}
