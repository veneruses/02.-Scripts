using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GefestCapital;
using UnityEngine;

namespace GefestCapital
{
    public class CorouselWithPhotosScreen : ScreenBaseElement
    {
        protected override void SaveChildElements()
        {
            BlockElement[] Elements = transform.GetComponentsInChildren<BlockElement>();
            foreach (var element in Elements)
            {
                element.SaveElement();
            }
        }

        public override void CreateData()
        {
            Data = new ScreenData();
            OnDataSet();
        }
        
        protected virtual void LoadAndInstantiateElements<T,K>()where T: ButtonData where K: NestedElement
        {
            LoadAndInstantiateElements<UiElementData, BlockElement>();
        }
    }
}   
