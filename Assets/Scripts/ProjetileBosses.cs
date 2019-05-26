using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileBosses : MonoBehaviour
{
   //Serealizable Variable Private
    [SerializeField]
    private Transform[] spawnsProjetiles;
    [SerializeField] private GameObject[] projetiles;
    [SerializeField] private float rateprojetile_;
    
     public static bool shoot;
   

    
    public float Rateprojetile_ { get => rateprojetile_; set => rateprojetile_ = value; }

    protected void Start()
    {
        shootProjetile();
        
        
        
    }
  
    private void shootProjetile()
    {
        InvokeRepeating("Fire", Rateprojetile_, Rateprojetile_);
    }
    private void Fire()
    {
        if(shoot)
        {
            for (int i = 0; i < spawnsProjetiles.Length; i++)
            {
                Instantiate(projetiles[0], spawnsProjetiles[0].position, spawnsProjetiles[0].rotation);
                
                Instantiate(projetiles[1], spawnsProjetiles[1].position, spawnsProjetiles[1].rotation);
                SoundEffectControl.Instance.MakeEnemyShotSound();
                
            }
        }
        
        
    }
}
