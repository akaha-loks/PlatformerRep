using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void End()
    {
        anim.SetTrigger("Finish");
    }

    private void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
