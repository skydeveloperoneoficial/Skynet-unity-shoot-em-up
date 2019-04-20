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
    [SerializeField] private float Rateprojetile;
    private LifeBase enemyHealth, playerHealth;
    private ShipEnemy enemy;
    private float nextProjetile;


    [SerializeField] private string[] txts;
    [SerializeField]private Text[] texts;
    [SerializeField] private Button[] buttons_;
    [SerializeField]private int killEnemy;
    [SerializeField]private int amountProjetileMax;
    [SerializeField]private int currentAmountProjetile;
    [SerializeField]private bool stopProjetile= true;

    [SerializeField] private int damagerPlayer, damagerEnemy;
    private void Start()
    {
        texts[3].gameObject.SetActive(false);
        buttons_[0].gameObject.SetActive(false);
    }


    #region Propriedades

    public Text[] Texts { get => texts; set => texts = value; }
    public Button[] Buttons_ { get => buttons_; set => buttons_ = value; }
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
        texts[2].text = txts[1] + currentAmountProjetile;
        
        // quantidade Tiro min
        //texts[2].text = txts[2] + amountProjetileMax;

        //Inimgos Mortos
        //texts[3].text = txts[3] + killEnemy;
        texts[3].text = "GameOver";
        
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
                    ScoreManager.TotalScore--;
                    SoundEffectControl.Instance.MakeExplosionSound();


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
            currentAmountProjetile = zero;
            stopProjetile = true;
            

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
    private void Update()
    {
        
        // verifica se o  tiro  esta no limite maximo
        CheckShotLimitMax();
        
        HUDSTxt();
        ShotProjetile();
        
        
    }
 
}
