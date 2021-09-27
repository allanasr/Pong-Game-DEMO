using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Key Setup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public int maxPoints;
    public TextMeshProUGUI uiTextPoints;

    public float speed = 5;
    public Image uiPlayer;
    public string playerName;

    private void Awake()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

   
    void Update()
    {
        if (Input.GetKey(keyCodeMoveUp))
            myRigidbody2D.MovePosition(transform.position + transform.up * speed * Time.deltaTime * 100);
        else if (Input.GetKey(keyCodeMoveDown))
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed * Time.deltaTime * 100);
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    public void ResetPoints()
    {
        currentPoints = 0;
        UpdateUI();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints == maxPoints)
        {
            HighScoreManager.Instance.SavePlayerWin(this);
            GameManager.Instance.EndGame();
        }
    }

    public void ChanceColor(Color color)
    {
        uiPlayer.color = color;
    }

    public void SetName(string s)
    {
        playerName = s;
    }
}
