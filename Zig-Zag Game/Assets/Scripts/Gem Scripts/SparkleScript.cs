using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DeactiveAferTime());
    }

    IEnumerator DeactiveAferTime()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
