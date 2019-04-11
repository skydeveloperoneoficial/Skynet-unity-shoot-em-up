using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeBase : MonoBehaviour
{
    [SerializeField] private int life= 1;
    [SerializeField] private float barlife;
    [SerializeField]private SpriteRenderer sprite_;
    [SerializeField] private Color damageColor;
    public void Damage(int damageCount)
    {
        life -= damageCount;
        int zero = 0;
        if (life <= zero)
        {

            // Dead!
            OnDestroy();
        }
        else
        {
            StartCoroutine(TakingDamage());
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
        else
        {
            StartCoroutine(TakingDamage());
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

    public SpriteRenderer Sprite_
    {
        get
        {
            return sprite_;
        }

        set
        {
            sprite_ = value;
        }
    }
    #endregion
    private IEnumerator TakingDamage()
    {
        sprite_.color = damageColor ;

        yield return new WaitForSeconds(0.1f);
        sprite_.color = Color.white;



    }
}
