using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private bool isReadyToChangeScene = false;

    private int countingPeople = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReadyToChangeScene && countingPeople.Equals(2))
        {
            isReadyToChangeScene = true;
            TransitionManager.Self.LoadScene("Stage2");
        }
    }
    
    void OnTriggerStay2D(Collider2D collider)
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Equals("Player") || collision.name.Equals("Player2"))
        {
            countingPeople++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player") || collision.name.Equals("Player2"))
        {
            countingPeople--;
        }
    }
}
