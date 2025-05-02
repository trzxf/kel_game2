using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public GameObject paddle2;

    void Start()
    {
        int modeAI = PlayerPrefs.GetInt("ModeAI", 0);

        if (modeAI == 1)
        {
            paddle2.GetComponent<PaddleAI>().enabled = true;
            paddle2.GetComponent<PaddleController>().enabled = false;
        }
        else
        {
            paddle2.GetComponent<PaddleAI>().enabled = false;
            paddle2.GetComponent<PaddleController>().enabled = true;
        }
    }
}
