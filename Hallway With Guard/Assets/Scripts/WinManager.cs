using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {

        if(collider.gameObject.name == "First Person Player")
        {
            //Debug.Log("You win!");
            SceneManager.LoadScene(2);
        }

    }
}
