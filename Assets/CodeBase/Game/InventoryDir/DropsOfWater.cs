using System;

namespace CodeBase.Game.InventoryDir
{
   public class DropsOfWater
   {
      public int AllDropsCount { get; }
      public int CurrentDropsCount { get; private set; }
      public event Action<DropsOfWater> DropsOfWaterChanged;

      public DropsOfWater(int allDropsCount)
      {
         AllDropsCount = allDropsCount;
         CurrentDropsCount = allDropsCount;
      }

      public void Fill()
      {
         CurrentDropsCount = AllDropsCount;
         DropsOfWaterChanged?.Invoke(this);
      }

      public void DecreaseDropsOfWater()
      {
         CurrentDropsCount--;
         DropsOfWaterChanged?.Invoke(this);
      }

      public bool HasDropsOfWater() =>
         CurrentDropsCount > 0;
   }
}