using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public float[] scaleSequence = new float[] { 0.9f, 1.1f, 0.9f, 1 };
    public int scaleIndex = 0;
    public float scale;
    private Action callback;

    void Start()
    {
        scale = scaleSequence[scaleIndex];
        transform.localScale = Vector3.one * scale;
    }

    private IEnumerator doScale()
    {
        while (scaleIndex < scaleSequence.Length - 1)
        {
            scale += (scaleSequence[scaleIndex + 1] - scaleSequence[scaleIndex]) / 10;
            transform.localScale = Vector3.one * scale;
            if (Math.Abs(scale - scaleSequence[scaleIndex + 1]) < 0.01f)
                scaleIndex++;
            yield return new WaitForEndOfFrame();
        }
        if (callback != null)
        {
            callback();
            callback = null;
        }
    }

    public void Show(Action cb)
    {
        callback = cb;
        scaleIndex = 0;
        scale = scaleSequence[scaleIndex];
        StartCoroutine(doScale());
    }

    public void Hide(Action cb)
    {
        scale = scaleSequence[0];
        transform.localScale = Vector3.one * scale;
        if (cb != null)
            cb();
    }
}
