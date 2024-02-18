using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    [SerializeField] GameObject sniperGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sniper") {
            // Удали этот объект
            // print("Взял");
            Destroy(other.gameObject);
            sniperGun.SetActive(true);
            PlayerBaxGun.hasWeapon = true;
        }

        if(other.tag == "Apteka") {
            Destroy(other.gameObject);
            GetComponent<PlayerHp>().changeHpBux(-20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
