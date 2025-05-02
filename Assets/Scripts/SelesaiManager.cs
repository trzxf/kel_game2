using UnityEngine;
using UnityEngine.UI;

public class SelesaiManager : MonoBehaviour
{
    public Text txtHasil;

    void Start()
    {
        string hasil = PlayerPrefs.GetString("Pemenang", "Belum Ada Pemenang");
        txtHasil.text = hasil;
    }
}
