using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace Assets.Scripts
{
    enum SelectInput
    {
        InputMouseAxis,
        InputAxis,
        inputMouseRotation


    }
    public class PlayerController2D : ScriptGlobal
    {


        protected string horizontal = "Horizontal";
        protected string vertical = "Vertical";
        protected string moveMouseX = "Mouse X";//exo //Autor Skydevelopers
        protected string moveMouseY = "Mouse Y";//exo //Autor Skydevelopers
         private float inputRotation2D;
        [SerializeField] private SelectInput selectInput;
        private float inputX, inputY;
        //[SerializeField] private bool MouseAxis = false,MouseRotation_= false;

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
             InputRotation2D = CrossPlatformInputManager.GetAxis("Mouse ScrollWheel");

            // mouse

            mouseMoviment = new Vector2(
                speed.x * inputXMouse , //Autor Skydevelopers
                speed.y * inputYMouse );//Autor Skydevelopers

            rotationMouse += InputRotation2D;
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
          
            switch (selectInput)
            {
                case SelectInput.InputMouseAxis:
                    GetComponent<Rigidbody2D>().velocity = mouseMoviment;
                    break;
                case SelectInput.InputAxis:
                    GetComponent<Rigidbody2D>().velocity = movement;
                    break;
                case SelectInput.inputMouseRotation:
                    GetComponent<Rigidbody2D>().rotation = rotationMouse;
                    break;
                default:
                    break;
            }

        }



        public Vector2 Speed
        {
            get { return speed= new Vector2(transform.position.x,transform.position.y); }
            set { speed = value; }
        }

        

        public float InputRotation2D
        {
            get
            {
                return inputRotation2D;
            }

            set
            {
                inputRotation2D = value;
            }
        }
        public float InputX { get { return inputX; } set { inputX = value; } }
        public float InputY { get { return inputY; } set { inputY = value; } }
    }
}
