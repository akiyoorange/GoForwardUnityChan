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
        
    }

    // Update is called once per frame
    void Update()
    {
        // キューブが着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;

        // 空中にいるときにはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        //オーディオを取得
        GetComponent<AudioSource>();

        //Unityちゃんを取得
        this.unitychan2d = GameObject.Find("UnityChan2D");

        //もし衝突した相手の名前がUnityちゃんだったら音量０、それ以外は１
        if (collision.gameObject.name == "UnityChan2D")
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = 1;
        }

    }
}
