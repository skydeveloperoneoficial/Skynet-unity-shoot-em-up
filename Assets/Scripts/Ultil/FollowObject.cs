using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{ 
    [SerializeField] private GameObject target;
    private Vector3 positionTarget;
    [SerializeField]private float speed;

    // Update is called once per frame
    public  void Update()
    { 
        Follow();
        
    }
    private void Follow()
    {
        positionTarget = new Vector3(target.transform.position.x, target.transform.position.y,transform.position.z);
        Vector3 tempPosition = Vector3.Lerp(transform.position, positionTarget, speed);
        transform.position = tempPosition;
    }

   

    // public float Speed { get => speed; set => speed = value; }
    // public GameObject Target { get => target; set => target = value; }
}
