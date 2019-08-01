using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class MiniGameSelectManager : MonoBehaviour
{
    public MiniGamesList miniGamesList;
    public GameObject miniGameButtonPrefab;
    public Transform buttonContainer;

    private GameObject[] miniGameButtonObject;

    string nextSceneName;

    void Awake()
    {
        SaveLoad.LoadData(miniGamesList);

        UpdateGameListUI();
        
        // Should already have buttons in container
        // If not, click "Update Game List UI" button in inspector
        AddButtonListeners();
        
        EventManager.StartListening("End Scene", LoadScene);
    }

    void Update()
    {
        
    }
    public void UpdateGameListUI() {
        DeleteOldButtons();
        AddNewButtons();
    }



    private void DeleteOldButtons() {
        foreach(Button b in buttonContainer.GetComponentsInChildren<Button>()) {
            DestroyImmediate(b.gameObject);
        }
    }

    private void AddNewButtons() {
        MiniGameDetails[] miniGames = miniGamesList.GameList;
        miniGameButtonObject = new GameObject[miniGames.Length];
        foreach (MiniGameDetails d in miniGames) {
            GameObject go = Instantiate(miniGameButtonPrefab, buttonContainer);
            go.GetComponentInChildren<TextMeshProUGUI>().text = d.GameName;
        }
    }

    private void AddButtonListeners() {
        MiniGameDetails[] miniGames = miniGamesList.GameList;

        Button[] buttons = buttonContainer.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++) {
            MiniGameDetails m = miniGames[i];
            buttons[i].onClick.AddListener(() => nextSceneName = m.SceneName);
            buttons[i].onClick.AddListener(() => EventManager.TriggerEvent("Start Exit"));
            buttons[i].onClick.AddListener(() => EventManager.TriggerEvent("Transition To"));
            if (!m.Won && i != 0) {
                buttons[i].interactable = false;
            }
            if (!m.Played) {
                buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "?";
            }
        }
    }


    private void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    private void LoadScene() {
        SceneManager.LoadScene(nextSceneName);
    }


}
