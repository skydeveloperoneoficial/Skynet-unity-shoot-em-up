using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boss :LifeBase
{
    public static bool destroyBoss;
    protected  void Start()
    {
        
        OnBossDestroy();
        
    }

    // Update is called once per frame
    public  void Update()
    {
       
    }
    public void OnBossDestroy()
    {
        if(destroyBoss)
        {
            Destroy(gameObject);
        }
        
    }
    
   
    
}
