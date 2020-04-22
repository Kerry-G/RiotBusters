﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float duration = 2f;

    void Start()
    {
        Invoke("StartFade", 5f);
    }

    void StartFade() {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(Fade(canvasGroup));
    }

    IEnumerator Fade(CanvasGroup canvasGroup) {
        float counter = 0f;
        float start = 0f;
        float end = 1f;

        while(counter < duration) {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}