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
