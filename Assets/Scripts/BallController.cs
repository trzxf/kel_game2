using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    AudioSource audio;
    public AudioClip hitSound;

    // Timer
    public float waktuPermainan = 90f;
    float timer;
    Text waktuUI;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        scoreP1 = 0;
        scoreP2 = 0;

        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();

        waktuUI = GameObject.Find("Waktu").GetComponent<Text>();
        timer = waktuPermainan;

        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Tampilkan waktu ke UI
        if (waktuUI != null)
        {
            waktuUI.text = Mathf.CeilToInt(timer).ToString();
        }

        // Jika waktu habis
        if (timer <= 0)
        {
            // Tentukan pemenang dan simpan ke PlayerPrefs
            if (scoreP1 > scoreP2)
            {
                PlayerPrefs.SetString("Pemenang", "Player 1 Pemenang!");
            }
            else if (scoreP2 > scoreP1)
            {
                PlayerPrefs.SetString("Pemenang", "Player 2 Pemenang!");
            }
            else
            {
                PlayerPrefs.SetString("Pemenang", "Seri!");
            }

            SceneManager.LoadScene("End"); // Ganti ke scene akhir
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        audio.PlayOneShot(hitSound);

        if (coll.gameObject.name == "TepiKanan")
        {
            scoreP1 += 1;
            TampilkanScore();
            ResetDanLemparBola(new Vector2(2, 0));
        }

        else if (coll.gameObject.name == "TepiKiri")
        {
            scoreP2 += 1;
            TampilkanScore();
            ResetDanLemparBola(new Vector2(-2, 0));
        }

        else if (coll.gameObject.name == "P1" || coll.gameObject.name == "P2")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.linearVelocity.x, sudut).normalized;

            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetDanLemparBola(Vector2 arah)
    {
        transform.localPosition = Vector2.zero;
        rigid.linearVelocity = Vector2.zero;
        rigid.AddForce(arah.normalized * force);
    }

    void TampilkanScore()
    {
        Debug.Log("Score P1: " + scoreP1 + " | Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1.ToString();
        scoreUIP2.text = scoreP2.ToString();
    }
}
