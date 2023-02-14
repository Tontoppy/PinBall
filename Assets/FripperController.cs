using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを取り込む
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //はじいた時の傾き
    private float flickAngle = -20;
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);


    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("マウスクリック" + Input.GetMouseButton(0));
        Debug.Log("マウスクリック" + (Input.GetMouseButton(0) == false));


        if ((Input.GetKeyDown(KeyCode.LeftArrow)
                || Input.GetKeyDown(KeyCode.A))
            && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow)
                || Input.GetKeyDown(KeyCode.D))
            && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow)
                || Input.GetKeyUp(KeyCode.A))
            && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow)
                 || Input.GetKeyUp(KeyCode.D))
             && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //S,↓を押したときには左右のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.DownArrow)
                 || Input.GetKeyDown(KeyCode.S))
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)
                 || Input.GetKeyUp(KeyCode.S))
        {
            SetAngle(this.defaultAngle);
        }

        //以下タップ操作
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began && touch.position.x >= Screen.width / 2
                && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            else if(touch.phase == TouchPhase.Began && touch.position.x < Screen.width / 2
                && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            else if (touch.phase == TouchPhase.Ended && touch.position.x >= Screen.width / 2
                && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            else if (touch.phase == TouchPhase.Ended && touch.position.x < Screen.width / 2
                && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

        }
    }

    public void SetAngle(float angle)
    {
        //        this.myHingeJoint.spring.targetPosition = angle;
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
