using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int health;
    [SerializeField] GameObject health1;
    [SerializeField] GameObject health2;
    [SerializeField] GameObject health3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 2)
        {
            health3.SetActive(false);
        }
        if (health == 1)
        {
            health2.SetActive(false);
        }

        if (health <= 0)
        {
            health1.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
