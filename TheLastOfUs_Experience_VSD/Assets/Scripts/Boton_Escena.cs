using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton_Escena : MonoBehaviour
{
    [Header("Configuración de la Escena")]
    public string nombreEscena; // Nombre de la escena a cargar, asignado desde el inspector.

    [Header("Configuración de Transición")]
    public float duracionFade = 1f; // Duraci del fade.

    // CanvasGroup para controlar la opacidad
    [SerializeField] private CanvasGroup fadeCanvas;

    private void Start()
    {

        /*
        // Crear un CanvasGroup en tiempo de ejecuci si no existe uno en el GameObject
        fadeCanvas = gameObject.AddComponent<CanvasGroup>();
        fadeCanvas.alpha = 0; // Comienza totalmente transparente*/
    }

    // Este m騁odo se llamar・al hacer clic en el bot
    public void CambiarEscenaConFade()
    {
        StartCoroutine(FadeOutAndChangeScene());
    }

    private IEnumerator FadeOutAndChangeScene()
    {
        /* float tiempoTranscurrido = 0f;

         // Hacer el fade-out
         while (tiempoTranscurrido < duracionFade)
         {
             tiempoTranscurrido += Time.deltaTime;
             fadeCanvas.alpha = Mathf.Clamp01(tiempoTranscurrido / duracionFade);
             yield return null;
         }*/

        yield return new WaitForSeconds(1.2f);
        // Cambiar a la nueva escena despu駸 de que termine el fade-out
        SceneManager.LoadScene(nombreEscena);
    }

}
