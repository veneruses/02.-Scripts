using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GefestCapital
{
    [System.Serializable]
    public class TransitionButtonData : ButtonData
    {
        public string GameObjectToTransitId;
        public string GameObjectToTransitPrefab;
    }
}

