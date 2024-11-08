using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotonEtapas : MonoBehaviour
{
    public CanvasGroup[] paginas;
    private int paginaActual = 0; // �ndice de la p�gina en la que estamos
    public float duracionTransicion = 0.5f;

    private void Start()
    {
        // Inicializar para que solo la primera p�gina est� activa
        ActivarSoloPaginaActual();
    }

    private void ActivarSoloPaginaActual()
    {
        // Desactivar todas las p�ginas excepto la actual
        for (int i = 0; i < paginas.Length; i++)
        {
            if (paginas[i] != null)
            {
                paginas[i].gameObject.SetActive(i == paginaActual);
                paginas[i].alpha = i == paginaActual ? 1 : 0;
            }
        }
    }

    // M�todo para avanzar a la siguiente p�gina
    public void OnButtonClickAdelante()
    {
        // Confirmar p�gina actual antes de avanzar
        Debug.Log("P�gina actual antes de avanzar: " + paginaActual);

        // Guardar el �ndice anterior
        int paginaAnterior = paginaActual;

        // Actualizar el �ndice de la p�gina actual antes de animar
        paginaActual = (paginaActual + 1) % paginas.Length;
        Debug.Log("Nuevo �ndice despu�s de avanzar: " + paginaActual);

        // Ocultar la p�gina anterior con fade-out
        if (paginas[paginaAnterior] != null)
        {
            CanvasGroup paginaOcultar = paginas[paginaAnterior];
            DOTween.To(() => paginaOcultar.alpha, x => paginaOcultar.alpha = x, 0, duracionTransicion)
                .OnComplete(() =>
                {
                    paginaOcultar.gameObject.SetActive(false);
                    ActivarSoloPaginaActual(); // Mostrar solo la p�gina actualizada

                    // Mostrar la nueva p�gina con fade-in
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

    // M�todo para retroceder a la p�gina anterior
    public void OnButtonClickAtras()
    {
        // Confirmar p�gina actual antes de retroceder
        Debug.Log("P�gina actual antes de retroceder: " + paginaActual);

        // Guardar el �ndice anterior
        int paginaAnterior = paginaActual;

        // Actualizar el �ndice de la p�gina actual antes de animar
        paginaActual = (paginaActual - 1 + paginas.Length) % paginas.Length;
        Debug.Log("Nuevo �ndice despu�s de retroceder: " + paginaActual);

        // Ocultar la p�gina anterior con fade-out
        if (paginas[paginaAnterior] != null)
        {
            CanvasGroup paginaOcultar = paginas[paginaAnterior];
            DOTween.To(() => paginaOcultar.alpha, x => paginaOcultar.alpha = x, 0, duracionTransicion)
                .OnComplete(() =>
                {
                    paginaOcultar.gameObject.SetActive(false);
                    ActivarSoloPaginaActual(); // Mostrar solo la p�gina actualizada

                    // Mostrar la nueva p�gina con fade-in
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