using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Several different movement schemas for 2D games
public class Move2D : MonoBehaviour
{
    public enum MoveType { topview, sideview};
    public MoveType moveType;

    [Range(.5f,100f)]
    public float moveSpeed;

    private float _horizontal;
    private float _vertical;

    void FixedUpdate() {
        if (GameState.state == State.inGame) {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _vertical = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(_horizontal, _vertical, 0) * moveSpeed * Time.deltaTime;
        }
    }
}
