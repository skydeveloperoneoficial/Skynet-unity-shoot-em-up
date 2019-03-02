using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitObject : MonoBehaviour
{

    [SerializeField] private float xmin, xmax, Ymin, Ymax;
    [SerializeField] private bool maxMin = true;
    #region Propriedades Get Set
    public float Xmin
    {
        get
        {
            return xmin;
        }

        set
        {
            xmin = value;
        }
    }

    public float Xmax
    {
        get
        {
            return xmax;
        }

        set
        {
            xmax = value;
        }
    }

    public float Ymin1
    {
        get
        {
            return Ymin;
        }

        set
        {
            Ymin = value;
        }
    }

    public float Ymax1
    {
        get
        {
            return Ymax;
        }

        set
        {
            Ymax = value;
        }
    }
    // Retorna Booleno
    public bool MaxMin
    {
        get
        {
            return maxMin;
        }

        set
        {
            maxMin = value;
        }
    }

    #endregion
    // Update is called once per frame
    void Update()
    {
        CheckLimit();
    }
    public virtual bool Enable()
    {
        return MaxMin;
    }
    private void CheckLimit()
    {
        //Checa se esta ativado
        if (MaxMin)
        {

            int two = 2;
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, xmin, xmax),
                Mathf.Clamp(transform.position.y, Ymin, Ymax),
               two * transform.position.z

            );
        }
    }
}