using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class invData : MonoBehaviour
{   
    // item number vars
    public static float wheatCount;


    // gui vars
    public TMP_Text wheatCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wheatCounter.text = "Wheat: "+wheatCount;
    }
}
