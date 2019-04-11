using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileManager : MonoBehaviour
{

    //Serealizable Variable Private
    [SerializeField]
    private Transform[] spawnsProjetiles;
    [SerializeField] private GameObject[] projetiles;
    [SerializeField] private float rateprojetile;
    
    [SerializeField] private bool shoot = true;
    private AudioSource audioSource;

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
            InvokeRepeating("Fire", rateprojetile, rateprojetile);
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
