using UnityEngine;
using UnityEngine.SceneManagement;
public class HalamanManager : MonoBehaviour
{
public bool isEscapeToExit;
// Use this for initialization
void Start()
{
}
// Update is called once per frame
void Update()
{
if (Input.GetKeyUp(KeyCode.Escape))
{
if (isEscapeToExit)
{
Application.Quit();
}
else
{
KembaliKeMenu();
}
}
}
public void MulaiPermainanVersusAI()
{
    PlayerPrefs.SetInt("ModeAI", 1);
    SceneManager.LoadScene("Main");
}

public void MulaiPermainan()
{
    PlayerPrefs.SetInt("ModeAI", 0);
    SceneManager.LoadScene("Main");
}

public void KembaliKeMenu()

{
SceneManager.LoadScene("Menu");
}
public void KeluarGame()
{
    Debug.Log("Keluar dari game...");
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
}

}