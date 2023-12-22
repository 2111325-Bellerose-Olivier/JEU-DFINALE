using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// script pas utilisé, était utilisé avant que je redesign le jeu
/// </summary>
public class PlatformProcScript : MonoBehaviour
{

    private GameObject platActuelle;
    private GameObject platProchaine;
    private GameObject platFin;
    // Start is called before the first frame update
    void Start()
    {
        platFin = GameObject.Find("fin");
        platActuelle = gameObject;

        if (platActuelle.transform.position.z + 1 < platFin.transform.position.z)
        {
            platProchaine = Instantiate(platActuelle, Vector3.zero, Quaternion.identity);
            platProchaine.transform.position = new Vector3(platActuelle.transform.position.x, platActuelle.transform.position.y, platActuelle.transform.position.z + 3);
        }
    }
}
