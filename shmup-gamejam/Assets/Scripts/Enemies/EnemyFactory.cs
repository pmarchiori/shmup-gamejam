using UnityEngine;
using UnityEngine.Splines;

namespace Shmup
{
    public class EnemyFactory
    {
        public GameObject CreateEnemy(Enemy enemyType, SplineContainer spline)
        {
            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemyType.enemySpeed);

            return builder.Build();
        }

        //space for more factory methods, for example enemies that do not follow a spline
    }
}