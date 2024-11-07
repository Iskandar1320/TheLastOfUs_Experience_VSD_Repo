using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManegment : MonoBehaviour
{
    [SerializeField] private GameObject panelToFade;
    private CanvasGroup groupPanelToFade;
    // Start is called before the first frame update
    void Start()
    {
        groupPanelToFade = panelToFade.GetComponent<CanvasGroup>();
        FadeOut();
    }
    private void fadeIn()
    {
        groupPanelToFade.DOFade(1, 1);

    }
    private void FadeOut()
    {
        groupPanelToFade.DOFade(0, 1).OnComplete(() =>
        {
            panelToFade.SetActive(false);
        });

    }
    
}
