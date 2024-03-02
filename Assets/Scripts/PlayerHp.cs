using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    // Переменные под hp
    [SerializeField] int hp = 100;
    [SerializeField] Text hpText;

    public void changeHpBux(int i) {
        hp -= i;
    }

    void Update()
    {
        hpText.text = "hp:" + hp.ToString();
    }
}
