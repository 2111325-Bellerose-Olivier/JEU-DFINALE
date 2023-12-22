using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feu : MonoBehaviour
{

    //fonction pour quand le joueur ramène le bois au spawn
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("joueur"))
        {
            if(BoisPlatforme.boisPris)
            {
                Debug.Log("jeu gagné!");
            }
        }
    }
}
