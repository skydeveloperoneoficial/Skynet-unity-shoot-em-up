using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Ship : ScriptGlobal
{
    // Start is called before the first frame update
    //private BulletManagement bulletManagement;
    private LifePlayer characterLife;
    [SerializeField]private AudioClip playerShotSound;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private string tagobj;
    [SerializeField] private GameObject projetile;
    [SerializeField] private Transform SpawnProjetile;
    [SerializeField] private float Rateprojetile;
    private float nextProjetile;

    // hit
    private float currentTimeTohit;
    [SerializeField] private string hptxt,killTxt;
     public Text hp;
    [SerializeField]private Text kill;
    private int killEnemy; 
    

    private void FindObj()
    {
        characterLife = FindObjectOfType(typeof(LifePlayer)) as LifePlayer;
                
    }
    protected override void Start()
    {
        FindObj();
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
        hp.text = hptxt + characterLife.Hp;
        kill.text = killTxt + killEnemy;
    }
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
            MakePlayerShotSound();
            


        }
    }

    // Colisoes  ship com o ShipEnemy

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagobj)
        {
            var damagePlayer = false;

            ShipEnemy enemy = collision.gameObject.GetComponent<ShipEnemy>();

            //if (enemy != null)
            //{
            //    //CharacterLife enemyHealth = enemy.GetComponent<CharacterLife>();

            //    //if (enemyHealth != null)
            //    {
            //        //enemyHealth.Damage(enemyHealth.Hp);
            //        //ScoreManager.TotalScore--;
            //        //MakerexplosionSound();

            //    }
            //    //if (enemyHealth.Hp == 0)
            //    //{
            //    //    AddNumKillEnemy();
            //    //}

            //    damagePlayer = true;
            //}

            if (damagePlayer)
            {
                
                LifePlayer playerHealth = GetComponent<LifePlayer>();

                if (playerHealth != null)
                {
                    playerHealth.Damage(1);

                }
            }
           
        }
        base.OnCollisionEnter2D(collision);
    }
    public override void Update()
    {
        HUDSTxt();
        shootShip();
        base.Update();
    }
 
}
