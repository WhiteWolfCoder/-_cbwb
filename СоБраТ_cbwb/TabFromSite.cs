using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СоБраТ_cbwb
{
    class TabFromSite
    {
        TabControl tc;
        TabPage pageThis = null;
        ToolStrip tst = null;
         EO.WebBrowser.WebView b = null;
        PictureBox box = null;
        ToolStripTextBox URLtsttb;
        public TabFromSite(TabControl tc)
        {
            this.tc = tc;
            this.pageThis = new TabPage("Пустая вкладка");
            this.tst = new ToolStrip();
            ToolStripButton Gotstb = new ToolStripButton("GO!>>");
            ToolStripButton backtstb = new ToolStripButton("<<");
            ToolStripButton nobacktstb = new ToolStripButton(">>");
            this.URLtsttb = new ToolStripTextBox();
            URLtsttb.Size = new System.Drawing.Size(450, 20);
            Gotstb.Dock = DockStyle.Right;
            Gotstb.Click += Gotstb_Click;
            nobacktstb.Click += Nobacktstb_Click;
            backtstb.Click += Backtstb_Click;
            
            URLtsttb.Dock = DockStyle.Right;
            tst.Items.Add(backtstb);
            tst.Items.Add(nobacktstb);
            tst.Items.Add(URLtsttb);
            tst.Items.Add(Gotstb);
            tst.Dock = DockStyle.Top;
            b = new EO.WebBrowser.WebView();
            b.NewWindow += B_NewWindow;   
            box = new PictureBox();
            b.Create(box.Handle);
            b.Url = Properties.Settings.Default.homepage;
            box.Dock = DockStyle.Fill;
            pageThis.Controls.Add(tst);
            pageThis.Controls.Add(box);
            tc.TabPages.Add(this.pageThis);
            tc.SelectedIndex = tc.TabPages.Count-1;
            b.LoadCompleted += B_LoadCompleted;
            
        }

        private void Backtstb_Click(object sender, EventArgs e)
        {
            b.GoBack();
        }

        private void Nobacktstb_Click(object sender, EventArgs e)
        {
            b.GoForward();
        }

        private void Gotstb_Click(object sender, EventArgs e)
        {
            b.Url = URLtsttb.Lines[0];
            
        }

        private void B_LoadCompleted(object sender, EO.WebBrowser.LoadCompletedEventArgs e)
        {
            this.pageThis.Text = b.Title;
            Form1.ActiveForm.Text = b.Title + " СоБраТ (открыто вкладок: " + (tc.TabPages.Count-1).ToString()+")";
        }

        private void B_NewWindow(object sender, EO.WebBrowser.NewWindowEventArgs e)
        {
            new TabFromSite(tc);
        }
    }
}
