﻿using SimpleToolkit.Core;

namespace SIOT.Views.Pages
{
    public partial class PopoverPage : ContentPage
    {
        public PopoverPage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            button.ShowAttachedPopover();
        }
    }
}
