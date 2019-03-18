﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : ProjetileBase
{

    [SerializeField] private int damage;
    [SerializeField] private string objectTag;
    [SerializeField] private int timeDestroy;
    [SerializeField] private int score;
    
    private Ship ship;
    private LifeBase characterLife;
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
    protected override void Start()
    {

        findObjs();
        
        base.Start();
    }
    private void CheckDestroyGameObject()
    {
        Destroy(gameObject, timeDestroy);
    }
    //Procurar Object
    private void findObjs()
    {
        ship = FindObjectOfType(typeof(Ship)) as Ship;
    }
    // Update is called once per frame
    public override void Update()
    {
        CheckDestroyGameObject();
        base.Update();
    }
   
    public override void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == objectTag)
        {
             characterLife = collider.gameObject.GetComponent<LifeBase>();

            if (characterLife != null)
            {
                characterLife.Damage(Damage);
                int lifezero = 0;
                // Verifica se a vida do player  = zero
                if (characterLife.Hp == lifezero)
                {

                    SoundEffectControl.Instance.MakeExplosionSound();

                }
                Destroy(gameObject);//destroyProjetil


                if (characterLife.Hp == lifezero)
                {
                    ship.AddNumKillEnemy();
                    
                    ScoreManager.AddScore(score);
                }


            }

        }
        base.OnTriggerEnter2D(collider);
    }

    protected override void OnAppyDamage()
    {
        
    }
}
