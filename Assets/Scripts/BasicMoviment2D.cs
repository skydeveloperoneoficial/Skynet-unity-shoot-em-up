using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    public class BasicMoviment2D :  MonoBehaviour
    {

        [SerializeField] private Vector2 speed;
        [SerializeField] private Vector2 direction = new Vector2(0, 0).normalized;

        [SerializeField]private Vector2 movement;
        [SerializeField]private  bool disableMove= false;
        private float rotatiomObj;
        [SerializeField] private bool disableRotation = false;

        private  void Update()
        {
            
            CheckMoviment();
            
        }

        private void CheckMoviment()
        {
            if (disableRotation)
            {
                rotatiomObj += movement.x;
                rotatiomObj += movement.y;
            }

            if (disableMove)
            {
                //2D

                movement = new Vector2(
                     speed.x * direction.x,
                     speed.y * direction.y);
            }

        }

        private void FixedUpdate()
        {
            GetObject();
            
        }
        private void GetObject()
        {
            if (disableMove)
            {
                GetComponent<Rigidbody2D>().velocity = movement;
                GetComponent<Rigidbody2D>().rotation = rotatiomObj;
            }
            
        }
        #region  Propriedades Publicas
        public Vector2 Dir
        {
            get { return direction = new Vector2(); }
            set { direction = value.normalized; }
        }
        public Vector2 Speed
        {
            get { return speed = new Vector2(); }
            set { speed = value.normalized; }
        }

        public bool DisableMove
        {
            get
            {
                return disableMove;
            }

            set
            {
                disableMove = value;
            }
        }

        public Vector2 Movement
        {
            get
            {
                return movement;
            }

            set
            {
                movement = value;
            }
        }
        #endregion
    }
}
