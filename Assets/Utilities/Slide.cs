using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class Slide : MonoBehaviour
{
    public AnimationCurve curve;
    public EventPair[] events;
    RectTransform rt;

    void Awake() {
        foreach (EventPair p in events) {
            EventManager.StartListening(p.trigger, p.triggerActions.Invoke);
        }
        //EventManager.StartListening("Transition From", TransitionFrom);
    }

    public void TransitionFrom() {
        rt = GetComponent<RectTransform>();
        float expectedValue = curve[curve.length - 1].value;
        StartCoroutine(Coroutines.InterpolateCurve(curve, 1.5f,(value)=> {
            if (value == expectedValue) {
                gameObject.SetActive(false);
                return;
            }
            rt.anchorMin = new Vector2(2f*value - 1f, rt.anchorMin.y);
            rt.anchorMax = new Vector2(2f*value, rt.anchorMax.y);
        }));
    }

    public void TransitionTo() {
        rt = GetComponent<RectTransform>();
        float expectedValue = curve[curve.length - 1].value;
        StartCoroutine(Coroutines.InterpolateCurve(curve, 1.5f,(value)=> {
            if (value == expectedValue) {
                gameObject.SetActive(false);
                return;
            }
            rt.anchorMin = new Vector2(2f*value, rt.anchorMin.y);
            rt.anchorMax = new Vector2(2f*value +1f, rt.anchorMax.y);
        }));
    }
}
