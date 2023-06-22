using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace GefestCapital
{
    [System.Serializable]
    public class ButtonScreenOpenerData : ButtonData
    {
        public string IdElementToOpen;
        public string PrefabNameElementToOpen;
    }
}