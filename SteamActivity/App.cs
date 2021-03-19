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
        private MenuItem menuItemOpen, 
                         menuItemExit;

        public App()
        {
            InitializeComponent();
         
            this.contextMenu1 = new ContextMenu();
            this.menuItemOpen = new MenuItem();
            this.menuItemExit = new MenuItem();

            this.contextMenu1.MenuItems.AddRange(
               new MenuItem[] { this.menuItemExit, this.menuItemOpen });

            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Text = "Open";
            this.menuItemOpen.Click += new EventHandler(this.menuItemOpen_Click);

            this.menuItemExit.Index = 1;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new EventHandler(this.menuItemExit_Click);

            notifyIcon1.ContextMenu = contextMenu1;
            notifyIcon1.Icon = new Icon("steam.ico");

            notifyIcon1.Text = "Steam Activity";
            notifyIcon1.Visible = true;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
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

        private void menuItemOpen_Click(object sender, EventArgs e)
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
