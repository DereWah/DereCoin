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

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private static readonly DereCoin Singleton = new();

        private Handlers.Player playerHandler;
        public static DereCoin Instance => Singleton;

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            playerHandler = new Handlers.Player(this);
            Player.FlippingCoin += playerHandler.OnCoinFlip;
        }

        public void UnregisterEvents()
        {
            Player.FlippingCoin -= playerHandler.OnCoinFlip;
            playerHandler = null;
        }
    }
}
