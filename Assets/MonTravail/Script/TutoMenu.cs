using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TutoMenu : MonoBehaviour
{
    [SerializeField]private GameObject menu;
    void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) //affiche le menu quand le joueur fait "K"
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }
    }
}
