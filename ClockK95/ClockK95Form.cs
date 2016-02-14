using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockK95
{
    public partial class ClockK95Form : Form
    {
        private readonly CorsairRgb _corsairRgb;
        private readonly Clock _clock;

        public ClockK95Form()
        {
            InitializeComponent();

            _corsairRgb = new CorsairRgb();
            _clock = new Clock(_corsairRgb.GetCorsairKeyboard());
            _clock.Start();

            this.WindowState = FormWindowState.Minimized;
            Form1();
        }
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItem12or24;
        private System.Windows.Forms.MenuItem menuItemAmPm;
        private System.Windows.Forms.MenuItem menuItemStartStop;

        public void Form1()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItem12or24 = new System.Windows.Forms.MenuItem();
            this.menuItemAmPm = new System.Windows.Forms.MenuItem();
            this.menuItemStartStop = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu
            this.contextMenu.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[]
                        {
                            this.menuItemStartStop,
                            this.menuItem12or24,
                            this.menuItemAmPm,
                            this.menuItemExit
                        });

            // Initialize menuItemStartStop
            this.menuItemStartStop.Index = 0;
            this.menuItemStartStop.Text = "&Start/Stop";
            this.menuItemStartStop.Click += new System.EventHandler(this.menuItemStartStop_Click);

            // Initialize menuItem12or24
            this.menuItem12or24.Index = 1;
            this.menuItem12or24.Text = "12/24 &Hour";
            this.menuItem12or24.Click += new System.EventHandler(this.menuItem12or24_Click);

            // Initialize menuItemExit
            this.menuItemAmPm.Index = 2;
            this.menuItemAmPm.Text = "A&M/PM";
            this.menuItemAmPm.Click += new System.EventHandler(this.menuItemAmPm_Click);

            // Initialize menuItemExit
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);

            // Create the NotifyIcon.
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            
            notifyIcon.Icon = new Icon("ClockK95.ico");
            notifyIcon.ContextMenu = this.contextMenu;
            notifyIcon.Text = "Clock K95";
            notifyIcon.Visible = true;

        }

        private void menuItemExit_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.Close();
        }

        private void menuItem12or24_Click(object Sender, EventArgs e)
        {
            _clock.Hour12or24 = !_clock.Hour12or24;
        }

        private void menuItemAmPm_Click(object Sender, EventArgs e)
        {
            _clock.AmPmIndicatior = !_clock.AmPmIndicatior;
        }

        private void menuItemStartStop_Click(object Sender, EventArgs e)
        {
            if (_clock.isRunning())
            {
                _clock.Stop();
            }
            else
            {
                _clock.Start();
            }
        }
    }
}
