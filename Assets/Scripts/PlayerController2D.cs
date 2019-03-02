using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace Assets.Scripts
{
    public class PlayerController2D : ScriptGlobal
    {


        protected string horizontal = "Horizontal";
        protected string vertical = "Vertical";
        protected string moveMouseX = "Mouse X";//exo //Autor Skydevelopers
        protected string moveMouseY = "Mouse Y";//exo //Autor Skydevelopers


        [SerializeField] private bool MouseAxis = false,MouseRotation_= false;

        /// <summary>
        /// 1 - The speed of the playerinput
        /// </summary>
        [SerializeField] private Vector2 speed = new Vector2(0, 0);// padrao


        // 2 - Store the movement and the component
        private Vector2 movement;
        private Vector2 mouseMoviment;
        private   float rotationMouse;
         

        // Update is called once per frame

        public override void Update()
        {
            CheckInputAxis();
            CheckInputMouse();
            base.Update();
        }
        public void CheckInputAxis()
        {
            // 3 - Retrieve axis information
            float inputX =  CrossPlatformInputManager.GetAxis(horizontal);
            float inputY =  CrossPlatformInputManager.GetAxis(vertical);
            

            // 4 - Movement per direction
            movement = new Vector2(
              speed.x * inputX ,
              speed.y * inputY );
            

        }
        private void CheckInputMouse()
        {
            float inputXMouse = CrossPlatformInputManager.GetAxis(moveMouseX);
            float inputYMouse = CrossPlatformInputManager.GetAxis(moveMouseY);
            float inputRotation2D = CrossPlatformInputManager.GetAxis("Mouse ScrollWheel");

            // mouse

            mouseMoviment = new Vector2(
                speed.x * inputXMouse , //Autor Skydevelopers
                speed.y * inputYMouse );//Autor Skydevelopers

            rotationMouse += inputRotation2D;
        }

        public override void FixedUpdate()
        {
            GetObj();
            base.FixedUpdate();
        }
        private void GetObj()
        {
            // Movimento do objeto.
            GetComponent<Rigidbody2D>().velocity = movement;

            //Autor Skydevelopers
            //ativar mouse
            if (MouseAxis)
            {
                GetComponent<Rigidbody2D>().velocity = mouseMoviment;
            }
            if (MouseRotation_)
            {
                GetComponent<Rigidbody2D>().rotation = rotationMouse;
            }
            
        }

        

        public Vector2 Speed
        {
            get { return speed= new Vector2(transform.position.x,transform.position.y); }
            set { speed = value; }
        }

        public bool ActiveMouse
        {
            get { return MouseAxis; }
            set { MouseAxis = value; }
        }


    }
}
