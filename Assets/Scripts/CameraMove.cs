using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posx = player.transform.position.x;//playerのx座標
        float posy = player.transform.position.y;//playerのy座標
        float posz = player.transform.position.z;//playerのz座標

        //カメラのpositionをプレイヤーのx座標, y座標+10, z座標-10にし続ける
        transform.position = new Vector3(posx, posy + 10, posz - 10);
    }
}
