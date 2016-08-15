using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // 移動速度
    public float speed = 5;

    public GameObject bullet;

	// Use this for initialization
	IEnumerator Start () {
	    while (true)
	    {
            //弾をプレイヤと同じ位置/角度で作成
	        Instantiate(bullet, transform.position, transform.rotation);

            yield return new WaitForSeconds(0.05f);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{

	    float x = Input.GetAxisRaw("Horizontal");
	    float y = Input.GetAxisRaw("Vertical");

        //　移動方向を計算
	    Vector2 direction = new Vector2(x, y).normalized;

        //　アタッチされたコンポーネントに反映
	    GetComponent<Rigidbody2D>().velocity = direction*speed;

	}
}
