using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace GefestCapital
{
    public class MainScreen : ScreenBaseElement
    {
        protected override void Start()
        {
            base.Start();
            if (Data != null)
            {
                ScreenData mathingData =  FilesHandle.Instance.CheckElementMathing<ScreenData>(Data.ID);
                Data = mathingData ?? Data;
            }
        }

        protected override void SaveChildElements()
        {
            NestedElement[] buttonElements = transform.GetComponentsInChildren<NestedElement>();
            foreach (var buttonElement in buttonElements)
            {
                buttonElement.SaveElement();
            }
        }

        public override void SetData(Data data)
        {
            Data = data as ScreenData;
            OnDataSet();
        }

        public override void CreateData()
        {
            SetData(new ScreenData());
        }
    }
}