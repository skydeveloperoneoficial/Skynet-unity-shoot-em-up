using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeBaseRender : MonoBehaviour
{
    
    [SerializeField]private SpriteRenderer sprite_;
    [SerializeField] private Color damageColor;
   
   
   
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
    public  IEnumerator TakingDamage()
    {
        sprite_.color = damageColor ;

        yield return new WaitForSeconds(0.1f);
        sprite_.color = Color.white;



    }
}
