﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Photon.Pun;


namespace Com.MyCompany.MyGame
{
    public class PlayerAnimatorManager : MonoBehaviourPun
    {
        #region Private Fields


        [SerializeField]
        private float directionDampTime = 0.25f;
        private Animator animator;


        #endregion

        #region MonoBehaviour Callbacks


        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            if (!animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            // only allow jumping if we are running.
            if (stateInfo.IsName("Base Layer.Run"))
            {
                // When using trigger parameter
                if (Input.GetButtonDown("Space"))
                {
                    animator.SetTrigger("Jump");
                }
            }

            if (!animator)
            {
                return;
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                v = 0;
            }
            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
        }


        #endregion
    }
}