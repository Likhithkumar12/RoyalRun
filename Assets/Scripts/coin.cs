using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class coin : Pickup
{
    scoremanager scoremanage;
    [SerializeField] int scoreamount=100;
    public void Init(scoremanager scoremanage)
   {
    this.scoremanage=scoremanage;
   }
    protected override void onPickup()
    {
       scoremanage.incrementscore(scoreamount);
      

    }
    
}
