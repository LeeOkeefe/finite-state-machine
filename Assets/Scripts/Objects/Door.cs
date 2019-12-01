﻿using System.Collections;
using UnityEngine;

namespace Objects
{
    internal class Door : MonoBehaviour, IInteractive
    {
        [SerializeField] private Vector3 angle;

        public void Interact()
        {
            StartCoroutine(OpenDoor());
        }

        private IEnumerator OpenDoor()
        {
            var endRotation = transform.rotation * Quaternion.Euler(angle);

            while (transform.rotation != endRotation)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * 0.75f);
                yield return null;
            }

            Destroy(this);
        }
    }
}
