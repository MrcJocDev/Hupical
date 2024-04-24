using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(changeScene);
    }

    static void changeScene(){
        SceneManager.LoadScene("playScene");
        Debug.Log("Button clicked");
    }
}
