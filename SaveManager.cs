using System;
using System.Collections;
using System.Collections.Generic;
using GefestCapital;
using UnityEngine;

public class SaveManager: MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    public bool saveAfterExit = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        // ScreenData[] screenDatas = new ScreenData[10];
        // int counter = 0;
        // foreach (var element in screenDatas)
        // {
        //     element.PrefabName = "name "+counter;
        //     element.ID = counter.ToString();
        //     element.xxx2x = (counter * counter).ToString();
        // }
    }
}
