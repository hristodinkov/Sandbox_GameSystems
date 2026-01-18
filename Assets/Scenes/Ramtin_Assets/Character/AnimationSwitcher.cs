using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetAnim(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetAnim(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetAnim(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SetAnim(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SetAnim(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SetAnim(6);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SetAnim(7);
        if (Input.GetKeyDown(KeyCode.Alpha8)) SetAnim(8);
    }

    void SetAnim(int index)
    {
        animator.SetInteger("AnimIndex", index);
    }
}
