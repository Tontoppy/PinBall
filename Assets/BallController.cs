using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    private float visivlePosZ = -6.5f;
    private GameObject gameoverText;

    //�ۑ�1:�Փ˂����I�u�W�F�N�g������
    private GameObject collidedObject;
    //�ۑ�1:�X�R�A�e�L�X�g������
    private GameObject scoreText;
    //�ۑ�1:�X�R�A������
    private int gameScore = 0;
    //�ۑ�1:�I�u�W�F�N�g���Ƃ̃X�R�A�ݒ�
    private int smallStarScore = 5;
    private int largeStarScore = 10;
    private int smallCloudScore = 20;
    private int largeCloudScore = 50;

    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visivlePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }
        this.scoreText.GetComponent<Text>().text = "Score: " + this.gameScore.ToString();

    }

    //�ۑ�1
    private void OnCollisionEnter(Collision collision)
    {
        this.collidedObject = collision.gameObject;
        if (collidedObject.tag == "SmallStarTag")
        {
            this.gameScore += smallStarScore;

        }
        else if (collidedObject.tag == "LargeStarTag")
        {
            this.gameScore += largeStarScore;
        }
        else if (collidedObject.tag == "SmallCloudTag")
        {
            this.gameScore += smallCloudScore;

        }
        else if (collidedObject.tag == "LargeCloudTag")
        {
            this.gameScore += largeCloudScore;
        }
    }
}
