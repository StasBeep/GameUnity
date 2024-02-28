using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGun : MonoBehaviour
{
    // Переменные под оружие
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject avtomat;
    [SerializeField] GameObject shotgun;

    // Определение каким оружием будем стрелять
    int weapon = 0;

    // Функция включения и выключения свойства видимости объекта
    public void ChooseWeapon(string weapon)
    {
        switch (weapon)
        {
            case "Пистолет":
                pistol.SetActive(true);
                avtomat.SetActive(false);
                shotgun.SetActive(false);
                break;
            case "Автомат":
                pistol.SetActive(false);
                avtomat.SetActive(true);
                shotgun.SetActive(false);
                break;
            case "Дробовик":
                pistol.SetActive(false);
                avtomat.SetActive(false);
                shotgun.SetActive(true);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Переключение между оружиями на нажаие клавиш клавиатуры 1 2 3
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseWeapon("Пистолет");
            weapon = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChooseWeapon("Автомат");
            weapon = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChooseWeapon("Дробовик");
            weapon = 3;
        }

        // Если зажата левая кнопка мыши
        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case 1:
                    // Объект пистолета должен найти скрипт Gun и вызвать функцию Shoot()
                    pistol.GetComponent<Gun>().Shoot();
                    // pistol.GetComponent<Gun>().Update();
                    break;
                case 2:
                    avtomat.GetComponent<Gun>().Shoot();
                    // avtomat.GetComponent<Gun>().Update();
                    break;
                case 3:
                    shotgun.GetComponent<Gun>().Shoot();
                    // shotgun.GetComponent<Gun>().Update();
                    break;
            }
        }
    }
}
