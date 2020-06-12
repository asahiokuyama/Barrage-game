using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHp : MonoBehaviour
{
    public int hp;
    public GameObject effectPrefab;

    private Slider slider;
    public GameObject[] PlayerIcon;

    public int destroycount = 0;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("PlayerHP").GetComponent<Slider>();
        slider.maxValue = hp;
        slider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            destroycount++;
            this.gameObject.SetActive(false);

            if (destroycount < 5)
            {
                Invoke("Retry", 1.0f);
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        slider.value = hp;

        UpdatePlayerIcons();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyMissile"))
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            hp--;
        }
    }

    void UpdatePlayerIcons()
    {
        // for文（繰り返し文）・・・まずは基本形を覚えましょう！
        for (int i = 0; i < PlayerIcon.Length; i++)
        {
            if (destroycount <= i)
            {
                PlayerIcon[i].SetActive(true);
            }
            else
            {
                PlayerIcon[i].SetActive(false);
            }
        }
    }

    void Retry()
    {
        this.gameObject.SetActive(true);
        transform.position = new Vector3(-7, 0, 6);
        hp = 3;
    }
}
