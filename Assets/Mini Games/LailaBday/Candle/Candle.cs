using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public static int numCandles = 0;
    public Sprite outCandleSprite;
    private SpriteRenderer sr;

    void Start()
    {
        numCandles++;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PutOut() {
        GetComponent<Animator>().enabled = false;
        sr.sprite = outCandleSprite;
        numCandles--;
        CheckWin();
    }

    public void OnMouseDown() {
        if (GetComponent<Animator>().enabled)
            PutOut();
    }

    private void CheckWin() {
        if (numCandles == 0)
            EventManager.TriggerEvent("Game Win");
    }
}
