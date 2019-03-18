using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportObject : ScriptGlobal
{
    private Camera cam_;
    [SerializeField]private Transform point;
    // Start is called before the first frame update
    protected override void Start()
    {
        cam_ = Camera.main;
        
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void OnCollisionEnter2D(Collision2D collision)
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

        
        
        base.OnCollisionEnter2D(collision);
    }
}
