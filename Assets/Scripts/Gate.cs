using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.name.Contains("Player") && collider.name.Contains("Player2"))
        {
            TransitionManager.Self.LoadScene("Stage2");
        }
    }

}
