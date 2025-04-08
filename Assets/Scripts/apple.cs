using UnityEngine;

public class apple : Pickup
{
    
    [SerializeField] float applemovespeed=3f;
public void Init(Level _level)
{
    level=_level;
}

    protected override void onPickup()
    {
        level.movechunkspeed(applemovespeed);
        

    }
    
}
