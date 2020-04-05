using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを扱うときは追加する
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //public componentの名前(型) 変数名 で変数を宣言するとInspectorから指定したcomponentを代入できる
    public Rigidbody rb;

    //同じようにGameObjectもInspectorから代入可能
    public GameObject text_obj;

    //Text型の変数score_text　Inspectorに表示させる必要がないためprivate
    private Text goal_text;

    //ゴール後のリセットまでの時間
    private float resetTime = 2;
    //リセットするかどうかのフラグ
    private bool reset;



    // Start is called before the first frame update
    void Start()
    {
        //GameObject型の変数text_objの中のTextコンポーネントをText型のgoal_textに代入
        goal_text = text_obj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        //AddForceを使ったはオブジェクトが回転し、慣性の法則が働く(Rigidbody必須)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, 5);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -5);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(5, 0, 5);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-5, 0, 5);
        }

        //慣性の法則嫌だ
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * 5.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * 5.0f * Time.deltaTime;
        }*/


        //落ちたら戻ってくるようにする
        if (transform.position.y < -10)
        {
            Reset();
        }
    }

    private void OnCollisionStay(Collision hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            Reset();
        }

        if(hit.gameObject.tag == "Goal")
        {
            //GameObjectを有効化する
            //goal_text.enabled = true;
            //reset = true;
            Clear();
        }

        /*if(reset)
        {
            resetTime -= Time.deltaTime;
            if(resetTime < 0){
                Reset();
            }
        }*/
    }

	private void Reset()
	{
        transform.position = new Vector3(0, 1, 0);

        //勢いをなくす(Rigidbodyの加速度0にする)
        rb.velocity = Vector3.zero;

        //回転の勢いをなくす(Rigidbodyの回転加速度を0にする)
        rb.angularVelocity = Vector3.zero;

        //回転もリセットしたいときはrotationに代入する
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        //GameObjectを無効化する
        goal_text.enabled = false;

        resetTime = 2;

        reset = false;

        Timer.seconds = 0f;

        Timer.minute = 0;
	}

    private void Clear(){
        SceneManager.LoadScene("Result");
    }
}
