using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float area = 100; // Область видимости врага (100 метров)
    GameObject player; // Игрок
    [SerializeField] CharacterController controller; // Определение движения персонажа

    float timer = 0; // таймер
    float cooldown = 2; // интервал между выстрелами

    [SerializeField] GameObject bullet; // Объект пули
    [SerializeField] GameObject rifleStart; // Откуда вылетает пуля

    // Start is called before the first frame update
    void Start()
    {
        // Обозначили игрока, которому подключён скрипт PlayerMove
        player = FindObjectOfType<PlayerMove>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Если дистанция между тем, к кому привязан скрипт и игроком меньше area (область)
        if(Vector3.Distance(transform.position, player.transform.position) < area) {
            // Положение просмотра на координаты игрока
            transform.LookAt(player.transform);

            timer += Time.deltaTime;
            if(timer > cooldown) {
                timer = 0;
                GameObject buf = Instantiate(bullet);

                buf.GetComponent<Bullet>().setDirection(transform.forward);

                buf.transform.position = rifleStart.transform.position;
                buf.transform.rotation = rifleStart.transform.rotation;
            }
        }
    }
}
