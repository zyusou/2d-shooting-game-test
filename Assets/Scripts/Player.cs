using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Spaceship spaceShip;

    // Use this for initialization
    IEnumerator Start()
    {

        spaceShip = GetComponent<Spaceship>();

        while (true)
        {
            //弾をプレイヤと同じ位置/角度で作成
            //Instantiate(bullet, transform.position, transform.rotation);

            spaceShip.Shot(transform);
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //　移動方向を計算
        Vector2 direction = new Vector2(x, y).normalized;

        //　アタッチされたコンポーネントに反映
        //GetComponent<Rigidbody2D>().velocity = direction*speed;
        spaceShip.Move(direction);
    }

    void OnTriggerEnter2D(Collider2D c)
    {

        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName == "Bullet(Enemy)")
        {
            Destroy(c.gameObject);
        }


        if (layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            spaceShip.Explosion();
            Destroy(gameObject);
        }
    }
}
