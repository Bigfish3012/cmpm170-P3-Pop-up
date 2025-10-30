using UnityEngine;
using UnityEngine.SceneManagement;
// Reference: https://www.youtube.com/watch?v=DX7HyN7oJjE
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

}
