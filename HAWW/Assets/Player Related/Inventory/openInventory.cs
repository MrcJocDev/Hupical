using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openInventory : MonoBehaviour
{
    public GameObject inventoryUi;
    public bool isINVOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isINVOpen){
            print("sexu boi ");
            isINVOpen = false;
            inventoryUi.SetActive(false);
            
            
        }

        else if(Input.GetKeyDown(KeyCode.E) && !isINVOpen){
            inventoryUi.SetActive(true);
            isINVOpen = true;
        }
    }

}
