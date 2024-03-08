using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : EnemyBase
{
    float area = 25; // расстояние между игроком и врагом
    float speed = 2; // скорость перемещения врага
    public override void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < area)
        {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * speed);
        }
    }

    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            // Найти скрипт PlayerHp и функцию changeHpBux
            player.GetComponent<PlayerHp>().changeHpBux(200);
        }
    }
}
