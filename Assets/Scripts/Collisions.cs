using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public ParticleSystem exlposion;
    void OnTriggerEnter(Collider other)
    {
            Debug.Log(name + "__trigger__" + other.gameObject.name);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            exlposion.Play();
            Invoke("ReloadLevel", 1);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
