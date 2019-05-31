using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipEnemy : LifeBase
{
    
 
    [SerializeField]private int timeDestroy;// So mente nese  campo

    private Ship ship;
    public static bool destroyShipEnemy;



    #region propriedades get Set

    public int TimeDestroy
    {
        get
        {
            return timeDestroy;
        }

        set
        {
            timeDestroy = value;
        }
    }

    #endregion
    // Start is called before the first frame update
    protected  void Start()
    {
       
        OnTimeDestroy();
        FindObject();

    }
  
   
    private void FindObject()
    {
        
      

        ship = FindObjectOfType(typeof(Ship)) as Ship;
        
        

    }
    // Destruir a o Inimgo depois de um tempo
    public void OnTimeDestroy()
    {
        Destroy(gameObject, TimeDestroy);
    }
    public void OnDestroyNoTime()
    {
        if(destroyShipEnemy)
        {
            Destroy(gameObject);
        }
        
    }
   
   



}
