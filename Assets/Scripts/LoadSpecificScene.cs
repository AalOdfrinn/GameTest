using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSpecificScene : MonoBehaviour
{
    public Animator fadeSystem;
    public string sceneName;
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }
    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(sceneName);
    }
}
