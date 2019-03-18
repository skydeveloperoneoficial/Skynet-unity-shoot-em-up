using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Ship : LifeBase
{
  
    
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private string tagobj;
    [SerializeField] private GameObject projetile;
    [SerializeField] private Transform SpawnProjetile;
    [SerializeField] private float Rateprojetile;
    private LifeBase enemyHealth, playerHealth;
    private ShipEnemy enemy;
    private float nextProjetile;


    [SerializeField] private string[] txts;
    [SerializeField]private Text[] texts;
    [SerializeField]private int killEnemy;
    [SerializeField]private int amountProjetileMax;
    [SerializeField]private int currentAmountProjetile;
    [SerializeField]private bool stopProjetile= true;
    [SerializeField]private bool StopSoundEfectProjetile= true;
   

    
    [SerializeField] private int damagerPlayer, damagerEnemy;

    private Animation animation_;
   
  
    public override void Awake()
    {
        animation_ = FindObjectOfType(typeof(Animation)) as Animation;
        
        base.Awake();
    }

    public void MakePlayerShotSound()
    {
        MakeSound(audioClips[0]);
    }
    public void MakerexplosionSound()
    {
        MakeSound(audioClips[1]);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
    public void HUDSTxt()
    {
        //Hp Do player
        texts[0].text = txts[0] + Hp;
        //quantidade maxima de Tiro;
        texts[2].text = txts[1] + currentAmountProjetile;
        // quantidade Tiro min
        //texts[2].text = txts[2] + amountProjetileMax;

        //Inimgos Mortos
        //texts[3].text = txts[3] + killEnemy;
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
            stopProjetile = false;
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
            MakePlayerShotSound();
        }
    }
    public void PlayAnimation()
    {
        animation_.Play("PlayerAnimation");
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
                    enemyHealth.Damage(damagerEnemy);
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

                    
                    playerHealth.Damage(damagerPlayer);


                    PlayAnimation();


                }
            }

        }
        base.OnCollisionEnter2D(collision);
    }
    private void Reload()
    {
        // carega o  o tiro no limite maximo

        if (Input.GetKeyDown(KeyCode.R))
        {
            int zero = 0;
            currentAmountProjetile = zero;
            stopProjetile = true;
            StopSoundEfectProjetile = true;

        }
    }
    private void CheckShotLimitMax()
    {
        if (currentAmountProjetile == amountProjetileMax)
        {
            Reload();
        }
    }
    private void ShotProjetile()
    {
        if (stopProjetile)
        {
            shootShip();


        }
    }
    public override void Update()
    {
        
        // verifica se o  tiro  esta no limite maximo
        CheckShotLimitMax();
        
        HUDSTxt();
        ShotProjetile();
        
        base.Update();
    }
 
}
