using Mhmtbtn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public int sliceNumber=0;

    public GameEvent end; 

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        sliceNumber++;

        if (sliceNumber == 2)
        {
            Debug.Log("Oyun Bitti");
            end.Raise();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    
}
