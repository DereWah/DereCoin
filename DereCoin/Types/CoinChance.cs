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
        public ItemType Item { get; set; }
        public Effect Effect { get; set; }
        public int Chance { get; set; }
        public Rewards RewardType { get; set; }
        public string Message { get; set; }
    }
}
