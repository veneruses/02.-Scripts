using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GefestCapital;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GefestCapital
{
    public class TextImageElement : NestedElement
    {
        [SerializeField] private string m_description;
        [SerializeField] private Image m_image;
        [SerializeField] private TextMeshProUGUI m_text;

        public override void CreateData()
        {
            SetData(Data = new UiElementData());
        }

        public override void SetData(Data data)
        {
            if (data is UiElementData dt)
            {
                Data = dt;
            }

            UIElement screen = transform.GetComponentsInParent<UIElement>()
                .Where(element => element != this)
                .FirstOrDefault();
            (Data as UiElementData).IdScreenRelated = screen.Data.ID;
            (Data as UiElementData).GOToPinName = transform.parent.name;
            OnDataSet();
        }

        protected override void OnDataSet()
        {
            UiElementData currentData = Data as UiElementData;
            if (String.IsNullOrEmpty(m_description))
            {
                m_description = currentData.Text;
            }

            Sprite sprite = Resources.Load<Sprite>(currentData.ImagePath);
            if (sprite)
            {
                m_image.sprite = sprite;
            }

            base.OnDataSet();
        }
    }
}