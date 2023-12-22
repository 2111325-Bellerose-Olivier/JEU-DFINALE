using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMechant : MonoBehaviour
{
    [SerializeField] private GameObject cubeModel;
    [SerializeField] private GameObject[] posSpawn;
    [SerializeField] private GameObject[] posArrive;
    private bool peutSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= 4; i++){
            int rand_spawn = Random.Range(0,posSpawn.Length);
            GameObject cube = Instantiate(cubeModel, posSpawn[rand_spawn].transform.position, Quaternion.identity);
            if(i == 0) { cube.layer = LayerMask.NameToLayer("cubeSpawn"); }
        }
    }

    //update qui créer de nouveaux cubes rouges quand ceux d'avant sont détruit
    private void Update()
    {
        if (peutSpawn)
        {
            peutSpawn = false;
            for (int i = 0; i <= 4; i++)
            {
                int rand_spawn = Random.Range(0, posSpawn.Length);
                GameObject cube = Instantiate(cubeModel, posSpawn[rand_spawn].transform.position, Quaternion.identity);
            }
        }
    }

    //détruit les cubes rouges actuelles et indique aux prochains cube d'apparaitre
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("cubeSpawn"))
        {
            Destroy(other.gameObject);
            peutSpawn = true;
            Debug.Log("hahahahhahhahahahha");
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("cube"))
        {
            Destroy(other.gameObject);
            peutSpawn = true;
            Debug.Log("hahahahhahhahahahha");
        }
    }
}
