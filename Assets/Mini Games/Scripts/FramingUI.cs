using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FramingUI : MonoBehaviour
{
    public TextMeshProUGUI gameName;
    public TextMeshProUGUI gameInstructions;
    // Start is called before the first frame update
    void Start()
    {
        gameName.text = MiniGameManager.gameName;
        gameInstructions.text = "INSTRUCTIONS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
