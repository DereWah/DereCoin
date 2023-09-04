using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereCoin.Types
{
    public enum Rewards
    {
        ItemReward,
        EffectReward
    }
    public class CoinChance
    {
        private ItemType item = ItemType.Painkillers;
        private Effect effect;
        private int chance = 50;
        Rewards rewardType = Rewards.ItemReward;
        private string message;

        public Object getReward()
        {
            if(rewardType == Rewards.ItemReward)
            {
                return item;
            }else if (rewardType == Rewards.EffectReward)
            {
                return effect;
            }
            else
            {
                return null;
            }
        }

        public Rewards getRewardType()
        {
            return rewardType;
        }

        public int getChance()
        {
            return chance;
        }

        public string getMessage()
        {
            return message;
        }

        public CoinChance(ItemType item, string message, int chance)
        {
            this.item = item;
            this.chance = chance;
            this.rewardType = Rewards.ItemReward;
            this.message = message;
        }

        public CoinChance(EffectType effect, int duration, string message, int chance)
        {
            this.effect = new Effect(effect, duration);
            this.chance = chance;
            this.rewardType = Rewards.EffectReward;
            this.message = message;
        }

    }
}
