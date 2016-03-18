using TextAdventure.Living_Critter.User_Character_Types;
using TextAdventure.Objects;

namespace TextAdventure.Living_Critter
{
  public interface Character
  {
      int GetHealth();
      void SetHealth(int h);
      int GetMutability();
      void SetMutability(int m);
      int GetIntelligence();
      void SetIntelligence(int i);
      int GetBrutishness();
      void SetBrutishness(int b);
      int GetWillpower();
      void SetWillpower(int w);
      int GetEndurance();
      void SetEndurance(int e);
      void Mutate();
      int Attack();
      void Explore(Point p);
      int HitChance();
      int DamageDone();
  }
}