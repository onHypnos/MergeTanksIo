using System;
using Polarith.AI.Move;
using UnityEngine;

public class EnemyView : BasePersonView, IHaveAim, ITransaction
{
    private EnemyState _state;
    private AIMContext _context;

    public EnemyState State
    {
        set => _state = value;
        get => _state;
    }
    public AIMContext Context
    {
        set => _context = value;
        get => _context;
    }


    private void OnDestroy()
    {
        GameEvents.Current.EnemyDead(this);
    }

    public void CompleteTransaction(Transaction transaction)
    {
        _points = transaction.Value;
        PerkManager.AddPerk(transaction._perk);
    }
}