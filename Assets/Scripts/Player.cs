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
            GetComponent<AudioSource>().Play();
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
        //spaceShip.Move(direction);

        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        Vector2 minVector2 = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 maxVector2 = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = transform.position;

        pos += direction * spaceShip.speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minVector2.x, maxVector2.x);
        pos.y = Mathf.Clamp(pos.y, minVector2.y, maxVector2.y);

        transform.position = pos;
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
            FindObjectOfType<Manager>().GameOver();
            spaceShip.Explosion();
            Destroy(gameObject);
        }
    }
}
