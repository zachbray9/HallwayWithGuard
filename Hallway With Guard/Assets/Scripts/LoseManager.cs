using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseManager : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {

        if(collider.gameObject.name == "First Person Player")
        {
            //Debug.Log("You lose!");
            SceneManager.LoadScene(3);
        }

    }

}
