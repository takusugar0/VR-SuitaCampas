using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// public class scene : MonoBehaviour {
// void OnTriggerEnter (Collider other)
// {
// SceneManager.LoadScene("M3");
// }

// }
public class ToM3 : MonoBehaviour
{
    // オブジェクトと接触した時に呼ばれるコールバック
    void OnCollisionEnter (Collision hit)
    {
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag ("Player")) {


            SceneManager.LoadScene("M3");
        }
    }
}