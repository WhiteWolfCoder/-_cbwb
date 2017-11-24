using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СоБраТ_cbwb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ToolStripButton NewTab = new ToolStripButton("Новая вкладка");
            NewTab.Click += NewTab_Click;
            menu.Items.Add(NewTab);
        }

        private void NewTab_Click(object sender, EventArgs e)
        {
            TabFromSite taba = new TabFromSite(this.tabs);
        }
    }
}
