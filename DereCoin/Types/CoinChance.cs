using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereCoin.Types
{
    public abstract class CoinChanceBase : TypeCastObject<CoinChanceBase>
    { 
        public int Chance { get; set; }
        public string Message { get; set; }

        public CoinChanceBase() {
            Chance = 0;
            Message = "";
        }
    }
    
    public sealed class CoinChanceItem : CoinChanceBase
    {
        public ItemType Item { get; set; }
        
    }

    public sealed class CoinChanceEffect : CoinChanceBase
    {
        public Effect Effect { get; set; }

    }
}
