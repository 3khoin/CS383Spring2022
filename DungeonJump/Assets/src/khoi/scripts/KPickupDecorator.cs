using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPickupDecorator : KPickupInterface
{
    private KPickupInterface _kPickup;

    public KPickupDecorator(KPickupInterface kPickup)
    {
        _kPickup = kPickup;
    }

    public virtual int GetSpeedBonus()
    {
        return _kPickup.GetSpeedBonus();
    }
}