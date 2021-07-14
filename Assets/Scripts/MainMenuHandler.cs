using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
        GameManager.Instance.PlayerName = _inputField.text;
    }

    public void QuitGame()
    {
        GameManager.Instance.SaveHighScore();
        Application.Quit();
    }
}
