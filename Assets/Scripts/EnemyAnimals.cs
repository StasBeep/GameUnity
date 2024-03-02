using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimals : MonoBehaviour
{
    float area = 10; // Область видимости врага (100 метров)
    GameObject player; // Игрок
    [SerializeField] CharacterController controller; // Определение движения персонажа
    [SerializeField] float speed = 2; // Скорость персонажа

    float bax = 2; // Область удара врага (2 метра)

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

            // Движение врага в сторону player со скоростью 2
            controller.Move(transform.forward * Time.deltaTime * speed);
        }

        if(Vector3.Distance(transform.position, player.transform.position) < bax) {
            // print("Удар");
        }
    }
}
