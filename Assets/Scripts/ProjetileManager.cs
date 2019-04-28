using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileManager : MonoBehaviour
{

    //Serealizable Variable Private
    [SerializeField]
    private Transform[] spawnsProjetiles;
    [SerializeField] private GameObject[] projetiles;
    [SerializeField] private float rateprojetile_;
    
    [SerializeField] private bool shoot = true;
    private AudioSource audioSource;

    public bool Shoot { get => shoot; set => shoot = value; }
    public float Rateprojetile_ { get => rateprojetile_; set => rateprojetile_ = value; }

    protected void Start()
    {
        shootProjetile();
        
        FindObject();
        
    }
    private void FindObject()
    {
        audioSource = FindObjectOfType(typeof(AudioSource)) as AudioSource;
    }
    private void shootProjetile()
    {
        if (shoot)
        {
            InvokeRepeating("Fire", Rateprojetile_, Rateprojetile_);
        }
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
