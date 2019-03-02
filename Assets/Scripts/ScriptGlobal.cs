using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class ScriptGlobal : MonoBehaviour {


    //Clsss function Global
    //Autor Skydevelopers
    //Simple Work
    public virtual void FixedUpdate() { }
    public virtual void Awake() { }
    public virtual void LateUpdate() { }
    public virtual void Update() { }
    public virtual void OnGUI() { }
    public virtual void OnDisable() { }
    public virtual void OnEnable() { }
    protected virtual void Start() { }
    public virtual void Reset() { }
    public virtual void OnTriggerEnter2D(Collider2D collider) { }// Colision Trigger 2D
    public virtual void OnCollisionEnter2D(Collision2D collision) { }// Colision not trigger 2D
    public virtual void OnCollisionEnter(Collision collision) { }
    public virtual void OnTriggerStay2D(Collider2D other) { }// 2D
    public virtual void OnCollisionStay(Collision collisionInfo) { }
    public virtual void OnTriggerEnter(Collider other) { }
    public virtual void OnTriggerExit(Collider other) { }
    public virtual void OnTriggerExit2D(Collider2D other) { }

}
