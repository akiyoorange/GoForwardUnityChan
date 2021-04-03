using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // 地面の位置
    private float groundLevel = -3.0f;

    //Unityちゃん
    private GameObject unitychan2d;

    //衝突時のオーディオ
    private AudioSource audioSource;

   

    // Start is called before the first frame update
    void Start()
    {
        //オーディオを取得
        audioSource = GetComponent<AudioSource>();

        //Unityちゃんを取得
        this.unitychan2d = GameObject.Find("UnityChan2D");
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter2D(Collision2D collision)
    {
        //もし衝突した相手がUnityちゃん以外だったら再生
        if (collision.gameObject != unitychan2d)
        {
            audioSource.Play();
        }

    }
}
