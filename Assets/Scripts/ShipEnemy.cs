using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipEnemy : LifeBase
{
    
    
    private BasicMoviment2D enemyMove;
    
    [SerializeField]private int timeDestroy;
    
    //Private
    //variable
    //Serealizable Variable Private
    [SerializeField]
    private Transform[] spawnsProjetiles;
    [SerializeField] private GameObject[] projetiles;
    [SerializeField] private float Rateprojetile;
    private float nextProjetile;
    [SerializeField]private bool shoot = true;
    private AudioSource audioSource;

    
    private Ship ship;



    #region propriedades get Set
    public GameObject[] Projetiles
    {
        get
        {
            return projetiles;
        }

        set
        {
            projetiles = value;
        }
    }

    public float Rateprojetile1
    {
        get
        {
            return Rateprojetile;
        }

        set
        {
            Rateprojetile = value;
        }
    }



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

    public bool Shoot
    {
        get
        {
            return shoot;
        }

        set
        {
            shoot = value;
        }
    }

    #endregion
    // Start is called before the first frame update
    protected override void Start()
    {
        if (Shoot)
        {
            InvokeRepeating("Fire", Rateprojetile1, Rateprojetile1);
        }
        OnTimeDestroy();
        FindObject();

    }


    
    private void FindObject()
    {
        enemyMove = FindObjectOfType(typeof(BasicMoviment2D)) as BasicMoviment2D;

        ship = FindObjectOfType(typeof(Ship)) as Ship;
        audioSource = FindObjectOfType(typeof(AudioSource)) as AudioSource;
        

    }

   
    public void OnTimeDestroy()
    {
        Destroy(gameObject, TimeDestroy);
    }
    private void Fire()
    {
        for (int i = 0; i < spawnsProjetiles.Length; i++)
        {
            Instantiate(projetiles[0], spawnsProjetiles[0].position, spawnsProjetiles[0].rotation);
            Instantiate(projetiles[1], spawnsProjetiles[1].position, spawnsProjetiles[1].rotation);
            audioSource.Play();
        }
    }



}
