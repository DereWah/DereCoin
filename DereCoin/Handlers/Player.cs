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

        Random random = new Random();

        public void OnCoinFlip(FlippingCoinEventArgs ev)
        {
            List<int> weightedIndexes = new List<int>();
            int x = 0;
            if (plugin.Config.ConfigItems.Count() > 0)
            {
                foreach (CoinChanceBase element in plugin.Config.ConfigItems)
                {
                    for (int i = 0; i < element.Chance; i++)
                    {
                        weightedIndexes.Add(x);
                    }
                    x++;
                }
                int resultIndex = weightedIndexes[random.Next(weightedIndexes.Count)];
                CoinChanceBase el = plugin.Config.ConfigItems[resultIndex];

                ev.Player.RemoveItem(ev.Item);
                string message = el.Message.Replace("{player}", ev.Player.Nickname);
                ev.Player.Broadcast(5, message);



                if (el.Cast(out CoinChanceEffect cce))
                {
                    ev.Player.EnableEffect(cce.Effect);
                }
                else if (el.Cast(out CoinChanceItem cci))
                {
                    ev.Player.AddItem(cci.Item);
                }
            }
        }
    }
}
