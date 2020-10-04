
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public static void Select(string stage_name)
    {
        SceneManager.LoadScene(stage_name);
    }

}
