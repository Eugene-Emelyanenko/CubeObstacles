using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coins;
    [SerializeField] private Sprite[] sprites;
    public float speed = 3f;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("selectedBall")];
        coins = PlayerPrefs.GetInt("coins", 0);
        Debug.Log(coins);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            Debug.Log(coins);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
