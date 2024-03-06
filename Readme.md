# Игра на Unity

## Использование ООП на С# в разработке игры Unity

> Используется 5 файлов для объяснения

- Gun
- Pistol
- Rpg
- Rifle
- Shotgun
- SwitchGun

### Файл `Gun` 
Основной (родительский класс для других файлов)

```cs
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
```

Обратить внимание нужно на строку: `public class Gun : MonoBehaviour`, класс Gun зависит от MonoBehaviour, наследование от Unity сборки

Ещё на одну строку нужно обратить внимание:
```cs
protected virtual void OnShoot() { }
```

`protected` - видимость функции в дочерних компонентах

`private` - закрытая функция, видна только в классе *Gun*

`public` - открыта во всех файлах проекта

> *`virtual`* - обревиатура, которая говорит, что данная функция может применятся (то есть одно название функции) в разных файлах (дочерних)

### Файл Pistol
Код, дочерних компонент от класса Gun

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Наслдование от скрипта Gun
public class Pistol : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        auto = false;
    }

    // override - переопределение функции родительского компонента
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);

        buf.GetComponent<Bullet>().setDirection(transform.forward);

        buf.transform.position = rifleStart.transform.position;
        buf.transform.rotation = rifleStart.transform.rotation;
    }
}
```

Обратить внимание нужно на строку: `public class Pistol : Gun`, класс Pistol зависит от Gun, то есть скрипт `Pistol`, может обращаться к функциям класса `Gun`, которые имеют доступ `protected` или `public`, с другим доступом будут не видны

В строчках:
```cs
cooldown = 0;
auto = false;
```
Изменяем состояние переменных `cooldown` и `auto` на нужные нам через наследование

Обращая внимание на строку `protected override void OnShoot()` - `override` - говорит о том, что функцию, которая используется в классе `Gun` нужно переделать так как нужно нам для определённого объекта (в нашем случае для объекта pistol)

### Файлы Rifle & Rpg & Shotgun
Файлы наследуются либо от класса `Gun`, либо от класса `Pistol`, и c помощью `override` переписывам функцию, которая определена в родительском классе

### Файл SwitchGun
Файл не относится к наследованию, в файле прописана логика переключения между элементами, у которых присутствует наследование