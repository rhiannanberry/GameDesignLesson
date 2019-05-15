using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Useful for 2D game where you have an object that needs to stay in the screen
//Is NOT physics based
public class Bounds : MonoBehaviour
{
    private Vector2 _minScreenBounds, _maxScreenBounds;
    private float _objectWidth;
    private float _objectHeight;

    void Start()
    {
        _minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));    
        _maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));    
        
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _minScreenBounds.x + _objectWidth, _maxScreenBounds.x - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _minScreenBounds.y + _objectHeight, _maxScreenBounds.y - _objectHeight);
        transform.position = viewPos;
    }
}
