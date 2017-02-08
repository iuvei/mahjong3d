﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lobby_UIManager : MonoBehaviour {
    public static Lobby_UIManager instance;
    public Text[] _buttonTexts;
    public Text _buttonMoreText;
    public GameObject birdConnectingMask;
    public GameObject buttonBGMask;
    public Animator moreBtnPanelAnimator;
    public Animator lobbyAnimator;

    private Color _duckYellow = new Color(0.952f, 0.596f, 0, 1);

    void Start() {
        instance = this;

        //關閉連線視窗
        birdConnectingMask.SetActive(false);
    }


    //大廳-按鈕點擊變色
    public void ChangeTextColor(Button targetBtn) {
        ResetAllBtnColor();
        targetBtn.gameObject.GetComponentInChildren<Text>().color = _duckYellow;
    }

    //點擊按鈕背景遮罩
    public void ClickBackgroundMask()
    {
        ResetAllBtnColor();
        buttonBGMask.SetActive(false);
        moreBtnPanelAnimator.SetBool("OpenMorePanel", false);
    }

    //保留更多鈕顏色
    public void RemainMoreBtnTextColor()
    {
        _buttonMoreText.color = _duckYellow;
    }

    //點擊更多按鈕
    private void ClickButtomMore()
    {
        Debug.Log("!buttonBGMask.activeSelf = " + !buttonBGMask.activeSelf);
        //開啟背景遮罩
        buttonBGMask.SetActive(!buttonBGMask.activeSelf);
        moreBtnPanelAnimator.SetBool("OpenMorePanel", buttonBGMask.activeSelf);
    }

    //點擊 更多-排行榜
    public void ClickToolbarBtn(Button targetBtn) {

        if (targetBtn.name != "Button_More" && buttonBGMask.activeSelf) {
            //ClickBackgroundMask();
            StartCoroutine("DelayCloseBGMask");
        }

        ResetAllBtnColor();
        targetBtn.gameObject.GetComponentInChildren<Text>().color = _duckYellow;

        switch (targetBtn.name) {
            case "Button_Billboard":
                //點擊 排行榜

                break;
            case "Button_Activity":
                //點擊 活動

                break;
            case "Button_Charge":
                //點擊 儲值

                break;
            case "Button_Message":
                //點擊 訊息通知

                break;
            case "Button_More":
                //點擊 更多
                ClickButtomMore();
                break;

            case "Button_Setting":
                //點擊 更多 - 設定
                RemainMoreBtnTextColor();
                break;
            case "Button_Explain":
                //點擊 更多 - 說明
                RemainMoreBtnTextColor();
                break;
            case "Button_Question":
                //點擊 更多 - 問題
                RemainMoreBtnTextColor();
                break;
            case "Button_Invite":
                //點擊 更多 - 邀請好友
                RemainMoreBtnTextColor();
                break;
            case "Button_Record":
                //點擊 更多 - 紀錄
                RemainMoreBtnTextColor();
                break;
            default:
                //點擊  ???

                break;
        }
    }

    //重置所有按鈕顏色
    public void ResetAllBtnColor() {
        foreach (Text _text in _buttonTexts) {
            _text.color = Color.white;
        }
    }

    IEnumerator DelayCloseBGMask() {
        yield return new WaitForSeconds(0.1f);
        ClickBackgroundMask();
    }

    //點擊開桌 準備進入遊戲畫面
    public void StartSetConnecting() {
        ResetAllBtnColor();
        birdConnectingMask.SetActive(true);
    }

    //載入畫面載入完畢
    public void SetConnectingDone()
    {
        lobbyAnimator.SetBool("ConnectingDone", true);
    }
}
