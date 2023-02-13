using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeBaseBar : MonoBehaviour
{
    [SerializeField] private float barlife;
    
   
    public void BarDamage(float damageCount)
    {

        barlife -= damageCount;

        float zero= 0;
        if (barlife <= zero)
        {
            //Dead
            OnDestroy();
        }
        else
        {
            StartCoroutine(TakingDamage());
        }
    }
    public virtual void OnDestroy()
    {
        Destroy(gameObject);
    }


    public float Barlife
    {
        get
        {
            return barlife;
        }

        set
        {
            barlife = value;
        }
    }

   
  
}
