using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipEnemy : LifeBase
{
    private BasicMoviment2D enemyMove;
    
    [SerializeField]private int timeDestroy;

    private Ship ship;



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
        enemyMove = FindObjectOfType(typeof(BasicMoviment2D)) as BasicMoviment2D;

        ship = FindObjectOfType(typeof(Ship)) as Ship;
        
        

    }

    public void OnTimeDestroy()
    {
        Destroy(gameObject, TimeDestroy);
    }
 



}
