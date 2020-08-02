using UnityEngine;
using UnityEngine.SceneManagement;

public class logoscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MainLoad", 4.5f, 1);
    }
    void MainLoad()
    {
        SceneManager.LoadScene("MainScene");
    }
}
