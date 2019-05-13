using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateShotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]private int timeDestroy;// So mente nese  campo
     
     [SerializeField]private float amountProjetileUp,amountProjetileSet;
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

    public float AmountProjetileUp { get => amountProjetileUp; set => amountProjetileUp = value; }
    public float AmountProjetileSet { get => amountProjetileSet; set => amountProjetileSet = value; }

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
     // ele Vai  modificar
    public  void Setprojetile(float amountProjetile){
        Ship.Rateprojetile = amountProjetile;
    }
    //adiciona mais progesivamente
    public void  LevelUpProjetile(float amountProjetile)
    {
        Ship.Rateprojetile-= amountProjetile;
    }
  
    

    // Update is called once per frame
     void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Ship"){
            SoundEffectControl.Instance.MakeColetableSound();
            
            Destroy(gameObject);
            //LevelUpProjetile(amountProjetileUp);
            //Debug.Log("Aumeto o Tiro"+amountProjetileUp--);
            Setprojetile(amountProjetileSet);
            Reload_();
            
            
        }
        
    }
}
