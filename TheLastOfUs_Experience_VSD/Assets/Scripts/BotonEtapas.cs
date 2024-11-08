using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotonEtapas : MonoBehaviour
{
    public CanvasGroup[] paginas;
    private int paginaActual = 0; // Índice de la página en la que estamos
    public float duracionTransicion = 0.5f;

    private void Start()
    {
        // Inicializar para que solo la primera página esté activa
        ActivarSoloPaginaActual();
    }

    private void ActivarSoloPaginaActual()
    {
        // Desactivar todas las páginas excepto la actual
        for (int i = 0; i < paginas.Length; i++)
        {
            if (paginas[i] != null)
            {
                paginas[i].gameObject.SetActive(i == paginaActual);
                paginas[i].alpha = i == paginaActual ? 1 : 0;
            }
        }
    }

    // Método para avanzar a la siguiente página
    public void OnButtonClickAdelante()
    {
        // Confirmar página actual antes de avanzar
        Debug.Log("Página actual antes de avanzar: " + paginaActual);

        // Guardar el índice anterior
        int paginaAnterior = paginaActual;

        // Actualizar el índice de la página actual antes de animar
        paginaActual = (paginaActual + 1) % paginas.Length;
        Debug.Log("Nuevo índice después de avanzar: " + paginaActual);

        // Ocultar la página anterior con fade-out
        if (paginas[paginaAnterior] != null)
        {
            CanvasGroup paginaOcultar = paginas[paginaAnterior];
            DOTween.To(() => paginaOcultar.alpha, x => paginaOcultar.alpha = x, 0, duracionTransicion)
                .OnComplete(() =>
                {
                    paginaOcultar.gameObject.SetActive(false);
                    ActivarSoloPaginaActual(); // Mostrar solo la página actualizada

                    // Mostrar la nueva página con fade-in
                    if (paginas[paginaActual] != null)
                    {
                        CanvasGroup paginaMostrar = paginas[paginaActual];
                        paginaMostrar.alpha = 0;
                        paginaMostrar.gameObject.SetActive(true);
                        DOTween.To(() => paginaMostrar.alpha, x => paginaMostrar.alpha = x, 1, duracionTransicion);
                    }
                });
        }
    }

    // Método para retroceder a la página anterior
    public void OnButtonClickAtras()
    {
        // Confirmar página actual antes de retroceder
        Debug.Log("Página actual antes de retroceder: " + paginaActual);

        // Guardar el índice anterior
        int paginaAnterior = paginaActual;

        // Actualizar el índice de la página actual antes de animar
        paginaActual = (paginaActual - 1 + paginas.Length) % paginas.Length;
        Debug.Log("Nuevo índice después de retroceder: " + paginaActual);

        // Ocultar la página anterior con fade-out
        if (paginas[paginaAnterior] != null)
        {
            CanvasGroup paginaOcultar = paginas[paginaAnterior];
            DOTween.To(() => paginaOcultar.alpha, x => paginaOcultar.alpha = x, 0, duracionTransicion)
                .OnComplete(() =>
                {
                    paginaOcultar.gameObject.SetActive(false);
                    ActivarSoloPaginaActual(); // Mostrar solo la página actualizada

                    // Mostrar la nueva página con fade-in
                    if (paginas[paginaActual] != null)
                    {
                        CanvasGroup paginaMostrar = paginas[paginaActual];
                        paginaMostrar.alpha = 0;
                        paginaMostrar.gameObject.SetActive(true);
                        DOTween.To(() => paginaMostrar.alpha, x => paginaMostrar.alpha = x, 1, duracionTransicion);
                    }
                });
        }
    }
}