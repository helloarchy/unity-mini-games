using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _gameManager = GameObject.Find("Game Manager").gameObject.GetComponent<GameManager>();
        
        _button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log($"Button {gameObject.name} was clicked");
        _gameManager.StartGame();
    }
}
