using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] Image progressFill;
    public bool start = false;

    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }
    private IEnumerator LoadSceneAsync(int index)
    {
        screen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        progressFill.fillAmount = 0;
        operation.allowSceneActivation = false;

        float progress = 0f;

        while (!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);

            progressFill.fillAmount = progress;

            if (progress >= 0.9f)
            {
                progressFill.fillAmount = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
