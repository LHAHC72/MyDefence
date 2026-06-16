using UnityEngine;


namespace MyDefence
{
    public class Destruction : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField]
        private Vector3 rotationspeed;

        private void Update()
        {
            transform.localEulerAngles += rotationspeed;
        }

    }
}