using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyCrystal : MonoBehaviour
{
    [SerializeField] int crystal = 0;
    [SerializeField] Text crystalText;

    // Контейнер для звука подбора кристалов
    AudioSource audio;

    // Префаб подбора кристалов
    [SerializeField] GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        // Выбор трека у player, трек привязан к игроку
        audio = GetComponent<AudioSource>();
    }

    // Функция OnTriggerEnter выполняется при столкновении с объектом
    // Функция OnTriggerExit - выполняется как только прекращаетсся столкновение, но столкновение изначально было
    // Функция OnTriggerStay -срабатывает несколько раз при длительном контакте с объектом

    // Функция при столкновении с объектом
    private void OnTriggerEnter(Collider other)
    {
        // Если столкнёшься с предметом у которого тег Crystal
        // то выполни то-то
        if(other.tag == "Crystal") 
        {
            // Удали этот объект
            Destroy(other.gameObject);
            crystal += 1;

            // Вкл. музыку подбора кристалов
            audio.Play();

            // Префаб взрыва
            Instantiate(particle, other.transform.position, other.transform.rotation);
        }

        if(other.tag == "Portal1") {
            SceneManager.LoadScene(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        crystalText.text = "Crystals: " + crystal.ToString();

        if(crystal == 5) {
            SceneManager.LoadScene(0);
        }
    }
}
