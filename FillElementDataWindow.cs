using System;
using System.Collections;
using System.Collections.Generic;
using GefestCapital;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillElementDataWindow : MonoBehaviour
{
    [SerializeField] private TMP_InputField m_inputField;
    [SerializeField] private string m_photoPath;
    [SerializeField] private Sprite m_sprite;
    [SerializeField] private Button m_OkButton;
    [SerializeField] private UIElement m_elementToSpawn;

    private void Start()
    {
        
    }

    public void Init(Transform transformToSpawn,Action OnDataSet)
    {
        m_OkButton.onClick.AddListener(()=>OnDataSet?.Invoke());
    }
}
