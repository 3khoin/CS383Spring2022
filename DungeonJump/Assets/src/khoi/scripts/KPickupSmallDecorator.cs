using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPickupSmallDecorator : KPickupDecorator
{
    public KPickupSmallDecorator(KPickupInterface kPickup) : base(kPickup) { }

    public override int GetSpeedBonus()
    {
        return 1;
    }
}