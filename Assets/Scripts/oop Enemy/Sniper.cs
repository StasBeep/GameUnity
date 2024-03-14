using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Turret
{
    public override void Attack()
    {
        cooldown = 2;
        area = 100;

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
