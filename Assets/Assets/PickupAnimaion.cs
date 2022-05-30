using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimaion : MonoBehaviour
{
    private float originalY;
        private float randomFloat;
        private float randomTime;
        private float randomRotation;
        public bool rotateObject;
        public bool rotateOnZ;


        void Start()
        {
            this.originalY = this.transform.position.y + 0.3f;
            randomFloat = Random.Range(0.2f, 0.35f);
            randomTime = Random.Range(0f, 400f);
            randomRotation = Random.Range(5f, 20f);
        }
        void Update()
        {
            if(rotateObject) {
                if(rotateOnZ)
                    gameObject.transform.Rotate(0, 0, randomRotation * Time.deltaTime);
                else
                    gameObject.transform.Rotate(0, randomRotation * Time.deltaTime, 0);
            }

            gameObject.transform.position = new Vector3(transform.position.x,
                originalY + (Mathf.Sin(randomTime + Time.time) * randomFloat), transform.position.z);

        }
}
