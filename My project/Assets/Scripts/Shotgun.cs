using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ! Наследуется от Gun
public class Shotgun : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        auto = false;
        cooldown = 0;
    }

    protected override void OnShoot()
    {
        for (int i = 0; i < 10; i++)
        {
            // Заспавни новый объект пулю
            GameObject buf = Instantiate(bullet);

            // Локальные переменные для функции рандом от -30 до 30 и от -10 до 10
            float x = Random.Range(-30, 30);
            float y = Random.Range(-10, 10);

            // Задаём откуда будет вылетать и под каким углом
            buf.transform.position = rifleStart.transform.position;
            buf.transform.rotation = rifleStart.transform.rotation;

            // Ищём скрипт Bullet, находим функцию setDirection - в неё определяем направление пули вперёд 
            // и смещение на локальные переменные
            buf.GetComponent<Bullet>().setDirection(transform.forward + new Vector3(x / 500, y / 500, 0));
        }
    }
}
