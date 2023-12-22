using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider sliderSaut;
    [SerializeField] private UnityEngine.UI.Slider sliderVitesse;

    public static float saut { get; private set; }
    public static float vitesse { get; private set; }

    [SerializeField]private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        //sliders qui modifie la vitesse du joueur et sa force de saut
        menu.SetActive(false);
        sliderSaut.onValueChanged.AddListener((value) => //r�cupere la valeur du slider
        {
            saut = value;
        });

        sliderVitesse.onValueChanged.AddListener((value) => //r�cupere la valeur du slider
        {
            vitesse = value;
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //affiche le menu quand le joueur fait "P"
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
