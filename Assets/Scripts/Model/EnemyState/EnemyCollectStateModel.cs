
using UnityEngine;
public class EnemyCollectStateModel : BaseEnemyStateModel
{
    public override void Execute(EnemyView enemy)
    {
        base.Execute(enemy);
        _dir = enemy.Context.DecidedDirection; 
        _dir.y = 0f;
        _time -= Time.deltaTime;
        _enemyTransform.rotation = Quaternion.Slerp(
            _enemyTransform.rotation,
            Quaternion.LookRotation(_dir), 
            Time.deltaTime * enemy.ViewParams.RotationSpeed);
        _enemyTransform.position += _enemyTransform.forward * Time.deltaTime * enemy.ViewParams.MoveSpeed;
        
        if (enemy.Context.Context.Decision.Values[2] > 0.7f || enemy.Context.Context.Decision.Values[0]== 0f)
        {
            enemy.State = EnemyState.Search;
        }
    }
}