using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPostion;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPannel;
    public float fadewait;

    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity);
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.runtimeValue = playerPostion;
            StartCoroutine(FadeCo());
        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPannel != null)
        {
            Instantiate(fadeOutPannel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadewait);   
        AsyncOperation asyncOpe = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOpe.isDone)
        {
            yield return null;
        }
    }

}
