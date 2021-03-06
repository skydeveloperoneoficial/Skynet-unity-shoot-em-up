﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : ProjetileBase
{

    [SerializeField] private int damage;
    [SerializeField] private string objectTag,objectTag2;
    [SerializeField] private int timeDestroy;
    [SerializeField] private int score;
    private ScoreManager scoreManager;
    private WaveControl waveControl;
    private Ship ship;
    private ShipEnemy shipEnemy;
    private LifeBase characterLife,Bosslife;// Todos os personagens
    private SpawnControl2D spawnControl;
    private ScrollingBackground scrollingBackground;
    private Boss boss;
    private GameObject[] gameObjects;
    
    
   
    #region Propriedades get Set
    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
        
    }
    
    public string ObjectTag
    {
        get
        {
            return objectTag;
        }

        set
        {
            objectTag = value;
        }
    }
    #endregion
    // Start is called before the first frame update
    protected  void Start()
    {

        findObjs();
        
        
    }
   
    private void CheckDestroyGameObject()
    {
        Destroy(gameObject, timeDestroy);
    }
    //Procurar Object
    private void findObjs()
    {
        ship = FindObjectOfType(typeof(Ship)) as Ship;
        scoreManager = FindObjectOfType( typeof(ScoreManager)) as ScoreManager;
        spawnControl = FindObjectOfType(typeof(SpawnControl2D)) as SpawnControl2D;
        scrollingBackground = FindObjectOfType(typeof(ScrollingBackground)) as ScrollingBackground;
        shipEnemy = FindObjectOfType(typeof(ShipEnemy))as ShipEnemy;
        boss = FindObjectOfType(typeof(Boss))as Boss;
        
        waveControl = FindObjectOfType(typeof(WaveControl))as WaveControl;
        
    }
    // Update is called once per frame
    public  void Update()
    {
        CheckDestroyGameObject();
        
    }

   public bool SpawnItem()
   {
        Debug.Log("Instanciou"+ transform.position);
        Instantiate(ship.GameObjects_[0],shipEnemy.transform.position,shipEnemy.transform.rotation);
        ship.GameObjects_[0].SetActive(true);

        return true;
        
        
   }
  

    private  void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == objectTag)
        {
             characterLife = collider.gameObject.GetComponent<LifeBase>();

            if (characterLife != null)
            {
                characterLife.Damage(Damage);
                int lifezero = 0;
                // Verifica se a vida do obj = zero
                if (characterLife.Hp == lifezero)
                {


                    SpawnItem();
                    
                    
                   
                    Debug.Log("Pegou");
                    
                   SoundEffectControl.Instance.MakeExplosionSound();
                    
                }
                
                Destroy(gameObject);//destroyProjetil
               

                if (characterLife.Hp == lifezero)
                {
                    ship.AddNumKillEnemy();

                    //shipEnemy.OnDestroy();
                    ScoreManager.AddScore(score);
                }
                //Somente a nave do player sera destruida e dara  game Over
                if (ship.Hp == lifezero)
                {
                    spawnControl.directionSpawn = StateDirectionSpawn.Disable;
                    scrollingBackground.Speed = 0;
                    ship.Texts[3].gameObject.SetActive(true);
                    ship.Buttons_[0].gameObject.SetActive(true);
                    ship.Texts[0].gameObject.SetActive(false);
                    ship.Texts[2].gameObject.SetActive(false);
                    scoreManager.DesableTextScore();
                    //StopCoroutine(gameControl.WaveCont());
                    waveControl.StopCorotina_();
                    

                }
               
                
                
                


            }

        }
        // Colisao do Tiro do player no boss
        if (collider.gameObject.tag == "Boss")
        {
            Bosslife = collider.gameObject.GetComponent<LifeBase>();
            
            if (Bosslife != null)
            {
                Bosslife.Damage(Damage);
                
                int lifezero = 0;
                // Verifica se a vida do obj = zero
                if (Bosslife.Hp == lifezero)
                {


                    //SpawnItem();
                    //Destroy(ship.GameObjects_[1]);
                     
                   
                    //Debug.Log("Pegou");
                    
                   SoundEffectControl.Instance.MakeExplosionSound();
                    
                }
                
                Destroy(gameObject);//destroyProjetil


               if(boss.Hp== lifezero)
               {
                    ship.Texts[4].gameObject.SetActive(true);
                    ship.Buttons_[0].gameObject.SetActive(true);
                    //Debug.ClearDeveloperConsole();
                    Ship.destroyShip = true;
                    ScoreManager.AddScore(300);
                    
                    
               }

               
        }
       
    }
}
        
    
    
    protected override void OnAppyDamage()
    {
        
    }
   
}
