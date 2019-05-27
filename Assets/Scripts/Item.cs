using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Items
    {
        UPDATEPOWERUPSHOT,
        DesableItems
    }
    public Items itens;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        SelectedItem();
    }
    public  void SelectedItem()
    {
        switch (itens)
        {
            case  Items.UPDATEPOWERUPSHOT:
            Debug.Log("Item Obitido.");
            break; 

            case Items.DesableItems:
            Debug.Log("Item desativado.");
            break;
            
            default:

            break;
            
        }
    }

}
