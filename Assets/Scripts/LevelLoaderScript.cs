using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{

    public Animator animator;

    public float TransitionTime;

    public string NextLevelName;

    public void Nextevel()
    {
      StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(NextLevelName);
    }
}
