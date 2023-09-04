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

            if (plugin.Config.ConfigItems.Count() > 0)
            {
                ev.Player.RemoveItem(ev.Item);
                List<CoinChanceBase> joined = plugin.Config.ConfigItems + plugin.Config.ConfigEffects;
                WeightedRandomSelector<CoinChanceBase> selector = new WeightedRandomSelector<CoinChanceBase>(plugin.Config.ConfigItems);
                CoinChanceBase selectedElement = selector.GetRandomElement();

                string message = selectedElement.Message.Replace("{player}", ev.Player.Nickname);
                ev.Player.Broadcast(5, message);

                if (selectedElement.Cast(out CoinChanceEffect cce))
                {
                    ev.Player.EnableEffect(cce.Effect);
                }
                else if (selectedElement.Cast(out CoinChanceItem cci))
                {
                    ev.Player.AddItem(cci.Item);
                }
            }
        }
    }
}
