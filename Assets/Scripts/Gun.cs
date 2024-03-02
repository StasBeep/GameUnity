using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Переменная (универсальная) для отправки пули из нужной точки
    [SerializeField] protected Transform rifleStart;
    // Переменная для пули
    [SerializeField] protected GameObject bullet;
    // Тип стрельбы (автоматический/одиночный)
    protected bool auto = false;
    // Интервал между выстрелами
    protected float cooldown = 0;
    // Время выстрела (закрытая)
    private float timer = 0;

    public void Shoot()
    {
        // ! Для одиночного выстрела работать будет всегда, второе условие для интервала при автоматической стрельбы
        // Если нажата и сразу же отпущена левая кнопка мыши или
        // автоматичекий режим включён
        if (Input.GetMouseButtonDown(0) || auto)
        {
            // Если время выстрела превышает интервал
            if (timer > cooldown)
            {
                OnShoot();
                timer = 0;
            }
        }
    }

    // TODO Виртуальная функция для определения поведения оружия в дочерних компонентах
    protected virtual void OnShoot() { }

    // Start is called before the first frame update
    void Start()
    {
        // В начале игры интервал приравниваем к 0
        cooldown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        // В течении игры в переменную кладём время игры в милисекундах
        timer += Time.deltaTime;
        // print(timer);
    }
}
