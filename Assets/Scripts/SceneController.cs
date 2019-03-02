﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneController : ScriptGlobal {

    //Autor SkyDeveloper
    public   void SetScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene); 
    }
    public  void SetSceneAsync(string nextscene)
    {
        SceneManager.LoadSceneAsync(nextscene);
    }
    protected override void Start()
    {
       
    }

}
