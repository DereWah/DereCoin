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
        public List<Dictionary<String, Object>> ConfigItems { get; set; } = new()
        {
            new Dictionary<String, Object>()
            {
                { "RewardType", "item" },
                { "Reward", ItemType.Adrenaline.ToString() },
                { "Message", "You got adrenaline from gambling!" },
                { "Chance", 30 }
            },
                new Dictionary<String, Object>()
            {
                { "RewardType", "effect" },
                { "Reward", EffectType.Blinded.ToString() },
                { "Duration", 3 },
                { "Message", "You flipped the coin into your eyes" },
                { "Chance", 30 }
            }
        };


    }
}
