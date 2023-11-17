using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AE0672
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private float yOffest = 1f;
        [SerializeField] private float xOffest = 1f;


        [SerializeField] private Transform playerTransform;

        // Update is called once per frame
        private void Update()
        {
            transform.position = new Vector3(playerTransform.position.x + xOffest, playerTransform.position.y + yOffest, transform.position.z);
        }
    }

}