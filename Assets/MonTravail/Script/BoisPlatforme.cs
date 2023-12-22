using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoisPlatforme : MonoBehaviour
{
    public static bool boisPris = false;

    //fonction qui met boisPris � true sur le joueur a ramass� le bois
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("joueur"))
        {
            boisPris = true;
        }
    }
}
