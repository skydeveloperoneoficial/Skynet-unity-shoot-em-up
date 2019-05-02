using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveBoss : MonoBehaviour
{

    [SerializeField] private float speedX,speedY,targetX,targetY;
    
   
    [SerializeField]private  Vector2 direction  ;
    [SerializeField] private  Vector2 moviment;
    
    public static bool enableBossX= false;
    public static bool enableBossY= false;
    public static bool enableTeleport;
   

    public float SpeedX { get => speedX; set => speedX = value; }
    public float SpeedY { get => speedY; set => speedY = value; }
    public float TargetX { get => targetX; set => targetX = value; }
    public float TargetY { get => targetY; set => targetY = value; }


    // Start is called before the first frame update
    private void Start() {
       
   }

    // Update is called once per frame
    private void Update() {
        
        CheckMovement();
        StopMovimentBoss();
        TelepotBossMovimentBoss();
        
    }
    public  void CheckMovement()
    {
        moviment = new Vector2(speedX* direction.x,speedY* direction.y );
    }
    public  void TelepotBossMovimentBoss()
    {
        if (enableTeleport)
        {
            transform.position = new Vector2(targetX, TargetY);
        }
            
    }
    public void StopMovimentBoss()
    {
        if(enableBossX)
        {
            speedX = 0;
        }
        if(enableBossY)
        {
            speedY= 0;
        }

        
        
    }

     private void FixedUpdate() {
         
        
         GetComponent<Rigidbody2D>().velocity = moviment;
         
     }
    
}
