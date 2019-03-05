using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipEnemy : LifeBase
{
    
    
    private BasicMoviment2D enemyMove;
    
    [SerializeField]private int timeDestroy;
    [SerializeField] private AudioClip enemyShotSound;
    //Private
    //variable
    //Serealizable Variable Private
    [SerializeField]
    private Transform[] spawnsProjetiles;
    [SerializeField] private GameObject[] projetiles;
    [SerializeField] private float Rateprojetile;
    private float nextProjetile;
    [SerializeField]private bool shoot = true;
   

    private LimitObject limitObject;
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

    public AudioClip EnemyShotSound
    {
        get
        {
            return enemyShotSound;
        }

        set
        {
            enemyShotSound = value;
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

    public void MakerEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
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
    private void Fire()
    {
        for (int i = 0; i < spawnsProjetiles.Length; i++)
        {
            Instantiate(projetiles[0], spawnsProjetiles[0].position, spawnsProjetiles[0].rotation);
            Instantiate(projetiles[1], spawnsProjetiles[1].position, spawnsProjetiles[1].rotation);
            MakerEnemyShotSound();
        }
    }



}
