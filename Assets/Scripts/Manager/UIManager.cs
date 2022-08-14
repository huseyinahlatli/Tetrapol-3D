using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI redObjectsText;
    [SerializeField] public GameObject fadePanel;

    private void Update()
    {
        redObjectsText.text = GameManager.gameManager.collectableObject.ToString() + " / 10";
    }
}
