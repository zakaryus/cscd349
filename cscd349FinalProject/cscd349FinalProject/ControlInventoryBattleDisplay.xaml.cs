﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cscd349FinalProject
{
    /// <summary>
    /// Interaction logic for ControlInventoryBattleDisplay.xaml
    /// </summary>
    public partial class ControlInventoryBattleDisplay : UserControl
    {
        private IItem _item;

        public IItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public ControlInventoryBattleDisplay(IItem item)
        {
            InitializeComponent();
            Item = item;

            lblName.Content = Item.Name;
            tblkDescription.Text = Item.Description;
            ItemIcon.Source = Item.Icon.Source;
        }
    }
}
