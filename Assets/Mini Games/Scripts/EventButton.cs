using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : MonoBehaviour
{
    public void TriggerEvent(string myEvent) {
        EventManager.TriggerEvent(myEvent);
    }
}
