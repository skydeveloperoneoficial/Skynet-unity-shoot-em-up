using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts
{

    public enum LevelState_
    {
        GameOver= 1,
        Paused= 2,
        Start= 3,
        Loading=4

    }
     public class LevelController: MonoBehaviour
    {
        public static LevelController levelController;
        public LevelState_ levelState_;
        public GameObject[] TextsHud;
        private void Start()
        {
            levelController = this;
        }
        private void Update()
        {
            
        }
        public void SetStateLevel( LevelState_ levelState_)
        {
            levelState_ = LevelState_.Start;
        }

        public void CheckState()
        {
            switch (levelState_)
            {
                case LevelState_.GameOver:
                    break;
                case LevelState_.Paused:
                    break;
                case LevelState_.Start:
                    break;
                case LevelState_.Loading:
                    break;
                default:
                    break;
            }
        }
    }
}
