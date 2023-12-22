using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurClavier : MonoBehaviour
{
    //variables pour le mouvement du joueur
    [Header("Mouvements")]
    public float vitesseMouv; //default 50
    public float sautForce;   //default 5

    public float groundDrag;  //default 5

    //variable pour le jump
    [Header("Vérification platforme")]
    public float hauteurJoueur;
    public LayerMask estPlatforme;
    bool aTerre;

    //variable de l'orientation du joueur
    public Transform orientation;

    //variable de l'input joueur
    float inputHorizon;
    float inputVerti;

    Vector3 directionMouv;
    Rigidbody rb;

    //variables pour les sons
    [SerializeField] private AudioSource sonSaut;
    [SerializeField] private AudioSource sonPas;


    // Start is called before the first frame update
    void Start()
    {
        //characterController = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //gère le saut, marche moyen
        aTerre = Physics.Raycast(transform.position, Vector3.down, hauteurJoueur * 0.5f + 0.2f, estPlatforme);
        InputJoueur();

        if (aTerre) { rb.drag = groundDrag; }
        else rb.drag = 0;
    }

    void FixedUpdate()
    {
        BougerJoueur();
        SonPas();
    }

    //obtien l'input du joueur
    private void InputJoueur()
    {
        inputHorizon = Input.GetAxisRaw("Horizontal");
        inputVerti = Input.GetAxisRaw("Vertical");
    }

    //fait jouer un son de pas quand le joueur marche
    private void SonPas() 
    {
        if (inputHorizon>0.1f||inputVerti>0.1f)
        {
            sonPas.mute = false;
        }
        else { sonPas.mute = true; }
    }

    private void BougerJoueur()
    {
        //calcule la direction du mouvement
        directionMouv = orientation.forward * inputVerti + orientation.right * inputHorizon;
        rb.AddForce(directionMouv.normalized * vitesseMouv,ForceMode.Force);

        //fonctionnalité de jump qui marche moyen, pas utile pour le jeu de toute façon
        if (Input.GetButtonDown("Jump") && aTerre)
        {
            rb.AddForce(Vector3.up * sautForce, ForceMode.Impulse);
            sonSaut.Play();
        }
    }
}
