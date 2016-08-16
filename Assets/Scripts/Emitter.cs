using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{

    public GameObject[] waves;
    private int currentWave;
    private Manager manager;

    // Use this for initialization
    IEnumerator Start()
    {

        if (waves.Length == 0)
        {
            yield break;

        }

        manager = FindObjectOfType<Manager>();

        while (true)
        {
            //タイトル表示中は待機
            while (manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }

            //Waveを作成
            GameObject g = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);
            g.transform.parent = transform;

            //Waveの子要素のEnemyがすべて削除されるまで待機
            while (g.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            Destroy(g);


            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
