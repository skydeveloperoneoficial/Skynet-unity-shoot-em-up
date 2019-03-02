using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifePlayer : ScriptGlobal
{

    [SerializeField] private int hp= 1;

    public void Damage(int damageCount)
    {
        hp -= damageCount;
        int zero = 0;
        if (hp <= zero)
        {

            // Morte!
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
            return hp;
        }

        set
        {
            hp = value;
        }
    }
    #endregion

}
