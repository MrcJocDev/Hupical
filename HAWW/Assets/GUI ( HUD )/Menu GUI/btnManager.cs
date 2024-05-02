using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnManager : MonoBehaviour
{
    public Button playBTN;
    public Button exitBtn;
    void Start()
    {

    }

    void Update()
    {
        playBTN.onClick.AddListener(onPlayClick);
        
    }

    public void onPlayClick(){
        SceneManager.LoadScene(1);
        
    }

    public void onExitClick(){
        Application.Quit();
    }
    
}
