using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using Codenesium.TemplateGenerator.Classes.Generation;
using Codenesium.TemplateGenerator.Classes.Mediation;
namespace Codenesium.TemplateGenerator.Forms
{
    public partial class MainForm : MetroForm
    {
        delegate void SetStatusCallback(object sender, MessageEventArgs me);
        private UserControls.Projects _projects;
        private UserControls.Templates _templates;
        private UserControls.Generation _generation;
        private UserControls.Database _database;
        public MainForm()
        {
            InitializeComponent();
            LoadStaticClasses();
        }

        public void LoadStaticClasses()
        {
            TemplateContainer.GetInstance();
            ProjectContainer.GetInstance();

            TemplateContainer.GetInstance().Load(TemplateContainer.GetInstance().FileLocation); 
            ProjectContainer.GetInstance().Load(ProjectContainer.GetInstance().FileLocation);

            FormMediator.GetInstance().BroadCastMessageEvent += BroadCastMessageEventHandler;
            FormMediator.GetInstance().BroadCastErrorEvent += BroadCastErrorEventHandler;
            FormMediator.GetInstance().SendMessage(String.Empty);
        }

        private void BroadCastMessageEventHandler(object sender, MessageEventArgs me)
        {
            if (labelStatus.InvokeRequired)
            {
                SetStatusCallback callback = new SetStatusCallback(BroadCastMessageEventHandler);
                this.Invoke(callback, this,me);
            }
            else
            {
                labelStatus.ForeColor = Color.LimeGreen;
                labelStatus.Text = me.Message;
            }
        }

        private void BroadCastErrorEventHandler(object sender, MessageEventArgs me)
        {
            if (labelStatus.InvokeRequired)
            {
                SetStatusCallback callback = new SetStatusCallback(BroadCastErrorEventHandler);
                this.Invoke(callback, this, me);
            }
            else
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = me.Message;
            }
        }

        private void buttonProject_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            if(this._projects == null)
            {
                this._projects = new UserControls.Projects();
            }
            panelMain.Controls.Add(this._projects);
        }

        private void buttonTemplates_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            if (this._templates == null)
            {
                this._templates = new UserControls.Templates();
            }
            panelMain.Controls.Add(this._templates);
        }

        private void buttonGeneration_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            if (this._generation == null)
            {
                this._generation = new UserControls.Generation();
            }
            panelMain.Controls.Add(this._generation);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            if (this._projects == null)
            {
                this._projects = new UserControls.Projects();
            }
            panelMain.Controls.Add(this._projects);
        }

        private void buttonDataInterfaces_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            if (this._database == null)
            {
                this._database = new UserControls.Database();
            }
            panelMain.Controls.Add(this._database);
        }
    }
}
