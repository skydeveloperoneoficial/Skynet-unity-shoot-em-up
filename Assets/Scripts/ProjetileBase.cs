using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjetileBase : LifeBase
{
    // visible inspector,private
    
   
    [SerializeField] private string taghit, Tagobject;

    [SerializeField] private Animator projetileAnimator;

    [SerializeField] private bool Animation_ = false;
    [SerializeField] private bool goToRight = true;
    private Animator projetileAnimatorHit;

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == Tagobject)
        {
            ApplyDamege(collider.gameObject);
        }
        base.OnTriggerEnter2D(collider);
    }

    public virtual void ApplyDamege(GameObject gameObject)
    {
        OnAppyDamage();
       
        AddAnimator();
       

    }
    // Adicina animaçao projetil
    private void AddAnimator()
    {
        if (Animation_)
        {
            try
            {
                projetileAnimator.SetTrigger(Taghit);
            }
            catch
            {
                Debug.LogWarning("Mark off Animation_");
            }
        }
    }
  

   

    protected abstract void OnAppyDamage();
    // varible public
    #region Variable Public
 
    public string Taghit
    {
        get
        {
            return taghit;
        }

        set
        {
            taghit = value;
        }
    }

    

   

    public Animator ProjetileAnimatorHit
    {
        get
        {
            return projetileAnimatorHit;
        }

        set
        {
            projetileAnimatorHit = value;
        }
    }

  
    #endregion
}

