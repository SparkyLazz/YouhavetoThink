using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMainMenu : MonoBehaviour
{
    public AudioSource Music;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        Music.Play();
    }
    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            Destroy(gameObject);
        }
    }

}
