using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeBase : ScriptGlobal
{
    [SerializeField] private int life= 1;
    [SerializeField] private float barlife;

    public void Damage(int damageCount)
    {
        life -= damageCount;
        int zero = 0;
        if (life <= zero)
        {

            // Dead!
            OnDestroy();
        }

    }
    public void BarDamage(float damageCount)
    {

        barlife -= damageCount;

        float zero= 0;
        if (barlife <= zero)
        {
            //Dead
            OnDestroy();
        }
    }
    public virtual void OnDestroy()
    {
        Destroy(gameObject);
    }


    #region Propriedade Hp
    public int Hp
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
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
    #endregion
}
