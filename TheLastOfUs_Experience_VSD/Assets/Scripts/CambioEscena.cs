using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CambioEscena : MonoBehaviour
{
    // Nombre de la escena a cargar
    public string sceneName;
    private CanvasGroup canvasPalFadeIn;
    [SerializeField] private GameObject panelToFadeIn;

    private void Start()
    {
        canvasPalFadeIn = panelToFadeIn.GetComponentInChildren<CanvasGroup>();
    }
    public void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneName);
    }
    
}
