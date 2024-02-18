using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    public void Save() {
        Vector3 vector = player.transform.position;
        PlayerPrefs.SetFloat("playerX", vector.x);
        PlayerPrefs.SetFloat("playerY", vector.y);
        PlayerPrefs.SetFloat("playerZ", vector.z);
        PlayerPrefs.Save();
    }
}
