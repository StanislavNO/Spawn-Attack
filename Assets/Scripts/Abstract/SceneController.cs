using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        public void Restart(int sceneNumbers = 0)
        {
            SceneManager.LoadScene(sceneNumbers);
        }
    }
}