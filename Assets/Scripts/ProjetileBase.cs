using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public abstract class ProjetileBase : LifeBase
{
    // visible inspector,private
    
    [SerializeField] private float timeToLive;// Tempo do Projetil
    [SerializeField] private string tagbject, taghit;

    [SerializeField] private Animator projetileAnimator;
    [SerializeField] private GameObject game_ObjectTarget;
    [SerializeField] private AudioClip damageSoundEffect;
    [SerializeField] private AudioClip Play_Projectile;
    [SerializeField] private bool Animation_ = false;
    [SerializeField] private bool goToRight = true;
   
    //Variable private
   
    
    private void StartGetConponent()
    {
        //basicMoviment2D = FindObjectOfType(typeof(BasicMoviment2D)) as BasicMoviment2D;
        
    }
    private void PlayProjectileSoundEfect()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = Play_Projectile;
        audio.Play();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        StartGetConponent();
        PlayProjectileSoundEfect();
    }

    // Update is called once per frame
    public override void Update()
    {
        DestroyBulletTime();
        base.Update();
    }
    private void DestroyBulletTime()
    {
        Destroy(gameObject, timeToLive);
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == Tagobject)
        {
            ApplyDamege(collider.gameObject);
        }
        base.OnTriggerEnter2D(collider);
    }

    public virtual void ApplyDamege(GameObject gameObject)
    {
        OnAppyDamage();
        SetActiveTarget();
        AddAnimator();
        SoundEffectDamager();

    }
    // Adicina animaçao projetil
    private void AddAnimator()
    {
        if (Animation_)
        {
            try
            {
                projetileAnimator.SetTrigger(Taghit);
            }
            catch
            {
                Debug.LogWarning("Mark off Animation_");
            }
        }
    }
    private void SetActiveTarget()
    {
        game_ObjectTarget.SetActive(false);
    }

    private void SoundEffectDamager()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = damageSoundEffect;
        audio.Play();
    }

    protected abstract void OnAppyDamage();
    // varible public
    #region Variable Public
    

    public float TimeToLive
    {
        get
        {
            return timeToLive;
        }

        set
        {
            timeToLive = value;
        }
    }

    public string Tagobject
    {
        get
        {
            return tagbject;
        }

        set
        {
            tagbject = value;
        }
    }

    public string Taghit
    {
        get
        {
            return taghit;
        }

        set
        {
            taghit = value;
        }
    }

    public AudioClip DamageSoundEffect
    {
        get
        {
            return damageSoundEffect;
        }

        set
        {
            damageSoundEffect = value;
        }
    }

    public GameObject Game_ObjectTarget
    {
        get
        {
            return game_ObjectTarget;
        }

        set
        {
            game_ObjectTarget = value;
        }
    }

    public Animator ProjetileAnimator
    {
        get
        {
            return projetileAnimator;
        }

        set
        {
            projetileAnimator = value;
        }
    }

    public AudioClip Playprojectile
    {
        get
        {
            return Play_Projectile;
        }

        set
        {
            Play_Projectile = value;
        }
    }
    #endregion
}

