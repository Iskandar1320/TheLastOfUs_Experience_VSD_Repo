using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ControladorAños : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider slider;        // El slider que controla los años

    [Header("Objetos de los años")]

    #region objetosAño
    [SerializeField] private GameObject objetoNulo;   // Objeto para el estado nulo o inicial (valor 0)
    [SerializeField] private GameObject objetoAño1;
    [SerializeField] private GameObject objetoAño2;
    [SerializeField] private GameObject objetoAño3;
    [SerializeField] private GameObject objetoAño4;
    [SerializeField] private GameObject objetoAño5;
    [SerializeField] private GameObject objetoAño6;
    [SerializeField] private GameObject objetoAño7;
    [SerializeField] private GameObject objetoAño8;
    [SerializeField] private GameObject objetoAño9;
    [SerializeField] private GameObject objetoAño10;
    [SerializeField] private GameObject objetoAño11;
    [SerializeField] private GameObject objetoAño12;
    [SerializeField] private GameObject objetoAño13;
    [SerializeField] private GameObject objetoAño14;
    [SerializeField] private GameObject objetoAño15;
    #endregion

    private Dictionary<int, (GameObject objeto, CanvasGroup canvasGroup)> diccionarioAños =
        new Dictionary<int, (GameObject, CanvasGroup)>();

    private int añoActual = -1; // Inicializado en -1 para evitar conflicto inicial

    void Start()
    { 
        // Establecer el valor inicial del slider en 1
        slider.value = 1;  // Forzamos que comience en 1

        // Inicializa el diccionario con los años y los GameObjects asociados
        InicializarDiccionario();

        // Desactiva todos los objetos al inicio
        foreach (var entry in diccionarioAños)
        {
            entry.Value.objeto.SetActive(false);
        }

        // Muestra el objeto correspondiente al año inicial (valor actual del slider)
        CambiarAño(slider.value);
    }

    private void InicializarDiccionario()
    {
        // Añadir el objeto nulo al valor 0
        diccionarioAños.Add(0, (objetoNulo, AsegurarCanvasGroup(objetoNulo)));

        // Añadir los objetos de año comenzando desde el año 1
        diccionarioAños.Add(1, (objetoAño1, AsegurarCanvasGroup(objetoAño1)));
        diccionarioAños.Add(2, (objetoAño2, AsegurarCanvasGroup(objetoAño2)));
        diccionarioAños.Add(3, (objetoAño3, AsegurarCanvasGroup(objetoAño3)));
        diccionarioAños.Add(4, (objetoAño4, AsegurarCanvasGroup(objetoAño4)));
        diccionarioAños.Add(5, (objetoAño5, AsegurarCanvasGroup(objetoAño5)));
        diccionarioAños.Add(6, (objetoAño6, AsegurarCanvasGroup(objetoAño6)));
        diccionarioAños.Add(7, (objetoAño7, AsegurarCanvasGroup(objetoAño7)));
        diccionarioAños.Add(8, (objetoAño8, AsegurarCanvasGroup(objetoAño8)));
        diccionarioAños.Add(9, (objetoAño9, AsegurarCanvasGroup(objetoAño9)));
        diccionarioAños.Add(10, (objetoAño10, AsegurarCanvasGroup(objetoAño10)));
        diccionarioAños.Add(11, (objetoAño11, AsegurarCanvasGroup(objetoAño11)));
        diccionarioAños.Add(12, (objetoAño12, AsegurarCanvasGroup(objetoAño12)));
        diccionarioAños.Add(13, (objetoAño13, AsegurarCanvasGroup(objetoAño13)));
        diccionarioAños.Add(14, (objetoAño14, AsegurarCanvasGroup(objetoAño14)));
        diccionarioAños.Add(15, (objetoAño15, AsegurarCanvasGroup(objetoAño15)));
    }

    private CanvasGroup AsegurarCanvasGroup(GameObject objeto)
    {
        CanvasGroup canvasGroup = objeto.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = objeto.AddComponent<CanvasGroup>();
        }
        return canvasGroup;
    }

    public void CambiarAño(float nuevoAño)
    {
        int añoConvertido = Mathf.RoundToInt(nuevoAño);
        CambiarAño(añoConvertido);
    }

    private void CambiarAño(int nuevoAño)
    {
        if (añoActual == nuevoAño)
        {
            // Si el año no ha cambiado, no hacer nada
            return;
        }

        // Desactiva el objeto del año actual solo si es diferente al nuevo año
        if (diccionarioAños.ContainsKey(añoActual))
        {
            var (objetoActual, _) = diccionarioAños[añoActual];
            objetoActual.SetActive(false);
        }

        // Activa el objeto del nuevo año
        if (diccionarioAños.ContainsKey(nuevoAño))
        {
            var (objetoNuevo, _) = diccionarioAños[nuevoAño];
            objetoNuevo.SetActive(true);
        }

        // Actualiza el año actual al nuevo año
        añoActual = nuevoAño;
    }
}
