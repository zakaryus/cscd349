using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cscd349FinalProject.Interfaces;
using cscd349FinalProject.Items;

namespace cscd349FinalProject.Utilities
{
    public enum CharacterType
    {
        KnightFemale, KnightMale,
        MagicianFemale, MagicianMale,
        NinjaFemale, NinjaMale,
        SoldierFemale, SoldierMale,
        ElfDark, ElfEarth, ElfFire,
        ElfLight, ElfWater, ElfWind
    }

    static class Factory
    {
        //Factory Method
        public static ICharacter CreateCharacter(CharacterType ct)
        {
            ICharacter character = null;

            if(ct == CharacterType.KnightFemale)
                character = new CharacterKnightFemale();

            else if (ct == CharacterType.KnightMale)
                character = new CharacterKnightMale();

            else if (ct == CharacterType.MagicianFemale)
                character = new CharacterMagicianFemale();

            else if (ct == CharacterType.MagicianMale)
                character = new CharacterMagicianMale();

            else if (ct == CharacterType.NinjaFemale)
                character = new CharacterNinjaFemale();

            else if (ct == CharacterType.NinjaMale)
                character = new CharacterNinjaMale();

            else if (ct == CharacterType.SoldierFemale)
                character = new CharacterSoldierFemale();

            else if (ct == CharacterType.SoldierMale)
                character = new CharacterSoldierMale();

            else if (ct == CharacterType.ElfDark)
                character = new CharacterElfDark();

            else if (ct == CharacterType.ElfEarth)
                character = new CharacterElfEarth();

            else if (ct == CharacterType.ElfFire)
                character = new CharacterElfFire();

            else if (ct == CharacterType.ElfLight)
                character = new CharacterElfLight();

            else if (ct == CharacterType.ElfWater)
                character = new CharacterElfWater();

            else if (ct == CharacterType.ElfWind)
                character = new CharacterElfWind();
            
            return character;
        }

        public static ICharacter CreateRandomEnemy()
        {
            List <ICharacter> enemies = new List<ICharacter>
                                        {
                                            new CharacterElfDark(), 
                                            new CharacterElfEarth(), 
                                            new CharacterElfFire(), 
                                            new CharacterElfLight(), 
                                            new CharacterElfWater(), 
                                            new CharacterElfWind()
                                        };

            Random rand = new Random();
            return enemies[rand.Next()%enemies.Count];
        }

        public static IInventory CreateRandomInventory()
        {
            List<IInventory> inventories= new List<IInventory>
                                        {
                                            new ItemHealthPotionBig(), 
                                            new ItemHealthPotionSmall(), 
                                            new ItemHealthCheese(), 
                                            new ItemHealthBread(),
                                            new ItemHealthWatermelon()
                                        };

            Random rand = new Random();
            return inventories[rand.Next() % inventories.Count];
        }
    }
}
