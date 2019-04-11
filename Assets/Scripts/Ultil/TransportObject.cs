using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportObject : MonoBehaviour
{
    private Camera cam_;
    [SerializeField]private Transform point;
    // Start is called before the first frame update
    protected  void Start()
    {
        cam_ = Camera.main;
        
       
    }

    // Update is called once per frame
    public  void Update()
    {
        
    }
    public  void OnCollisionEnter2D(Collision2D collision)
    {
        if (point == null)
        {
            Debug.LogWarning("");
        }
        else
        {
            collision.transform.position = point.transform.position;
			float posX= 0,posY= 0,posZ = -10;
            cam_.gameObject.transform.position = point.position + new Vector3(posX,posY,posZ);
        }

        
        
        
    }
}
