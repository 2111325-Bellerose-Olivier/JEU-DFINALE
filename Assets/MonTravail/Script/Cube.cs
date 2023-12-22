using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameObject cube;
    [SerializeField] private float vitesse = 0.01f;
    private Vector3 spawn = new Vector3(0, 4.23999977f, 0);
    // Start is called before the first frame update
    void Start()
    {
        cube = gameObject;
    }

    //fait bouger les cubes rouges. double leur vitesse si le joueur a récupéré le bois
    // Update is called once per frame
    void Update()
    {
            Vector3 currentPosition = cube.transform.position;

            currentPosition.z -= vitesse;
        if(BoisPlatforme.boisPris)
        {
            currentPosition.z -= vitesse;
        }

            cube.transform.position = currentPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("joueur"))
        {
            if (BoisPlatforme.boisPris)
            {
                other.gameObject.transform.position = spawn;
            }
        }
    }
}
