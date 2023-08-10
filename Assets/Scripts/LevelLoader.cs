using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public Volume PostProcessing;
    Bloom bloomEffect;
    // Update is called once per frame
    public void Start()
    {
        PostProcessing.profile.TryGet(out bloomEffect);

    }
    public void LoadNextLevel()
    {
        StartCoroutine(loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void onClick(Button button)
    {
        int buttonindex = Convert.ToInt16(button.name);
        StartCoroutine(loadlevel(buttonindex + 1));
    }
    public IEnumerator loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }
    public void Onquit()
    {
        Application.Quit();
    }
    public void ToMenu()
    {
        StartCoroutine(loadlevel(0));
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void BloomSetting(bool toggle)
    {
        bloomEffect.active = toggle;
    }
}
