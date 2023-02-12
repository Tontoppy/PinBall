using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    private float visivlePosZ = -6.5f;
    private GameObject gameoverText;

    //課題1:衝突したオブジェクトを入れる
    private GameObject collidedObject;
    //課題1:スコアテキストを入れる
    private GameObject scoreText;
    //課題1:スコアを入れる
    private int gameScore = 0;
    //課題1:オブジェクトごとのスコア設定
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

    //課題1
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
