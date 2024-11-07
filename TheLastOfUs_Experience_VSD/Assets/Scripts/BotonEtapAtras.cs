using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonEtapAtras : MonoBehaviour
{
    public CanvasGroup[] paginas;
    private int paginaActual = 0;
    public float duracionTransicion = 0.5f;

    public void OnButtonClick()
    {
        // Ocultar la página actual con fade-out
        if (paginas[paginaActual] != null)
        {
            CanvasGroup paginaOcultar = paginas[paginaActual];
            DOTween.To(() => paginaOcultar.alpha, x => paginaOcultar.alpha = x, 0, duracionTransicion)
                .OnComplete(() =>
                {
                    paginaOcultar.gameObject.SetActive(false);

                    // Decrementar el índice para pasar a la página anterior
                    paginaActual = (paginaActual - 1 + paginas.Length) % paginas.Length;

                    // Mostrar la página anterior con fade-in
                    if (paginas[paginaActual] != null)
                    {
                        CanvasGroup paginaMostrar = paginas[paginaActual];
                        paginaMostrar.alpha = 0; // Asegurarse de que empiece invisible
                        paginaMostrar.gameObject.SetActive(true);
                        DOTween.To(() => paginaMostrar.alpha, x => paginaMostrar.alpha = x, 1, duracionTransicion);
                    }
                });
        }
    }
}
