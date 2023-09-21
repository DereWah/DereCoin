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

        public void OnCoinFlip(FlippingCoinEventArgs ev)
        {
            List<CoinChanceBase> joined = new();
            List<CoinChanceBase> eval = new();

            if (DereCoin.Singleton.Config.CoinItems is not null || DereCoin.Singleton.Config.CoinEffects is not null)
            {
                
                if (DereCoin.Singleton.Config.CoinItems is not null)
                    joined.AddRange(DereCoin.Singleton.Config.CoinItems);

                if (DereCoin.Singleton.Config.CoinEffects is not null)
                    joined.AddRange(DereCoin.Singleton.Config.CoinEffects);
            
                foreach (CoinChanceBase ccb in joined)
                {
                    if (UnityEngine.Random.Range(1, 101) > ccb.Chance)
                        continue;

                    eval.Add(ccb);
                }

                if (eval.Count() > 0)
                {

                    if (!DereCoin.Singleton.CoinUses.ContainsKey(ev.Item.Serial)) DereCoin.Singleton.CoinUses.Add(ev.Item.Serial, (0, UnityEngine.Random.Range(1, DereCoin.Singleton.Config.CoinMaxUses)));
                    //override the tuple value in the dictionary with a new tuple, where the left value is the original left value increased by 1
                    DereCoin.Singleton.CoinUses[ev.Item.Serial] = (DereCoin.Singleton.CoinUses[ev.Item.Serial].Item1+1, DereCoin.Singleton.CoinUses[ev.Item.Serial].Item2);
                    //check if the left value is greather or equal than the right value. If so remove the coin
                    if (DereCoin.Singleton.CoinUses[ev.Item.Serial].Item1 >= DereCoin.Singleton.CoinUses[ev.Item.Serial].Item2)
                    {
                        ev.Player.RemoveItem(ev.Item);
                        DereCoin.Singleton.CoinUses.Remove(ev.Item.Serial);
                    }
                    

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
