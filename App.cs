using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamActivity
{
    public partial class App : Form
    {
        private ContextMenu contextMenu1;
        private MenuItem menuItem1, 
                         menuItem2;

        public App()
        {
            InitializeComponent();
         
            this.contextMenu1 = new ContextMenu();
            this.menuItem1 = new MenuItem();
            this.menuItem2 = new MenuItem();

            this.contextMenu1.MenuItems.AddRange(
               new MenuItem[] { this.menuItem2, this.menuItem1 });

            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Open";
            this.menuItem1.Click += new EventHandler(this.menuItem1_Click);

            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new EventHandler(this.menuItem2_Click);

            notifyIcon1.ContextMenu = contextMenu1;

            notifyIcon1.Icon = new Icon("steam.ico");

            notifyIcon1.ContextMenu = this.contextMenu1;

            notifyIcon1.Text = "Steam Activity";
            notifyIcon1.Visible = true;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void App_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            showApp();
        }

        private void notifyIcon1_DoubleClick(object sender, MouseEventArgs e)
        {
            showApp();
        }

        private void showApp()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
