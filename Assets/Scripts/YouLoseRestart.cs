using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouLoseRestart : MonoBehaviour
{
    void Start()
    {
        // Включение курсора на окне проигрыша
        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart() {
        // print("Перезагрузка");
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        print("Выход");
    }
}
