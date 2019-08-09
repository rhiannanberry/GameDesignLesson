using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run 
{
    private int _lives = 3;
    private MiniGame[] _list;
    private MiniGame _currentGame;

    public Run( MiniGame[] list, MiniGame currentGame ) {
        _list = list;
        _currentGame = currentGame;
    }
}
