using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] Rigidbody Rb;
    Coroutine mycor;

    private void OnEnable()
    {
        transform.localPosition = Vector3.zero;
        Rb.AddForce(new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)), ForceMode.Impulse);
        if (mycor != null)
            StopCoroutine(mycor);
        mycor = StartCoroutine(SleepMode());
    }
    IEnumerator SleepMode()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
