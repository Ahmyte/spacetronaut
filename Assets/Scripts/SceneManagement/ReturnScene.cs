using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnScene : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
