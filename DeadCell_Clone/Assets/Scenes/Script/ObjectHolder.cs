using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public GameObject sharedObject;
    public GameObject invent;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public static ObjectHolder Instance;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(sharedObject);
        DontDestroyOnLoad(invent);
        DontDestroyOnLoad(gameObject1);
        DontDestroyOnLoad(gameObject2);
        Instance = this;
    }
}
