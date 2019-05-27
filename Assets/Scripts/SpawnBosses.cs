using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBosses : MonoBehaviour
{
   [SerializeField]private Transform prefabOject;
   
    // Start is called before the first frame update
    void Start()
    {
        instatiateBoss();
        
    }
    
    
    public  void instatiateBoss()
    {   
        Instantiate(prefabOject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
