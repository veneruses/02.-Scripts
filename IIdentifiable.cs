using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIdentifiable
{
    [SerializeField] public string Id { get; set; }
    public void SetId();
    public string GetId();
}
