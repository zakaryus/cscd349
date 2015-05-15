using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cscd349FinalProject.Utilities
{
    public enum CharacterType
    {
        KnightFemale, KnightMale,
        MagicianFemale, MagicianMale,
        NinjaFemale, NinjaMale,
        SoldierFemale, SoldierMale
    }

    static class CharacterFactory
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
            
            return character;
        }
    }
}
