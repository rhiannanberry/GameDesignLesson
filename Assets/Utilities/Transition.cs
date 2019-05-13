using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{

    [Range(0, 10)]
    public float timeLength;
    Image _img;
    // Start is called before the first frame update
    void Awake()
    {
        _img = GetComponent<Image>();
        SetImageAlpha(1.0f);
    }

    void OnEnable() {
        FadeOut();
        StartCoroutine(StartAfterFade(timeLength));
        EventManager.StartListening("Transition Out", FadeIn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeOut() {
        _img.CrossFadeAlpha(0f, timeLength, true);
    }

    void FadeIn() {
        _img.CrossFadeAlpha(1f, timeLength, true);
        StartCoroutine("EndAfterFade");
    }

    IEnumerator StartAfterFade(float time) {
        yield return new WaitForSeconds(time);
        EventManager.TriggerEvent("Start Scene");
    }

    IEnumerator EndAfterFade() {
        yield return new WaitForSeconds(timeLength);
        EventManager.TriggerEvent("End Scene");
    }

    void SetImageAlpha(float a) {
        Color temp = _img.color;
        temp.a = a;
        _img.color = temp;
    }
}
