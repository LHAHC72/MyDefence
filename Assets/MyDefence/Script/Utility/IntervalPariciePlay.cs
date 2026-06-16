using UnityEngine;

namespace MyDefence
{ 


    public class IntervalPariciePlay : MonoBehaviour
    {
        public ParticleSystem particleEffect;

        [SerializeField]
        public float playTimer = 5.0f;

        public float delayTime = 0f;

        private void Start()
        {
            InvokeRepeating("PlayParticleSystem", delayTime, playTimer);
        }

        void PlayParticleSystem()
        {
            if (particleEffect == null)
            {
                return;
            }
            particleEffect.Play();
            
        }


    }
}