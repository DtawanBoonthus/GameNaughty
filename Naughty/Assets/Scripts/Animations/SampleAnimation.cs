using UnityEngine;

namespace Animations
{
    public class SampleAnimation : MonoBehaviour
    {
        private Animator animator;
        private const string key_isRun = "IsRun";
        private const string key_isAttack01 = "IsAttack01";

        void Start()
        {
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) ||
                (Input.GetKey(KeyCode.D)))
            {
                animator.SetBool(key_isRun, true);
            }
            else
            {
                animator.SetBool(key_isRun, false);
            }


            if (Input.GetKeyUp("space"))
            {
                animator.SetBool(key_isAttack01, true);
            }
            else
            {
                animator.SetBool(key_isAttack01, false);
            }
        }
    }
}