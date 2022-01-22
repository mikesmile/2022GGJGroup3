using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class ButtonGo : MonoBehaviour
{
    public Button btnGo;
    public Button btnExit;
    // Start is called before the first frame update
    void Start()
    {
        btnGo.onClick.AddListener(BtnGo);
        btnExit.onClick.AddListener(BtnExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnGo()
    {
        SceneManager.LoadScene(1);
    }
    public void BtnExit()
    {
        Application.Quit();
    }
}
