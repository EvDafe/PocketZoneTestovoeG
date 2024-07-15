using Assets.CodeBase.GameLogic.Inventory;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.ServicesScripts.Progress
{
    [Serializable]
    public class PlayerProgress
    {
        public Dictionary<ItemType, int> Items = new Dictionary<ItemType, int>
        {
            [ItemType.AK74] = 1,
            [ItemType.Makarov] = 1,
            [ItemType.Ammo545x39] = 20,
            [ItemType.MilitaryHelmet] = 0,
            [ItemType.BulletproofCloakWrist] = 0,
            [ItemType.BulletproofCloakElbow] = 0,
            [ItemType.BulletproofCloak] = 0,
            [ItemType.BanditPants] = 0
        };
    }
}
