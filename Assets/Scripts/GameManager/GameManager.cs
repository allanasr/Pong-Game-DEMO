using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<BallBase> ballBaseList;
    public Player player1;
    public Player player2;

    public static GameManager Instance;
    public StateMachine stateMachine;
    public float timeToSetBallFree = 1f;

    [Header("Menus")]
    public GameObject uiMainMenu;


    public void Awake()
    {
        Instance = this;
    }
    public void ResetBall()
    {
        foreach(BallBase b in ballBaseList)
        {
            b.canMove(false);
            b.ResetBall();
            Invoke(nameof(SetBallFree), timeToSetBallFree);
        }
   
    }

    private void SetBallFree()
    {
        foreach (BallBase b in ballBaseList)
            b.canMove(true);
    }
    public void StartGame()
    {
        foreach (BallBase b in ballBaseList)
            b.canMove(true);
    }

    public void RestartGame()
    {
        foreach (BallBase b in ballBaseList)
        {
            b.canMove(false);
            b.ResetBall();
            Invoke(nameof(SetBallFree), timeToSetBallFree);
        }
        player1.ResetPoints();
        player2.ResetPoints();
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    } 
    public void ShowMainMenu()
    {
        foreach (BallBase b in ballBaseList)
        {
            b.canMove(false); 
        }
        player1.ResetPoints();
        player2.ResetPoints();
        uiMainMenu.SetActive(true);
        
    }
}
