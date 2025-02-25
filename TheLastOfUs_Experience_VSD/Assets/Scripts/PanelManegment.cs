﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelManegment : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject panelNegro;


    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(WaitTheFade());     
        
    }
    public void MovePanel()
    {
        // Mueve el panel hacia la posición de `targetPosition` en `moveDuration` segundos.
        // setEase es para la suavidad "OJO"
        //panelToFade.SetActive(true); Ya está activo desde inicio, entonces no hay que usarlo
        panelNegro.transform.DOMove(target.position, 1).SetEase(Ease.InOutQuad);
    }
    private IEnumerator WaitTheFade()
    {
        yield return new WaitForSeconds(1.2f);
        MovePanel();
    }
    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
