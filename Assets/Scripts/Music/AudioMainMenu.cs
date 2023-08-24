using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMainMenu : MonoBehaviour
{
    public AudioSource Music;
    private static AudioMainMenu instance;

    private void Awake()
    {
        // Implement Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Music.Play();
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            // Destroy the object if it's not the singleton instanc
            Destroy(gameObject);
        }
    }
}
