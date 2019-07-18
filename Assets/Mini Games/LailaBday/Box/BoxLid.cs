using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLid : MonoBehaviour
{
    private Vector2 startPos;
    public float moveDist = 1f;
    public float downSpeed = .1f;
    public float upSpeed = .1f;

    private bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        EventManager.StartListening("Game Win", Won);
    }

    // Update is called once per frame
    void Update()
    {
        if (!won) {
            if (startPos.y < transform.position.y) {
                transform.position -= new Vector3(0, downSpeed,0)*Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                transform.position += new Vector3(0, upSpeed,0);
            }

            if (transform.position.y >= startPos.y + moveDist) {
                EventManager.TriggerEvent("Game Win");
            }
        }
    }

    void Won() {
        won = true;
    }
}
