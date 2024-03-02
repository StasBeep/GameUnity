using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 20;  // Скорость снаряда / пули
    Vector3 direction; // Направление снаряда

    // Метод определения направления при выстреле
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    // Функция полёта пули с учётом мощностей компьтера (равные права)
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    // Функция соприкосновения пули с объектами
    void OnTriggerEnter(Collider other)
    {
        // Если пуля конётся врага
        if (other.tag == "Enemy")
        {
            other.GetComponent<Animator>().SetTrigger("death");

            // ! Удаление капсулы (collaider), в полоении лёжа, капусула
            // ! существует и не даёт пропускать пули без этой команды
            Destroy(other);

            // TODO: Удаление скриптов, чтобы трупы не следили за игроком и не стреляли
            Destroy(other.GetComponent<Enemy>());
            Destroy(other.GetComponent<EnemyAnimals>());

            // удалить врага через 15 секунд
            Destroy(other.gameObject, 15);
        }

        // Если коснётся игрока
        if (other.tag == "Player")
        {
            // print("Попадание");
            other.GetComponent<PlayerHp>().changeHpBux(50);
        }

        // Уничтожение пули, если она коснётся любого предмета
        Destroy(gameObject);
    }
}
