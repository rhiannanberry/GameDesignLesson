using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    float moveUp = 1.5f;
    public Vector2 target;
    void Start()
    {
        target = transform.position;
        EventManager.StartListening("Game Win", MoveDog);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, 5f * Time.deltaTime );
    }

    public void MoveDog() {
        target += new Vector2(0,moveUp);
    }
}
