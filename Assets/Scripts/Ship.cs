using Assets.Scripts;
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
    public  static float Rateprojetile;
    [SerializeField] private float rateSpawnEnemy;
    [SerializeField] private float timeSpawnEnemy;
    [SerializeField] private float RateprojetileShip;
    private LifeBase enemyHealth, playerHealth,BossHealth;
    private ShipEnemy enemy;
    private Boss boss;
    private SpawnControl2D spawnControl2D;
    private ProjetileEnemys projetileEnemys;
    private ScrollingBackground scrollingBackground;
    //private Boss boss;
    private SpawnBosses spawnBosses;
    private  WaveControl waveControl;
    
    private ScoreManager scoreManager;
    
    private float nextProjetile;


    [SerializeField] private string[] txts;
    [SerializeField]private Text[] texts;
    [SerializeField] private Button[] buttons_;
    [SerializeField]private int killEnemy;
    [SerializeField]private int amountProjetileMax_;
    public static int currentAmountProjetile_;
    public static bool stopProjetile= true;
    public static bool destroyShip;
    [SerializeField] private float rateProjeteleEnemy;
   
    

    

   

    [SerializeField] private int damagerPlayer, damagerEnemy,DamageBoss ;

    [SerializeField]
    //private float[] colldownWaves;
    
    


    
    private void Start()
    {

        //FinnDObj
        spawnControl2D = FindObjectOfType(typeof(SpawnControl2D)) as SpawnControl2D;
        enemy = FindObjectOfType(typeof(ShipEnemy)) as ShipEnemy;
        //gameControl = FindObjectOfType(typeof(GameControl))as GameControl;
       
        projetileEnemys = FindObjectOfType(typeof(ProjetileEnemys)) as ProjetileEnemys;
        scrollingBackground = FindObjectOfType(typeof(ScrollingBackground)) as ScrollingBackground;
        
        scoreManager = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
        
        spawnBosses = FindObjectOfType(typeof(SpawnBosses))as SpawnBosses;
        boss = FindObjectOfType(typeof(Boss))as Boss;
        waveControl = FindObjectOfType(typeof(WaveControl)) as WaveControl;


        destroyShip = false;
       
        
        Ship.Rateprojetile =  RateprojetileShip;
        texts[3].gameObject.SetActive(false);// Desabilitar Game Over  Text
        buttons_[0].gameObject.SetActive(false);// Desabilitar Game Over  Bottom
        //Ativa o tiro
        stopProjetile= true;
        //Inimigo pode atira
        ProjetileEnemys.shoot= true;

        

        OnShipDestroy();
       
    }


    #region Propriedades

    public Text[] Texts { get => texts; set => texts = value; }
    public Button[] Buttons_ { get => buttons_; set => buttons_ = value; }
    public GameObject[] GameObjects_ { get => gameObjects_; set => gameObjects_ = value; }
    public int AmountProjetileMax_ { get => amountProjetileMax_; set => amountProjetileMax_ = value; }
    //public float[] ColldownWaves { get => colldownWaves; set => colldownWaves = value; }


    #endregion

    public void OnShipDestroy()
    {
        if(destroyShip)
        {
            Destroy(gameObject);
        }
        
    }
  
    public void HUDSTxt()
    {
        //Hp Do player
        texts[0].text = txts[0] + this.Hp;
        //quantidade maxima de Tiro;
        texts[2].text = txts[1] + currentAmountProjetile_;
        
       
        texts[3].text = "GameOver";
        texts[4].text = " You Winner";
        
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


    

    #region Colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica a  colisao do inimigo com o player
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
                    // Som de explosao

               
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
                         //StopCoroutine(gameControl.WaveCont());
                         waveControl.StopCorotina_();
                    }
                      




                }
            }
            

        }
        
        if (collision.gameObject.tag == "Boss")
        {
            

            boss = collision.gameObject.GetComponent<Boss>();
            if (boss != null)
            {
                BossHealth = boss.GetComponent<LifeBase>();

                if (BossHealth != null)
                {
                    BossHealth.Damage(DamageBoss);
                    //ScoreManager.TotalScore--;
                        if (boss.Hp == 0)
                        {
                            texts[4].gameObject.SetActive(true);
                            buttons_[0].gameObject.SetActive(true);
                            Ship.currentAmountProjetile_= 0;
                            BasicMoveBoss.enableBossX = false;
                            ProjetileBosses.shoot = false;
                            destroyShip = true;
                            ScoreManager.AddScore(300);
                            
                        }
                    
                        SoundEffectControl.Instance.MakeExplosionSound();
                        // Som de explosao
                        
                        

                    

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

    private void Update()
    {
        
        // verifica se o  tiro  esta no limite maximo
        CheckShotLimitMax();
        
        HUDSTxt();
        ShotProjetile();

        
        
        
    }
    


}
