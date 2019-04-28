
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateDirectionSpawn
{
    SpawnVetical,
    SpawnHorizontal,
    Disable
    
}

public class SpawnControl2D : MonoBehaviour {

    [SerializeField] private Transform spawnPos;
    [SerializeField] private float rateSpawn ,timespawn;
    [SerializeField] private float vRandomMin, vRandomMax, hRandomMin, hRandomMax;//Random Vertical and Horizontal
    [SerializeField] private string tagSpawn = "Spawn", tagPlayer = "ShipEnemy", tagenemy = "Enemy";// Def..
    private Transform enemyTransform;
    private Vector3 spawnPositionA, spawnPositionB;


    private bool isPositionPlayer = false;

   

    public StateDirectionSpawn directionSpawn = StateDirectionSpawn.Disable;
    private Transform playerTransform= null;
    #region Propriedes  Get Set
    public string TagSpawn
    {
        get
        {
            return tagSpawn;
        }

        set
        {
            tagSpawn = value;
        }
    }

    public string TagPlayer
    {
        get
        {
            return tagPlayer;
        }

        set
        {
            tagPlayer = value;
        }
    }

    public string Tagenemy
    {
        get
        {
            return tagenemy;
        }

        set
        {
            tagenemy = value;
        }
    }

    public float VRandomMin
    {
        get
        {
            return vRandomMin;
        }

        set
        {
            vRandomMin = value;
        }
    }

    public float VRandomMax
    {
        get
        {
            return vRandomMax;
        }

        set
        {
            vRandomMax = value;
        }
    }

    public float HRandomMin
    {
        get
        {
            return hRandomMin;
        }

        set
        {
            hRandomMin = value;
        }
    }

    public float HRandomMax
    {
        get
        {
            return hRandomMax;
        }

        set
        {
            hRandomMax = value;
        }
    }

    public Transform SpawnPos
    {
        get
        {
            return spawnPos;
        }

        set
        {
            spawnPos = value;
        }
    }

    public float RateSpawn { get => rateSpawn; set => rateSpawn = value; }
    #endregion


    // Use this for initialization
    protected  void Start()
    {
        ActiveSpawner();
        
       
    }
    private void ActiveSpawner()
    {

        InvokeRepeating(TagSpawn, timespawn, rateSpawn);
        
    }
    /// <summary>
    /// Selecione O Tipo que deseja Trabalhar.
    /// </summary>
    private void Spawn()
    {

        switch (directionSpawn)
        {
            // Spawn Vertical 
            #region Spawn  Vertical
            case StateDirectionSpawn.SpawnVetical:
                {
                    
                    isPositionPlayer = !isPositionPlayer;

                     

                    if (isPositionPlayer && playerTransform != null)
                    {
                        spawnPositionA = new Vector3(playerTransform.position.x,
                                                    transform.position.y,
                                                    transform.position.z); //SpawnPoint
                    }
                    else
                    {
                        spawnPositionA = new Vector3(Random.Range(VRandomMin, VRandomMax),
                                                    transform.position.y,
                                                    transform.position.z);//Spawn Random
                    }
                    
                    enemyTransform = Instantiate(spawnPos) as Transform;
                   
                    enemyTransform.position = spawnPositionA;

                }
                break;
            #endregion

            // Spawn Horizontal
            #region Spawn Horizontal
            case StateDirectionSpawn.SpawnHorizontal:
                {
                    
                    isPositionPlayer = !isPositionPlayer;

                     

                    if (isPositionPlayer && playerTransform != null)
                    {
                        spawnPositionA = new Vector3(playerTransform.position.x,
                                                    playerTransform.position.y,
                                                    transform.position.z);//SpawnPoint
                    }
                    else
                    {
                        spawnPositionA = new Vector3(transform.position.x,
                                                    Random.Range(HRandomMin, HRandomMax),
                                                    transform.position.z);//Spawn Random
                    }
                   

                        enemyTransform = Instantiate(spawnPos) as Transform;
                    

                    enemyTransform.position = spawnPositionA;
                    
                }
                break;
            #endregion
            case StateDirectionSpawn.Disable:
                
                try
                {
                    
                }
                // Desable spawn
                catch
                {
                    Debug.LogWarning("DisableSpawn");
                }
                
                break;
            default:
                break;
        }

       
    }
    



}
