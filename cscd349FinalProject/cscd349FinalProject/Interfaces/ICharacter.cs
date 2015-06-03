using System.Windows.Controls;

namespace cscd349FinalProject.Interfaces
{
    public interface ICharacter: IWatchee
    {
        //Properties
        string Name { get; }
        string Description { get; }
        HitPoint HitPoints { get; set; }
        HitPoint MaxHitPoints { get; set; }
        IWeapon Weapon { get; set; }
        IEquipment Equipment { get; set; }

        Image Face { get; }
        Image Front { get; }
        Image Back { get; }
        Image Left { get; }
        Image Right { get; }


        //Methods
        HitPoint Attack();
        void Die();
    }
}
