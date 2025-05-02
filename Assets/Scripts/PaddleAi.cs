using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public Transform bola;
    public float kecepatan;
    public float batasAtas;
    public float batasBawah;
    public float batasKiri;
    public float batasKanan;

    void Update()
    {
        if (bola == null) return;

        Vector3 pos = transform.position;

        // Gerakan Vertikal
        if (bola.position.y > pos.y && pos.y < batasAtas)
        {
            pos.y += kecepatan * Time.deltaTime;
        }
        else if (bola.position.y < pos.y && pos.y > batasBawah)
        {
            pos.y -= kecepatan * Time.deltaTime;
        }

        // Gerakan Horizontal (tambahan)
        if (bola.position.x > pos.x && pos.x < batasKanan)
        {
            pos.x += kecepatan * Time.deltaTime;
        }
        else if (bola.position.x < pos.x && pos.x > batasKiri)
        {
            pos.x -= kecepatan * Time.deltaTime;
        }

        transform.position = pos;
    }
}
