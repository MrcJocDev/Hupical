using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    // timer vars
    public float spawnRate;
    float nextSpawn;
    public bool somebool = true;
    public bool isDay;
    public static bool isDayStc;
    public float dayCount = 0;
    public float dayCountStc = 0f;

    // HUD vars
    public TMP_Text timeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDayStc = isDay;
        dayCountStc = dayCount;
         if(Time.time > nextSpawn && somebool){
            nextSpawn = Time.time + spawnRate;
            timeText.text = "Day: " + dayCount;
            isDay = true;
            somebool = false;
            dayCount += 1f;

         }        

         if(Time.time > nextSpawn && !somebool){
            nextSpawn = Time.time + spawnRate;
            isDay = false;
            somebool = true;
         }

    }


}
