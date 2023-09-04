using DereCoin.Types;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereCoin.Handlers
{
    class Player
    {

        public Player(DereCoin plugin) => this.plugin = plugin;

        public DereCoin plugin;

        public void OnCoinFlip(FlippingCoinEventArgs ev)
        {
            List<int> weightedIndexes = new List<int>();
            int x = 0;
            if (plugin.Config.ConfigItems.Count() > 0)
            {
                foreach (Dictionary<string, object> element in plugin.Config.ConfigItems)
                {
                    int chance = Convert.ToInt32(element["Chance"]);
                    for (int i = 0; i < chance; i++)
                    {
                        weightedIndexes.Add(x);
                    }
                    x++;
                }
                Random random = new Random();
                int resultIndex = weightedIndexes[random.Next(weightedIndexes.Count)];
                CoinChance el = getCoinChance(plugin.Config.ConfigItems[resultIndex]);

                ev.Player.RemoveItem(ev.Item);
                string message = el.getMessage().Replace("{player}", ev.Player.Nickname);
                ev.Player.Broadcast(5, message);
                if (el.getRewardType() == Rewards.EffectReward)
                {
                    ev.Player.EnableEffect((Effect)el.getReward());
                }
                else if (el.getRewardType() == Rewards.ItemReward)
                {
                    ev.Player.AddItem((ItemType)el.getReward());
                }
            }
        }


        CoinChance getCoinChance(Dictionary<string, object> obj)
        {
            if (((string)obj["RewardType"]).ToLower() == "item")
            {
                return (new CoinChance((ItemType)Enum.Parse(typeof(ItemType), (string)obj["Reward"]), (string)obj["Message"], Convert.ToInt32(obj["Chance"])));
            }
            else if (((string)obj["RewardType"]).ToLower() == "effect")
            {
                return (new CoinChance((EffectType)Enum.Parse(typeof(EffectType), (string)obj["Reward"]), Convert.ToInt32(obj["Duration"]), (string)obj["Message"], Convert.ToInt32(obj["Chance"])));
            }
            return null;
        }

    }
}
