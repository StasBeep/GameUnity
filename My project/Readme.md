
> Старый формат кода на стрельбу с разных клавиш
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaxGun : MonoBehaviour
{
    [SerializeField] GameObject rifleStart; // Переменная для координаты выстрела
    [SerializeField] GameObject bullet; // Переменная для пули
    [SerializeField] GameObject bulletSnaper; // Переменная для пули Sniper

    // Переменная для определения есть ли у нас в руках оружие
    public static bool hasWeapon = false;

    void Update() {
        // Если нажали на левую кнопку (0)
        // 2 - колёсико мыши
        // 1 - правая кнопка
        if(Input.GetMouseButtonDown(0) && hasWeapon)
        {
            // переменная  объекта юнити - спавн объекта
            GameObject buf = Instantiate(bullet);

            // передаём заспавненный компонент в скрипт Bullet в функцию setDrection - определение направления полёта пули
            buf.GetComponent<Bullet>().setDirection(transform.forward);

            // Задаём начальное положение пули на карте - начало в новом пустом объекте unity rifleStart, его положение
            // ! Важно определить объекты в unity, иначе будет ошибка
            buf.transform.position = rifleStart.transform.position;
            // Положение (Угол) пули относительно положения угла наклона оружия
            buf.transform.rotation = transform.rotation;

            // Переписали код - угол пули - совпадает с rifleStart положением (его нужно задать)
            //  buf.transform.rotation = rifleStart.transform.rotation;
        }

        // Нажатие на правую кнопку мыши
        if(Input.GetMouseButtonDown(1) && hasWeapon)
        {
            GameObject buf = Instantiate(bulletSnaper);

            buf.GetComponent<Bullet>().setDirection(transform.forward);

            buf.transform.position = rifleStart.transform.position;
            buf.transform.rotation = rifleStart.transform.rotation;
        }

        // Нажатие на колесо мыши
        if(Input.GetMouseButtonDown(2) && hasWeapon)
        {
            for(int i = 0; i <=6; i++)
            {
                GameObject buf = Instantiate(bulletSnaper);

                buf.GetComponent<Bullet>().setDirection(transform.forward);

                buf.transform.position = rifleStart.transform.position;
                buf.transform.rotation = rifleStart.transform.rotation;
            }
        }
    }
}
```