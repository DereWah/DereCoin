using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Player = Exiled.Events.Handlers.Player;

namespace DereCoin
{
    public class DereCoin : Plugin<Config>
    {
        public override string Name => "DereCoin";
        public override string Prefix => "DCoin";
        public override string Author => "@derewah";
        public override Version RequiredExiledVersion { get; } = new Version(8,0,0);
        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        public static DereCoin Singleton { get; private set; }

        public Dictionary<ushort, (int, int)> CoinUses = new Dictionary<ushort, (int, int)>();

        private Handlers.Player playerHandler;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            playerHandler = new Handlers.Player();
            Player.FlippingCoin += playerHandler.OnCoinFlip;
        }

        public void UnregisterEvents()
        {
            Player.FlippingCoin -= playerHandler.OnCoinFlip;
            playerHandler = null;
        }
    }
}
