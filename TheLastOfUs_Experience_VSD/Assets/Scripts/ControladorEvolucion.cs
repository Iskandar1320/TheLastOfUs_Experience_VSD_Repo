//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ZZ_EvoluciónEtapas : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}


using UnityEngine;
using UnityEngine.UI;

public class ControladorEvolucion : MonoBehaviour
{
    public GameObject[] etapas; // Arreglo que contendrá los objetos de las etapas (Etapa0, Etapa1, etc.)
    public Button botonAdelante; // Botón para avanzar
    public Button botonAtras;    // Botón para retroceder
    public Text[] numeros;       // Números de las etapas en la parte superior para resaltar

    private int etapaActual = 0;

    void Start()
    {
        // Inicializa mostrando solo la primera etapa
        ActualizarEtapas();

        // Asigna funciones a los botones
        botonAdelante.onClick.AddListener(AvanzarEtapa);
        botonAtras.onClick.AddListener(RetrocederEtapa);
    }

    void AvanzarEtapa()
    {
        if (etapaActual < etapas.Length - 1)
        {
            etapaActual++;
            ActualizarEtapas();
        }
    }

    void RetrocederEtapa()
    {
        if (etapaActual > 0)
        {
            etapaActual--;
            ActualizarEtapas();
        }
    }

    void ActualizarEtapas()
    {
        // Activa solo la etapa actual
        for (int i = 0; i < etapas.Length; i++)
        {
            etapas[i].SetActive(i == etapaActual);
        }

        // Actualiza la apariencia de los números
        for (int i = 0; i < numeros.Length; i++)
        {
            if (i == etapaActual)
                numeros[i].color = Color.red; // Resalta el número de la etapa actual
            else
                numeros[i].color = Color.white; // Color normal para los demás números
        }
    }
}
