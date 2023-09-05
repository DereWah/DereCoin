using DereCoin.Types;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
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
            List<CoinChanceBase> joined = new();
            List<CoinChanceBase> eval = new();

            if (plugin.Config.CoinItems is not null || plugin.Config.CoinEffects is not null)
            {
                
                if (plugin.Config.CoinItems is not null)
                    joined.AddRange(plugin.Config.CoinItems);

                if (plugin.Config.CoinEffects is not null)
                    joined.AddRange(plugin.Config.CoinEffects);
            
                foreach (CoinChanceBase ccb in joined)
                {
                    if (UnityEngine.Random.Range(1, 101) > ccb.Chance)
                        continue;

                    eval.Add(ccb);
                }

                if (eval.Count() > 0)
                {
                    ev.Player.RemoveItem(ev.Item);

                    eval.ShuffleList();
                    CoinChanceBase selectedElement = eval.FirstOrDefault();

                    string message = selectedElement.Message.Replace("{player}", ev.Player.Nickname);
                    ev.Player.ClearBroadcasts();
                    ev.Player.Broadcast(3, message);

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
}
