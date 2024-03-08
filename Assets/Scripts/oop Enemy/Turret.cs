using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Наследование от EnemyBase
public class Turret : EnemyBase
{
    [SerializeField] protected GameObject bullet; // пуля
    [SerializeField] protected GameObject rifleStart; // место выстрела
    protected float timer = 0; // Время (отсчёт)
    protected float cooldown = 1; // Интервал между выстрелами
    protected float area = 50; // Расстояние видимости от объекта и турели (врага)

    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < area)
        {
            transform.LookAt(player.transform);
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                GameObject buf = Instantiate(bullet);

                buf.GetComponent<Bullet>().setDirection(transform.forward);

                buf.transform.position = rifleStart.transform.position;
                buf.transform.rotation = rifleStart.transform.rotation;
            }
        }
    }
}
