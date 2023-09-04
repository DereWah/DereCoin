using DereCoin.Types;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereCoin
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        [Description("This is a list of all the possible rewards and their chance.")]
        public List<CoinChanceBase> ConfigItems { get; set; } = new()
        {
            new CoinChanceItem()
            {
                Item = ItemType.Adrenaline,
                Chance = 30,
                Message = "You got adrenaline from gambling!"
            },
            new CoinChanceEffect()
            {
                Effect = new(EffectType.MovementBoost, 10),
                Chance = 30,
                Message = "speed"
            }
        };


    }
}
