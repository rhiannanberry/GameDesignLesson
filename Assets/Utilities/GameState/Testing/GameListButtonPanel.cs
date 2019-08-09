using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class GameListButtonPanel : MonoBehaviour
{
    [SerializeField] GameObject _buttonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach( Transform child in transform ) {
            GameObject.Destroy(child.gameObject);
        }
        AddButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddButtons() {
        bool first = true;

        foreach(MiniGame m in GameStateManager.Instance.MiniGames) {
            GameObject go  = Instantiate(_buttonPrefab, transform);
            Button b = go.GetComponent<Button>();
            TextMeshProUGUI t = go.GetComponentInChildren<TextMeshProUGUI>();

            if (m.Played || first) {
                t.text = m.GameName;
            } else {
                t.text = "???";
            }

            if ( m.Won || first ) {
                b.onClick.AddListener(() => GameStateManager.Instance.StartRun(m.SceneName));
            } else {
                b.interactable = false;
            }

            first = false;
        }
    }
}
