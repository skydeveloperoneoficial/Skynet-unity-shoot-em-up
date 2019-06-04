using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Threading;


public class WaveControl : MonoBehaviour
{
   
    private Ship ship;
    [SerializeField]private float[] colldownWaves;
    private SpawnControl2D spawnControl2D;
    // Start is called before the first frame update
    void Start()
    {
       
        FindObJ();
        StartCorotine_();
        RestartState();
      
    }
    // Restaura quando Inicia
    private void RestartState()
    {
        Ship.currentAmountProjetile_= 0;
        BasicMoveBoss.enableBossX = false;
        ProjetileBosses.shoot = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void StartCorotine_()
    {
      
        StartCoroutine(WaveCont());
        
        
    }
    
    public  void StopCorotina_()
    {
       StopCoroutine(WaveCont());
    }
    private void FindObJ()
    {
        ship =  FindObjectOfType(typeof(Ship))as Ship;
        spawnControl2D = FindObjectOfType(typeof(SpawnControl2D))as SpawnControl2D;
    }
   
    public IEnumerator WaveCont()
    {
        
        // Primera Weve
        Debug.Log("Wave1");
        
        yield return new WaitForSeconds(colldownWaves[0]);
         
      
        
        // Segunda Wave
        Debug.Log("Wave2");

        

        yield return new WaitForSeconds(colldownWaves[1]);
        // terceira Wave
        Debug.Log("Wave3");
        
       

        yield return new WaitForSeconds(colldownWaves[2]);
        // Quarta Wave
        Debug.Log("Wave4");
        yield return new WaitForSeconds(colldownWaves[3]);
        // Quinta Wave
        Debug.Log("Wave5");
        yield return new WaitForSeconds(colldownWaves[4]);
        
        // Sexta Wave
        Debug.Log("Wave6");

        yield return new WaitForSeconds(colldownWaves[5]);

        // Final Wave
        Debug.Log("Disabiltar Spawn");
        spawnControl2D.directionSpawn = StateDirectionSpawn.Disable;// Para de spawnar
        
        Debug.Log("WaveFinal");
      
        // O boss aparece
        yield return new WaitForSeconds(colldownWaves[6]);
        // Aparece o Boss
        
       ship.GameObjects_[1].gameObject.SetActive(true);
        //boss.gameObject.SetActive(true);
        
        

        yield return new WaitForSeconds(colldownWaves[7]);
        
        Debug.Log("Parar Boss e inicia Batalha");
        //Thread.Sleep(10000);
        
       
        //scrollingBackground.Speed = 0; // Para o BsG
        // desativar o Boss
        BasicMoveBoss.enableBossX = true;
     
///Fim

        //Wave BattleBoss  Onda de balalha  do boss
        
        // tiro do boss fica visivel
        ProjetileBosses.shoot = true;


    }
}
