using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosureTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TestClosure()
    {
        List<Func<int>> delegates = new List<Func<int>>();
        for (int i = 0; i < 10; i++)
        {
            int j = i;
            delegates.Add(() =>
            {
                Debug.Log(j);
                return j;
            });
        }

        foreach (var element in delegates)
        {
            element.Invoke();
        }
    }
}