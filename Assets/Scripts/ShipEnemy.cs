using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipEnemy : ScriptGlobal
{
    
    
    private BasicMoviment2D enemyMove;
    
    [SerializeField]private int timeDestroy;
    [SerializeField] private AudioClip enemyShotSound;
    //Wave Bullet Enemy
    [SerializeField]private float waverate=1.1f;//Padrao
    [SerializeField] private float wavecooldown=4.0f;//Padrao
    private float thisValue= 0;

    private LimitObject limitObject;
    private Ship ship;

    #region propriedades get Set
    
    
    #endregion
    // Start is called before the first frame update
    protected override void Start()
    {
  
        OnTimeDestroy();
        FindObject();

    }

    public void MakerEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
    private void FindObject()
    {
        enemyMove = FindObjectOfType(typeof(BasicMoviment2D)) as BasicMoviment2D;

        ship = FindObjectOfType(typeof(Ship)) as Ship;

        

    }

    // Update is called once per frame
    public override void Update()
    {
        
        if (wavecooldown > thisValue)
        {
            wavecooldown -= Time.deltaTime;
        }


        if (wavecooldown <= thisValue)
        {
            waverate = wavecooldown;
            //MakerEnemyShotSound();


        }

        base.Update();
    }
    public void OnTimeDestroy()
    {
        Destroy(gameObject, timeDestroy);
    }
   

}
