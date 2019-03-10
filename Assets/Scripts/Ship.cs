using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Ship : LifeBase
{
  
    [SerializeField]private AudioClip playerShotSound;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private string tagobj;
    [SerializeField] private GameObject projetile;
    [SerializeField] private Transform SpawnProjetile;
    [SerializeField] private float Rateprojetile;
    private LifeBase enemyHealth, playerHealth;
    private ShipEnemy enemy;
    private float nextProjetile;

    // hit
    private float currentTimeTohit;
    [SerializeField] private string hptxt,killTxt,projetiletxtMax, projetiletxtMin;
    [SerializeField]private Text UIkill, UIhp,UIprojetileMax,UIprojetileMin;
    private int killEnemy;
    [SerializeField]private int amountProjetileMax;
    [SerializeField]private int currentAmountProjetile;
    [SerializeField]private bool StopProjetile= true;
    [SerializeField]private bool StopSoundEfectProjetile= true;

    
   
    protected override void Start()
    {


        
        base.Start();
    }
    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }
    public void MakerexplosionSound()
    {
        MakeSound(explosionSound);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
    public void HUDSTxt()
    {
        //Hp Do player
        UIhp.text = hptxt + Hp;
        //quantidade maxima de Tiro;
        UIprojetileMax.text = projetiletxtMax + currentAmountProjetile;
        // quantidade Tiro min
        UIprojetileMin.text = projetiletxtMin + amountProjetileMax;

        //Inimgos Mortos
        //kill.text = killTxt + killEnemy;
    }
    //Add projetile UI
    public void addProjetileUI()
    {
        currentAmountProjetile++;
        checkMaxProjetile();
    }

    //public void RemoveProjetileUI()
    //{
    //    if (currentAmountProjetile >= amountProjetileMax)
    //    {
    //        amountProjetileMax--;
    //    }
            
    //}
    /// <summary>
    /// checa  o Maximo de  projetil
    /// </summary>
    public void checkMaxProjetile()
    {
        if (currentAmountProjetile == amountProjetileMax)
        {
            StopProjetile = false;
            StopSoundEfectProjetile = false;
            
        }


    }
    // Add morte ui  do inimigo
    public  void AddNumKillEnemy()
    {
        killEnemy++;
    }
    
   
    private void shootShip()
    {
        if (CrossPlatformInputManager.GetButton("Fire1")&& Time.time> nextProjetile)
        {
            nextProjetile = Time.time + Rateprojetile;
            Instantiate(projetile, SpawnProjetile.position,SpawnProjetile.rotation);
            addProjetileUI();
            if (StopSoundEfectProjetile)
            {
                MakePlayerShotSound();
            }
            
            


        }
    }

    // Colisoes  ship com o ShipEnemy

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == tagobj)
        {
            var damagePlayer = false;

             enemy = collision.gameObject.GetComponent<ShipEnemy>();

            if (enemy != null)
            {
                enemyHealth = enemy.GetComponent<LifeBase>();
                
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(enemyHealth.Hp);
                    ScoreManager.TotalScore--;
                    MakerexplosionSound();
                    
                }
                if (enemyHealth.Hp == 0)
                {
                    AddNumKillEnemy();
                }

                damagePlayer = true;
            }

            if (damagePlayer)
            {

                playerHealth = GetComponent<LifeBase>();

                if (playerHealth != null)
                {
                    playerHealth.Damage(1);

                }
            }

        }
        base.OnCollisionEnter2D(collision);
    }
    private void Recaregar()
    {
        // carega o  o tiro no limite maximo

        if (Input.GetKeyDown(KeyCode.R))
        {
            int zero = 0;
            currentAmountProjetile = zero;
            StopProjetile = true;
            StopSoundEfectProjetile = true;

        }
    }
    public override void Update()
    {
        // verifica se o  tiro  esta no limite maximo
        if (currentAmountProjetile == amountProjetileMax)
        {
            Recaregar();
        }
            
        HUDSTxt();
        if (StopProjetile)
        {
            shootShip();
            

        }
        
        base.Update();
    }
 
}
