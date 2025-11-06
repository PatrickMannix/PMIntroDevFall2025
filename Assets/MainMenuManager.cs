using UnityEngine;

using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UIElements; 

public class MainMenuManager : MonoBehaviour
{
    private void OnEnable()
    {
        
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null) return;
        var root = uiDocument.rootVisualElement;

        
        Button startGameButton = root.Q<Button>("StartGameButton");

        
        if (startGameButton != null)
        {
            
            startGameButton.clicked += StartGame;
        }
        else
        {
            Debug.LogError("StartGameButton not found in UXML. Check the ID.");
        }
    }

    
    private void StartGame()
    {
        Debug.Log("Starting Game...");
        
        SceneManager.LoadScene("GameScene");
    }
}