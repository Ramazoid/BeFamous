using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//класс для работы с динамическим поведение элементов UI(появление/исчезновение)
public class ScaleManager : MonoBehaviour
{
    public Dictionary<string, MonoBehaviour> scalers = new Dictionary<string, MonoBehaviour>();
    private static ScaleManager INSTA;

    void Start()
    {
        INSTA = this;
        Scaler[] s1 = FindObjectsOfType<Scaler>();
        foreach (Scaler s in s1)
        {
            scalers.Add(s.name, s);
            s.Hide(null);
        }
    }

    internal static void Show(string scalerName, Action callback)
    {
        Scaler s = INSTA.scalers[scalerName] as Scaler;
        if (s == null)
            throw new Exception($"Scaler {scalerName} not found");
        s.Show(callback);
    }

    internal static void Hide(string scalerName, Action callback)
    {
        Scaler s = INSTA.scalers[scalerName] as Scaler;
        if (s == null)
            throw new Exception($"Scaler {scalerName} notfound");
        s.Hide(callback);
    }
}
