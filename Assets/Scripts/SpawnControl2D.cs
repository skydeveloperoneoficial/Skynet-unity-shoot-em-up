
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

    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private float rateSpawn = 2f,timespawn;
    [SerializeField] private float vRandomMin = 1.0f, vRandomMax = 1.0f, hRandomMin, hRandomMax;//Random Vertical and Horizontal
    [SerializeField] private string tagSpawn = "Spawn", tagPlayer = "ShipEnemy", tagenemy = "Enemy";
   
    

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
            return spawnPos[0];
        }

        set
        {
            spawnPos[0] = value;
        }
    }
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
            case StateDirectionSpawn.SpawnVetical:
                {
                    
                    isPositionPlayer = !isPositionPlayer;

                    Vector3 spawnPosition;

                    if (isPositionPlayer && playerTransform != null)
                    {
                        spawnPosition = new Vector3(playerTransform.position.x,
                                                    transform.position.y,
                                                    transform.position.z); //SpawnPoint
                    }
                    else
                    {
                        spawnPosition = new Vector3(Random.Range(VRandomMin, VRandomMax),
                                                    transform.position.y,
                                                    transform.position.z);//Spawn Random
                    }
                    
                    var enemyTransform = Instantiate(spawnPos[0]) as Transform;
                   
                    enemyTransform.position = spawnPosition;
                }
                break;
            case StateDirectionSpawn.SpawnHorizontal:
                {
                    
                    isPositionPlayer = !isPositionPlayer;

                    Vector3 spawnPosition;

                    if (isPositionPlayer && playerTransform != null)
                    {
                        spawnPosition = new Vector3(playerTransform.position.x,
                                                    playerTransform.position.y,
                                                    transform.position.z);//SpawnPoint
                    }
                    else
                    {
                        spawnPosition = new Vector3(transform.position.x,
                                                    Random.Range(HRandomMin, HRandomMax),
                                                    transform.position.z);//Spawn Random
                    }
                    
                    var enemyTransform = Instantiate(spawnPos[0]) as Transform;

                    enemyTransform.position = spawnPosition;
                }
                break;
            case StateDirectionSpawn.Disable:
                
                try
                {
                    
                }
                // Alerta.
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
