using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControlPlayer : MonoBehaviour
{
    // Для меню
    [SerializeField] GameObject pauseUI;
    bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        // Проверка при запуске игры на сохранение положения игрока
        // по координате Х
        if (PlayerPrefs.HasKey("playerX"))
        {
            // Локально определилои координаты сохранения
            float x = PlayerPrefs.GetFloat("playerX");
            float y = PlayerPrefs.GetFloat("playerY");
            float z = PlayerPrefs.GetFloat("playerZ");

            // телепортировали игрока на нужное место
            transform.position = new Vector3(x, y, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // При нажатии на Esc (Dowm обязательно!)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                // закрыть окно паузы
                pauseUI.SetActive(false);
                pause = !pause;

                Cursor.lockState = CursorLockMode.Locked;

                // Блокировка движения
                GetComponent<PlayerMove>().enabled = true;


                // Блокировка вращения
                GetComponent<PlayerLook>().enabled = true;

                // Блокировка стрельбы
                // GetComponent<PlayerBaxGun>().enabled = true;
            }
            else
            {
                // открыть окно паузы
                pauseUI.SetActive(true);
                pause = !pause;

                Cursor.lockState = CursorLockMode.None;

                // Блокировка движения
                GetComponent<PlayerMove>().enabled = false;

                // Блокировка вращения
                GetComponent<PlayerLook>().enabled = false;

                // Блокировка стрельбы
                // GetComponent<PlayerBaxGun>().enabled = false;
            }
        }
    }
}
