using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpen : MonoBehaviour {

    public GameObject objSwitchTrack;

    [SerializeField] private float trackLeftX = -1.7f;
    [SerializeField] private float trackRightX = 1.7f;
    [SerializeField] private bool leaningLeft = true;

    public Image fadeOutImg;
    public float fadeSpeed = 0.8f;

    public string levelName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickAction()
    {
        SwitchDirection();
    }

    public void SwitchDirection()
    {
        if (leaningLeft)
        {
            RightTrigger();
        }
        else
        {
            LeftTrigger();
        }
        StartCoroutine(FadeAndLoadScene(0, 1));
    }

    public void LeftTrigger()
    {
        objSwitchTrack.transform.position = new Vector3(trackLeftX, transform.position.y, transform.position.z);
        leaningLeft = true;
    }

    public void RightTrigger()
    {
        objSwitchTrack.transform.position = new Vector3(trackRightX, transform.position.y, transform.position.z);
        leaningLeft = false;
    }

    private IEnumerator Fade(float fadeStart, float fadeEnd)
    {
        Debug.Log("Fading");
        if (fadeStart > fadeEnd)
        {
            Debug.Log("In");
            while (fadeStart >= fadeEnd)
            {
                SetColorImage(ref fadeStart, fadeEnd);
                //SetColorImage (ref fadeEnd, fadeStart);
                yield return null;
            }
            fadeOutImg.enabled = false;
        }
        else
        {
            Debug.Log("Out");
            fadeOutImg.enabled = true;
            while (fadeStart < fadeEnd)
            {
                SetColorImage(ref fadeStart, fadeEnd);
                //SetColorImage (ref fadeEnd, fadeStart);
                yield return null;
            }
        }
    }

    private IEnumerator FadeAndLoadScene(float fadeStart, float fadeEnd)
    {
        //yield return Fade(fadeStart, fadeEnd);
        StartCoroutine(Fade(0, 1));
        SceneManager.LoadScene(levelName);
        yield return null;
    }

    private void SetColorImage(ref float alpha, float end)
    {
        fadeOutImg.color = new Color(fadeOutImg.color.r, fadeOutImg.color.g, fadeOutImg.color.b, alpha);
        if (alpha < end)
        {
            alpha += Time.deltaTime * (1.0f / fadeSpeed);
        }
        else
        {
            alpha -= Time.deltaTime * (1.0f / fadeSpeed);
        }
    }

    void OnEnable()
    {
        StartCoroutine(Fade(1, 0));
    }
}
