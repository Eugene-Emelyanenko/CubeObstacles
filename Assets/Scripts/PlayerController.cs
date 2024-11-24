using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    public float minX = -4f;
    public float maxX = 4f;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Spawner spawner;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("selectedBall")];
    }

    private void OnMouseDown()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            transform.position = newPosition;
        }
    }

    public void GameOver()
    {
        spawner.enabled = false;
        this.enabled = false;
        gameOverMenu.SetActive(true);
    }
}
