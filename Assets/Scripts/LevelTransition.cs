using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private Animator animator;
    private int levelToLoad;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel(int buildIndex) //Start fading out of the level.
    {
        levelToLoad = buildIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() //When fading out is complete, load a new level.
    {
        SceneManager.LoadScene(levelToLoad);
    }
}