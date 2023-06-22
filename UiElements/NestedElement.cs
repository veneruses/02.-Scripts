using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GefestCapital
{
    public class NestedElement : UIElement
    {
        public override void CreateData()
        {
            Data = new ButtonData();
            ScreenBaseElement screen = transform.GetComponentInParent<ScreenBaseElement>();
            (Data as ButtonData).IdScreenRelated = screen.Data.ID;
            (Data as ButtonData).GOToPinName = transform.parent.name;
        }

        public override void SaveElement()
        {
            Save(this);
        }
    }
}

