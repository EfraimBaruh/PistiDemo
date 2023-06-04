using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum NextScene
{
    Menu = 1,
    Game = 2
}
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private NextScene loadScene;
    [SerializeField] private bool loadOnStart;
    [SerializeField] private Slider sceneBar;
    [SerializeField] private TextMeshProUGUI loadingPercent;

    private void Start()
    {
        if (loadOnStart)
            StartCoroutine(Load(loadScene));
    }

    public void LoadScene()
    {
        StartCoroutine(Load(loadScene));
    }

    AsyncOperation operation;

    private IEnumerator Load(NextScene scene)
    {
        var counter = 0;

        yield return new WaitForSeconds(0.3f);
        operation = SceneManager.LoadSceneAsync(scene.ToString());
        operation.allowSceneActivation = false;

        while (!operation.isDone && operation.progress > .76)
        {
            if (loadingPercent)
            {
                loadingPercent.text = "%" + (int)(operation.progress * 100);
                sceneBar.value = operation.progress;
            }
            yield return null;
        }
        while (counter < 80)
        {
            counter++;
            if (loadingPercent)
            {
                loadingPercent.text = "%" + counter;
                sceneBar.value = (float)counter / 100;
            }
            yield return new WaitForSeconds(Random.Range(0.02f, 0.06f));
        }

        operation.allowSceneActivation = true;
        if (loadingPercent)
        {
            sceneBar.value = 1f;
            loadingPercent.text = "%100";
        }
        StopAllCoroutines();


    }
}
