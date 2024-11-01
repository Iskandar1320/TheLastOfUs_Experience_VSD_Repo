using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManegment : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelToFade;
    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }
    private void fadeIn()
    {
        panelToFade.DOFade(1, 1);
    }
    private void FadeOut()
    {
        panelToFade.DOFade(0, 1);
    }
    
}
