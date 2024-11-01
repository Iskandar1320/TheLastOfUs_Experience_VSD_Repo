using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Nombre de la escena a cargar
    public string sceneName;

    public void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneName);
    }
}
