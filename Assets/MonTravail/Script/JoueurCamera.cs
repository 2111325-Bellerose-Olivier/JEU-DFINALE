using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    //gestion du mouse mouvement
    [SerializeField]
    private float vitesseSourieHorizontal = 1f;
    [SerializeField]
    private float vitesseSourieVertical = 1f;
    private float rotX = 0f;
    private float rotY = 0f;
    [SerializeField]
    private Camera cameraJoueur;
    
    //gameobject du joueur
    private GameObject joueur;

    void Start()
    {
        joueur = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gestion de la caméra selon les mouvements de la sourie
        rotY += Input.GetAxis("Mouse X") * vitesseSourieHorizontal;
        rotX -= Input.GetAxis("Mouse Y") * vitesseSourieVertical;
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        cameraJoueur.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
        joueur.transform.eulerAngles = new Vector3(0f, rotY, 0f);
    }
}
