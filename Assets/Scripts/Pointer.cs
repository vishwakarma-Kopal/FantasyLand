using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    #region Singleton
    public static Pointer Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    #endregion

    [HideInInspector]
    public Pointable CurrentPointable;
    private void OnDisable()
    {
        CurrentPointable.OnExit?.Invoke();
    }
}
