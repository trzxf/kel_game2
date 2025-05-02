using UnityEngine;
public class PaddleController : MonoBehaviour
{
    public float batasAtas;
    public float batasBawah;
    public float kecepatan;
    public string axis;
    
    public float tepiKiri;    // Tambahan: batas kiri
    public float tepiKanan;   // Tambahan: batas kanan
    public string axisHorizontal; // Tambahan: axis untuk horizontal

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Gerakan vertikal
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float nextPos = transform.position.y + gerak;
        if (nextPos > batasAtas)
        {
            gerak = 0;
        }
        if (nextPos < batasBawah)
        {
            gerak = 0;
        }
        transform.Translate(0, gerak, 0);

        // Gerakan horizontal (Tambahan)
        float gerakHori = Input.GetAxis(axisHorizontal) * kecepatan * Time.deltaTime;
        float nextPosX = transform.position.x + gerakHori;
        if (nextPosX < tepiKiri)
        {
            gerakHori = 0;
        }
        if (nextPosX > tepiKanan)
        {
            gerakHori = 0;
        }
        transform.Translate(gerakHori, 0, 0);
    }
}
