using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Наследуется от пистолета
public class Rifle : Pistol
{
    // Start is called before the first frame update
    void Start()
    {
        auto = true;
        cooldown = 0.2f;
    }
}
