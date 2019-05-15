using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public static bool inRun;
    public static State state = State.inScene;
}

public enum State{inScene, inGame, inEnter, inExit, inPause};