using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g����荞��
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;

    //�͂��������̌X��
    private float flickAngle = -20;
    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);


    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("�}�E�X�N���b�N" + Input.GetMouseButton(0));
        Debug.Log("�}�E�X�N���b�N" + (Input.GetMouseButton(0) == false));


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

        //S,�����������Ƃ��ɂ͍��E�̃t���b�p�[�𓮂���
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

        //�ȉ��^�b�v����
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
