using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GefestCapital
{
    public class ButtonWithText : UIElement
    {
        [SerializeField] private TextMeshProUGUI m_textTMP;
        [SerializeField] private string text;
        public Action OnClick;
        private void Start()
        {
            m_textTMP.text = text;
        }

        public override void CreateData()
        {
            Data = new ButtonData();
        }
    }
}


