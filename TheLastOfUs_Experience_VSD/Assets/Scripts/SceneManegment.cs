using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManegment : MonoBehaviour
{
    public string sceneName;
    private CanvasGroup groupPanelToFade;
    [SerializeField] private GameObject panelToFade;

    // Start is called before the first frame update
    void Start()
    {
        groupPanelToFade = panelToFade.GetComponent<CanvasGroup>();
        FadeOut();


    }
    public void fadeIn()
    {
        panelToFade.SetActive(true);
        groupPanelToFade.DOFade(1, 1).OnComplete(() =>
        {
            //StartCoroutine(WaitToChangeScene());
            ChangeScene();
        }
        );

    }
    private void FadeOut()
    {
        groupPanelToFade.DOFade(0, 1).OnComplete(() =>
        {
            
            panelToFade.SetActive(false);
        });
    }
    private void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneName);
    }
    private IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(1f);
        
    }

}
