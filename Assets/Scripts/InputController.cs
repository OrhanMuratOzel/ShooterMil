using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;
    [SerializeField] FireAnimationEvent fireAnimation;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    public float GetXAxisRaw()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public float GetYAxisRaw()
    {
        return Input.GetAxisRaw("Vertical");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {//Fire
            fireAnimation.Fire();
        }
    }

   
}
