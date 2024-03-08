using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Родительский класс для врагов
public class EnemyBase : MonoBehaviour
{
    protected int demage; // количество урона игроку
    protected int health; // количество жизней у врага
    protected GameObject player; // объект игрока
    bool dead = false; // живой ли враг

    // Функция для движения врага (виртуальная), то есть дочерний скрипт будет изменять данный метод
    public virtual void Move(){}

    // Метод для опеределения атаки врага, настраивается в дочернем классе (наследование)
    public virtual void Attack(){}

    // Публичный метод для изменения состояния врага (жив/мертв), можем обращаться к этому методу
    // с других скриптов, но изменять в дочерни классах не можем!
    public void OnDeath()
    {
        dead = true;
        // Изменение анимации при попадания по врагу
        GetComponent<Animator>().SetBool("death", true);
        // Отключение вращения врага, после смерти
        GetComponent<CharacterController>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Находим главного персонажа по скррипту, который к нему прикреплён
        player = FindObjectOfType<PlayerMove>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Если враг жив (не мёртв)
        if(!dead)
        {
            Move();
            Attack();
        }
    }
}
