using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public bool fade;

    [Range(0, 10)]
    public float timeLengthFrom, timeLengthTo;
    public AnimationCurve curveFrom, curveTo;
    Image _img;
    RectTransform _rt;
    // Start is called before the first frame update
    void Awake()
    {
        _img = GetComponent<Image>();
        _rt = GetComponent<RectTransform>();
        _img.enabled = true;
        _img.SetAlpha(0f);
    }

    void OnEnable() {
        //TransitionFrom();
        EventManager.StartListening("Transition From", TransitionFrom);
        EventManager.StartListening("Transition To", TransitionTo);
    }


    void TransitionTo() {
        _img.SetAlpha(1f);
        float expectedValue = curveTo[curveTo.length - 1].value;
        bool triggered = false;
        StartCoroutine(Coroutines.InterpolateCurve(curveTo, timeLengthTo,(value)=> {
            if (fade) {
                _img.SetAlpha(value);
            } else {
                _rt.anchorMin = new Vector2(value-1f, _rt.anchorMin.y);
                _rt.anchorMax = new Vector2(value, _rt.anchorMax.y);
            }

            if (!triggered && value == expectedValue) {
                triggered = true;
                EventManager.TriggerEvent("End Scene");
            }

        }));
    }

    void TransitionFrom() {
        _img.SetAlpha(1f);
        float expectedValue = curveFrom[curveFrom.length - 1].value;
        bool triggered = false;
        StartCoroutine(Coroutines.InterpolateCurve(curveFrom, timeLengthFrom,(value)=> {
            if (fade) {
                _img.SetAlpha(1f - value);
            } else {
            
                _rt.anchorMin = new Vector2(value, _rt.anchorMin.y);
                _rt.anchorMax = new Vector2(value + 1f, _rt.anchorMax.y);
            }
            if (!triggered && value == expectedValue) {
                triggered = true;
                EventManager.TriggerEvent("Start Scene");
            }
        }));
    }
}
