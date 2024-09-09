using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace Shmup
{
    public class EnemyBuilder
    {
        private GameObject enemyPrefab;
        private SplineContainer splineContainer;
        private GameObject weaponPrefab;
        private float enemySpeed;

        public EnemyBuilder SetBasePrefab(GameObject prefab)
        {
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline)
        {
            this.splineContainer = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject prefab)
        {
            weaponPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpeed(float speed)
        {
            this.enemySpeed = speed;
            return this;
        }

        public GameObject Build()
        {
            GameObject instance = GameObject.Instantiate(enemyPrefab);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = splineContainer;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = enemySpeed;

            // Set instance transform to spline start position
            instance.transform.position = splineContainer.EvaluatePosition(0f); //makes sure enemies always start at position 0 at thespline
            //NOTE: if instantiating waves, could set the position along the spline in a staggered value 0f to 1f

            return instance;
        }
    }
}

