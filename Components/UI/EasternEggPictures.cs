using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminCon_CLI_dotnetEdition.Components.UI
{
    public partial class EasterEggPictures : Form
    {
        public EasterEggPictures()
        {
            InitializeComponent();
        }

        private void introLinkLabel_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://music.youtube.com/channel/UCB4u7GUvhOq4QfnRKxYXwCQ");
        }
    }
}
