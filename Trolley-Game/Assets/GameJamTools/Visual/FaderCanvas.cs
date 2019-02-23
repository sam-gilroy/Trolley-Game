using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJamTools;
using UnityEngine.Events;
using UnityEngine.UI;

public class FaderCanvas : MonoBehaviour {
    [SerializeField] List<UnityEvent> events = new List<UnityEvent>();
    [SerializeField] Image image;

    public void FadeIn(Color color, float fadeSpeed = 0.1f)
    {
        image.color = new Color(color.r, color.g, color.b, 0);
        StartCoroutine(FadeInRoutine(fadeSpeed));
    }

    public void FadeIn(float fadeSpeed = 0.1f)
    {
        StartCoroutine(FadeInRoutine(fadeSpeed));
    }

    public void PlayShit()
    {
        foreach (UnityEvent eventt in events)
        {
            eventt.Invoke();
        }
    }

    IEnumerator FadeInRoutine(float fadeSpeed)
    {
        while (image.color.a < 1)
        {
            image.color += new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        PlayShit();
    }
}
