using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Rigidbody[] allRb;
    [SerializeField] Image healthBar;
    Coroutine myCor;
    Animator animator;
    float currentHealth = 1;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        if (healthBar.fillAmount <= 0)
            return;
        if (myCor != null)
            StopCoroutine(myCor);
        myCor = StartCoroutine(DecreaseHealth(currentHealth - .2f));
        currentHealth -= .2f;
        if (healthBar.fillAmount <= .2f)
            Death();
    }

    IEnumerator DecreaseHealth(float targetVal)
    {
        float timeV = 0;
        float currentValue = healthBar.fillAmount;

        while (timeV < 1)
        {
            timeV += Time.deltaTime * 10;
            healthBar.fillAmount = Mathf.Lerp(currentValue, targetVal, timeV);
            yield return new WaitForSeconds(.01f);
        }
    }

    void Death()
    {
        animator.enabled = false;
    }

}
