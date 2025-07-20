using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GoToScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GoToScene(string name)
	{
		SceneManager.LoadScene(name);
	}
}
