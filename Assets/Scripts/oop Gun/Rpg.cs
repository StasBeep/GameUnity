using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rpg : Gun
{
    void Start()
    {
        cooldown = 0;
        auto = false;
    }

    // override - переопределение функции родительского компонента
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);

        buf.GetComponent<Rocket>().setDirection(transform.forward);

        buf.transform.position = rifleStart.transform.position;
        buf.transform.rotation = rifleStart.transform.rotation;
    }
}
