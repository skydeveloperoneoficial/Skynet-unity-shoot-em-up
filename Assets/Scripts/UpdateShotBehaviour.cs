using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateShotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]private int timeDestroy;// So mente nese  campo
     //private Ship ship;
      #region propriedades get Set

    public int TimeDestroy
    {
        get
        {
            return timeDestroy;
        }

        set
        {
            timeDestroy = value;
        }
    }
     public void OnTimeDestroy()
    {
        Destroy(gameObject, TimeDestroy);
    }

    #endregion
    private void Start()
    {
        OnTimeDestroy();
    }
    public void Reload_()
    {
       Ship.currentAmountProjetile_=0;
       Ship.stopProjetile = true;
    }
  
    

    // Update is called once per frame
     void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Ship"){
            SoundEffectControl.Instance.MakeColetableSound();
            
            Destroy(gameObject);
            Reload_();
            
            
        }
        
    }
}
