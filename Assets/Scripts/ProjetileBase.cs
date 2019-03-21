using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// hit   com o animator
public abstract class ProjetileBase : LifeBase
{
    // visible inspector,private
    
   
    [SerializeField] private string taghit;

    [SerializeField] private Animator projetileAnimatorHit;

    [SerializeField] private bool Animation_ = false;
    
   
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
                projetileAnimatorHit.SetTrigger(Taghit);
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

