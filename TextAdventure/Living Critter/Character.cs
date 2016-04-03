﻿using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter
{
  public interface Character
  {
      void Mutate();
      int Attack();
      int HitChance();
      int DamageDone();
  }
}
