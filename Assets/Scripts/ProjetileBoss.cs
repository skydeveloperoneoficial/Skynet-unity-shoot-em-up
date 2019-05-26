using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileBoss : ProjetileBase
{
    
   
    private LifeBase  characterlife;
    private Ship ship;
    private ScoreManager scoreManager;
   

    [SerializeField] private int damage;
    [SerializeField] private int timeDestroy;
    // campo  de Propriedade
    public int Damage_ { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        findObjs();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDestroyGameObject();
    }
    private void CheckDestroyGameObject()
    {
        Destroy(gameObject, timeDestroy);
    }
     private void findObjs()
     {
         ship = FindObjectOfType(typeof(Ship))as Ship;
          scoreManager = FindObjectOfType( typeof(ScoreManager)) as ScoreManager;
     }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag=="Ship")
        {
            characterlife = collider.gameObject.GetComponent<LifeBase>();
            if(characterlife!= null)
            {
                characterlife.Damage(Damage_);
                int zero= 0;
                if(characterlife.Hp== zero)
                {
                    SoundEffectControl.Instance.MakeExplosionSound();

                }
                // Destroi o tiro do boss
                Destroy(gameObject);
                //Somente a nave do player sera destruida e dara  game Over
                 if (ship.Hp == 0)
                 {
                    
                     ship.Texts[3].gameObject.SetActive(true);
                     ship.Buttons_[0].gameObject.SetActive(true);
                     ship.Texts[0].gameObject.SetActive(false);
                     ship.Texts[2].gameObject.SetActive(false);
                     // desabilitar Tiro do Boss
                     ship.GameObjects_[2].SetActive(false);
                     scoreManager.DesableTextScore();
                     StopCoroutine(ship.WaveCont());
                    

                 } 
            }
            
        

        }
        
    }
    protected override void OnAppyDamage()
    {
        
    }
}
