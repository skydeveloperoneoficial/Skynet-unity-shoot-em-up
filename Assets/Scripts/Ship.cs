﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Ship : LifeBase
{
  
    
    
    [SerializeField] private string tagobj;
    [SerializeField] private GameObject projetile;
    [SerializeField] private Transform SpawnProjetile;
    [SerializeField] private GameObject[] gameObjects_;
    [SerializeField] private float Rateprojetile;
    [SerializeField] private float rateSpawnEnemy;
    [SerializeField] private float timeSpawnEnemy;
    
    private LifeBase enemyHealth, playerHealth;
    private ShipEnemy enemy,shipEnemytwo;
    
    private SpawnControl2D spawnControl2D;
    private ProjetileManager projetileManager;
    private ScrollingBackground scrollingBackground;
    
    
    private ScoreManager scoreManager;
    
    private float nextProjetile;


    [SerializeField] private string[] txts;
    [SerializeField]private Text[] texts;
    [SerializeField] private Button[] buttons_;
    [SerializeField]private int killEnemy;
    [SerializeField]private int amountProjetileMax_;
    public static int currentAmountProjetile_;
    public static bool stopProjetile= true;
    [SerializeField] private float rateProjeteleEnemy;
    

    

   

    [SerializeField] private int damagerPlayer, damagerEnemy;

    [SerializeField]
    private float[] colldownWaves;
    
    



    private void Start()
    {
        
        texts[3].gameObject.SetActive(false);// Desabilitar Game Over  Text
        buttons_[0].gameObject.SetActive(false);// Desabilitar Game Over  Bottom
        //Desbiltar  Gerenciador de Tiro
        
        //Desatvar Boss
        gameObjects_[0].gameObject.SetActive(false);
        //Desabiltar inimigo
        
        //FinnDObj
        spawnControl2D = FindObjectOfType(typeof(SpawnControl2D)) as SpawnControl2D;
        enemy = FindObjectOfType(typeof(ShipEnemy)) as ShipEnemy;
       
        shipEnemytwo = FindObjectOfType(typeof(ShipEnemy)) as ShipEnemy;
        projetileManager = FindObjectOfType(typeof(ProjetileManager)) as ProjetileManager;
        scrollingBackground = FindObjectOfType(typeof(ScrollingBackground)) as ScrollingBackground;
        
        scoreManager = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
        
    }


    #region Propriedades

    public Text[] Texts { get => texts; set => texts = value; }
    public Button[] Buttons_ { get => buttons_; set => buttons_ = value; }
    public GameObject[] GameObjects_ { get => gameObjects_; set => gameObjects_ = value; }
    public int AmountProjetileMax_ { get => amountProjetileMax_; set => amountProjetileMax_ = value; }
    
    
    #endregion


    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
    public void HUDSTxt()
    {
        //Hp Do player
        texts[0].text = txts[0] + Hp;
        //quantidade maxima de Tiro;
        texts[2].text = txts[1] + currentAmountProjetile_;
        
       
        texts[3].text = "GameOver";
        
    }
    //Add projetile UI
    public void addProjetileUI()
    {
        currentAmountProjetile_++;
        checkMaxProjetile();
    }

    
    /// <summary>
    /// checa  o Maximo de  projetil
    /// </summary>
    public void checkMaxProjetile()
    {
        if (currentAmountProjetile_ == amountProjetileMax_)
        {
            stopProjetile = false;
            
            
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
            
            SoundEffectControl.Instance.MakePlayerShotSound();
        }
    }


    // Colisoes  ship com o ShipEnemy

    #region Colision
    private void OnCollisionEnter2D(Collision2D collision)
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
                    //ScoreManager.TotalScore--;
                
                    
                    SoundEffectControl.Instance.MakeExplosionSound();
                    

               
                }
                int zero=0;
                if (enemyHealth.Hp == zero)// se a viada do inimigo  For zero
                {
                    // adciona  quantide Morte para inimigos
                    AddNumKillEnemy();
                }
        
                damagePlayer = true;
            }
            // DANO DO PLAYER
            if (damagePlayer)
            {

                playerHealth = GetComponent<LifeBase>();

                if (playerHealth != null)
                {

                    playerHealth.Damage(damagerPlayer);
                    int zero = 0;
                    if (this.Hp == zero)
                    {
                        

                        //Ativa  o Game Over 
                        texts[3].gameObject.SetActive(true);
                        buttons_[0].gameObject.SetActive(true);

                        //desativa  os  testos e o score o scrollingBackground e para de spawnar
                        texts[0].gameObject.SetActive(false);
                        texts[2].gameObject.SetActive(false);
                        scoreManager.DesableTextScore();
                        scrollingBackground.Speed = 0;
                        spawnControl2D.directionSpawn = StateDirectionSpawn.Disable;
                        StopCoroutine(WaveCont());
                    }
                      




                }
            }
            

        }

    }
    #endregion

    private void Reload()
    {
        // carega o  o tiro no limite maximo

        if (Input.GetKeyDown(KeyCode.R)|| CrossPlatformInputManager.GetButton("Fire2"))
        {
            int zero = 0;
            currentAmountProjetile_ = zero;
            stopProjetile = true;
            

        }
    }
    private void CheckShotLimitMax()
    {
        if (currentAmountProjetile_ == amountProjetileMax_)
        {
            //Reload(); //Reload  sem powerup
        }
    }
    private void ShotProjetile()
    {
        if (stopProjetile)
        {
            shootShip();


        }
    }
    private void StartCorotine_()
    {
      
        StartCoroutine(WaveCont());
        
    }
    private void Update()
    {
        
        // verifica se o  tiro  esta no limite maximo
        CheckShotLimitMax();
        
        HUDSTxt();
        ShotProjetile();

        StartCorotine_();
        
        
    }
    public IEnumerator WaveCont()
    {
        projetileManager.Shoot = false;
        // Primera Weve
        Debug.Log("Wave1");
        
        yield return new WaitForSeconds(colldownWaves[0]);
       
        
        // Segunda Wave
        Debug.Log("Wave2");

        //Debug.Log("(Wave 2)" + colldownWaves[0]);
  
        Debug.Log("Disabiltar Spawn");

        yield return new WaitForSeconds(colldownWaves[1]);
        // terceira Wave
        Debug.Log("Wave3");
        Debug.Log("abiltar Spawn");
       

        yield return new WaitForSeconds(colldownWaves[2]);
        // Quarta Wave
        Debug.Log("Wave4");

        projetileManager.Shoot = true;

       

        yield return new WaitForSeconds(colldownWaves[3]);
        // Quinta Wave
        Debug.Log("Wave5");
        yield return new WaitForSeconds(colldownWaves[4]);
        // Sexta Wave
        Debug.Log("Wave6");

        yield return new WaitForSeconds(colldownWaves[5]);
        // Final Wave
        Debug.Log("Disabiltar Spawn");
        spawnControl2D.directionSpawn = StateDirectionSpawn.Disable;// Para de spawnar
        Debug.Log("WaveFinal");
        // O boss aparece
        yield return new WaitForSeconds(colldownWaves[6]);
        // Aparece o Boss

        gameObjects_[0].SetActive(true);
        
        

        yield return new WaitForSeconds(colldownWaves[7]);
        
        Debug.Log("Parar Boss e para BG");
        
       
        scrollingBackground.Speed = 0; // Para o BG
        //desativar o Boss
        BasicMoveBoss.enableBossX = true;
        BasicMoveBoss.enableTeleport = false;
///Fim

        //Wave BattleBoss  Onda de balalha  do boss




    }


}
