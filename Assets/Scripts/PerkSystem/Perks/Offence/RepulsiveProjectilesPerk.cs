using UnityEngine;

//Отталкивающие снаряды
[CreateAssetMenu(fileName = "RepulsiveProjectilesPerk", menuName = "ScriptableObjects/RepulsiveProjectiles", order = 1)]
public class RepulsiveProjectilesPerk : AbstractPerk
{
  [SerializeField] private float _distance;

  public override void Activate(BaseProjectile ownProjectile)
  {
    if(ownProjectile.Target == null) return;

    Repulsive(ownProjectile, ownProjectile.Target);
  }

  private Vector3 Repulsive(BaseProjectile projectile, GameObject target)
  {
    return target.transform.position += (projectile.transform.forward * _distance * Time.deltaTime);
  }

  public override void Deactivate(BaseProjectile ownProjectile)
  {
    // TODO
  }

  protected override void InternalAddLevel()
  {
    _distance++;
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }
}