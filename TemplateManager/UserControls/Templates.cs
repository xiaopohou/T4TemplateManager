using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Codenesium.GenerationLibrary.Generation;
using Codenesium.TemplateGenerator.Classes.Generation;
namespace Codenesium.TemplateGenerator.UserControls
{
    public partial class Templates : UserControl
    {
        TreeNode _currentlySelectNode;
        public Templates()
        {
            InitializeComponent();
            LoadForm();
            ProjectContainer.GetInstance().Reload += ProjectChanged;
        }

        private void ProjectChanged(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            ClearFields();
            int currentSelectedProject = comboBoxProjects.SelectedIndex;
            int currentSelectedTemplate = comboBoxTemplates.SelectedIndex;
            comboBoxProjects.DataSource = new BindingList<Project>(ProjectContainer.GetInstance().ProjectList);
            comboBoxProjects.DisplayMember = "Name";
            comboBoxProjects.ValueMember = "ID";

            if (currentSelectedProject == -1 && comboBoxProjects.Items.Count > 0)
            {
                comboBoxProjects.SelectedIndex = 0;
            }
            else
            {
                comboBoxProjects.SelectedIndex = currentSelectedProject;
            }

            if (currentSelectedTemplate == -1 && comboBoxTemplates.Items.Count > 0)
            {
                comboBoxTemplates.SelectedIndex = 0;
            }
            else
            {
                comboBoxTemplates.SelectedIndex = currentSelectedTemplate;
            }
            treeViewParameters.BeginUpdate();
            PopulateParameterTree();
            if (this._currentlySelectNode != null)
            {
                treeViewParameters.ExpandAll();
                treeViewParameters.SelectedNode = this._currentlySelectNode;
            }
            treeViewParameters.EndUpdate();
        }

        private void PopulateParameterTree()
        {
            if (comboBoxTemplates.SelectedIndex > -1)
            {
                treeViewParameters.Nodes.Clear();
                ProjectTemplate projectTemplate = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                Template template = TemplateContainer.GetInstance().TemplateList.Where(x => x.Name.ToUpper() == projectTemplate.TemplateName.ToUpper()).FirstOrDefault();

                if (projectTemplate.ParametersTree != null)
                {
                    if (projectTemplate.ParametersTree.Elements().Any())
                    {
                        foreach (XElement parameter in projectTemplate.ParametersTree.Elements())
                        {
                            treeViewParameters.Nodes.Add(RecursiveTreeIterate(parameter));
                        }
                    }
                }
            }
        }

        private TreeNode RecursiveTreeIterate(XElement parameter)
        {

            TreeNode newNode = new TreeNode();
            newNode.Text = parameter.Attribute("name").Value;
            newNode.Tag = parameter;

            foreach (XElement node in parameter.Elements("children").Elements())
            {
                newNode.Nodes.Add(RecursiveTreeIterate(node));
            }
            return newNode;
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedIndex > -1)
            {
                ClearFields();
                Project project = (Project)comboBoxProjects.SelectedItem;
                comboBoxTemplates.DataSource = new BindingList<ProjectTemplate>(project.ProjectTemplateList);
                comboBoxTemplates.DisplayMember = "TemplateName";
            }
        }

        private void ClearFields()
        {
            dataGridViewParameters.Rows.Clear();
        }

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();
            if (comboBoxTemplates.SelectedIndex > -1)
            {
                ProjectTemplate projectTemplate = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                Template template = TemplateContainer.GetInstance().TemplateList.Where(x => x.Name.ToUpper() == projectTemplate.TemplateName.ToUpper()).FirstOrDefault();

                if (template != null)
                {
                    Dictionary<string, string> parameters = Parameter.ParseParametersFromTemplate(template.TemplateText);
                    foreach (string key in parameters.Keys)
                    {
                        if (key.ToUpper() == "TREEPARAMETER") //hide the parameter tree parameter from the user. 
                        {
                            continue;
                        }
                        int index = -1;
                        if (projectTemplate.ScreenParameters.ContainsKey(key))
                        {
                            index = dataGridViewParameters.Rows.Add(key, projectTemplate.ScreenParameters[key]);
                        }
                        else
                        {
                            index = dataGridViewParameters.Rows.Add(key, "");
                        }
                        dataGridViewParameters.Rows[index].Cells["key"].Style.ForeColor = Color.Green;
                    }


                    //if we have extra parameters that are not used by the template but are generation specific we add those here
                    foreach (string key in projectTemplate.ScreenParameters.Keys)
                    {
                        if (!parameters.ContainsKey(key))
                        {
                            int index = dataGridViewParameters.Rows.Add(key, projectTemplate.ScreenParameters[key]);
                            dataGridViewParameters.Rows[index].Cells["key"].Style.ForeColor = Color.Blue;
                        }
                    }
                }
                PopulateParameterTree();

            }
        }

        public Dictionary<string,object> ConvertGridToDictionary()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (DataGridViewRow row in dataGridViewParameters.Rows)
            {

                string key = (row.Cells["key"].Value ?? String.Empty).ToString();
                string value = (row.Cells["value"].Value ?? String.Empty).ToString();
                if (key != String.Empty)
                {
                    parameters.Add(key, value);
                }
            }

            return parameters;
        }

        private XElement SaveTree()
        {
            XElement tree = new XElement("parameterTree");
            foreach(TreeNode node in treeViewParameters.Nodes)
            {
                tree.Add((XElement)node.Tag);
            }
            return tree;
        }

      
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(comboBoxProjects.SelectedIndex > -1)
            {
                if(comboBoxTemplates.SelectedIndex > -1)
                {
                    Save();  
                }
            }
        }

        private void ClearTextFields()
        {
            textBoxParameterKey.Clear();
            textBoxParameterValue.Clear();
        }
        private void Save()
        {
            treeViewParameters.SelectedNode = null;
            ClearTextFields();
            Dictionary<string, object> parameters = ConvertGridToDictionary();
            ProjectTemplate template = (ProjectTemplate)comboBoxTemplates.SelectedItem;
            Project project = (Project)comboBoxProjects.SelectedItem;
            template.ScreenParameters = parameters;
            template.ParametersTree = SaveTree();

            int index = project.ProjectTemplateList.FindIndex(x => x.TemplateName == template.TemplateName);
            project.ProjectTemplateList[index] = template;


            ProjectContainer.GetInstance().Save();
            ProjectContainer.GetInstance().Load();
            LoadForm();
            Classes.Mediation.FormMediator.GetInstance().SendMessage("Project Template Saved");
        }

        private void linkLabelViewTemplate_Click(object sender, EventArgs e)
        {
            if(comboBoxTemplates.SelectedIndex > -1)
            {
                ProjectTemplate projectTemplate = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                Template template = TemplateContainer.GetInstance().TemplateList.Where(x => x.Name.ToUpper() == projectTemplate.TemplateName.ToUpper()).FirstOrDefault();
                Forms.FormTextViewer textViewer = new Forms.FormTextViewer(template.TemplateText);
                textViewer.ShowDialog();

                if(textViewer.Saved)
                {
                    template.TemplateText = textViewer.TextValue;
                    // TODO: Add template saving functionality
                }
            }        
        }

       
        private void textBoxParameterValue_TextChanged(object sender, EventArgs e)
        {
            if(treeViewParameters.SelectedNode != null)
            {
                XElement currentNode = (XElement)this._currentlySelectNode.Tag;
                currentNode.Attribute("value").Value = textBoxParameterValue.Text;
            }
        }

        private void treeViewParameters_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this._currentlySelectNode = e.Node;
            XElement currentNode = (XElement)this._currentlySelectNode.Tag;
            if (currentNode.Attribute("value") != null)
            {
                textBoxParameterValue.Text = currentNode.Attribute("value").Value;
            }
             
            textBoxParameterKey.Text = currentNode.Attribute("name").Value;
        }

        private void textBoxParameterKey_TextChanged(object sender, EventArgs e)
        {
            if (treeViewParameters.SelectedNode != null)
            {
                XElement currentNode = (XElement)this._currentlySelectNode.Tag;
                if (currentNode.Attribute("name") != null)
                {
                    currentNode.Attribute("name").Value = textBoxParameterKey.Text;
                }
                this._currentlySelectNode.Text = textBoxParameterKey.Text;
            }
        }

        private void treeViewParameters_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point point = new Point(e.X, e.Y);
                this._currentlySelectNode = treeViewParameters.GetNodeAt(point);
                if (this._currentlySelectNode != null)
                {
                      XElement nodeXML = (XElement)this._currentlySelectNode.Tag;

                      if (nodeXML.Attribute("type") != null && nodeXML.Attribute("type").Value.ToString() == "databaseField")
                      {
                          contextMenuStripNodeOptions.Items[2].Visible = true;
                          contextMenuStripNodeOptions.Show(treeViewParameters, point);
                      }
                      else
                      {
                          contextMenuStripNodeOptions.Items[2].Visible = false;
                          contextMenuStripNodeOptions.Show(treeViewParameters, point);
                      }
                  
                }
            }
        }

        private void toolStripMenuAddItem_Click(object sender, EventArgs e)
        {
            XElement currentNode = (XElement)this._currentlySelectNode.Tag;
            XElement newParameter = new XElement("parameter");
            newParameter.SetAttributeValue("name", "default");
            newParameter.SetAttributeValue("value", "default");
            newParameter.Add(new XElement("children"));
            currentNode.Element("children").Add(newParameter);
            Save();
        }

        private void toolStripMenuItemDeleteItem_Click(object sender, EventArgs e)
        {
            TreeNode parent =  this._currentlySelectNode.Parent;
            if (parent != null) // don't delete the root node dummy!
            {
                ((XElement)this._currentlySelectNode.Tag).Remove();
                parent.Nodes.Remove(this._currentlySelectNode);
                Save();
            }
        }

        private void buttonCopyToAllTemplates_Click(object sender, EventArgs e)
        {
            
        }

        private void Templates_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStripNodeOptions_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItemMapToDatabaseField_Click(object sender, EventArgs e)
        {

           

            XElement nodeXML = (XElement)this._currentlySelectNode.Tag;

            if (nodeXML.Attribute("type") != null && nodeXML.Attribute("type").Value.ToString() == "databaseField")
            {
                ProjectTemplate template = (ProjectTemplate)comboBoxTemplates.SelectedItem;


                if (!template.ScreenParameters.ContainsKey("DataInterfaceKey"))
                {
                    MessageBox.Show("To use database field mapping you must add a 'DataInterfaceKey' parameter to the template and set the value to a key on the Data Interfaces tab","Error");
                    return;
                }

                if (!template.ScreenParameters.ContainsKey("Table"))
                {
                    MessageBox.Show("To use database field mapping you must add a 'Table' parameter to the template and set a table from the database as the value","Error");
                    return;
                }

                if (!template.ScreenParameters.ContainsKey("Schema"))
                {
                    MessageBox.Show("To use database field mapping you must add a 'Schema' parameter to the template and set a table from the database as the value", "Error");
                    return;
                }


                string connectionString = ProjectContainer.GetInstance().ConnectionStrings[template.ScreenParameters["DataInterfaceKey"].ToString()].ToString();
                string schema = ProjectContainer.GetInstance().ConnectionStrings[template.ScreenParameters["Schema"].ToString()].ToString();
                Forms.FormMapToDatabase mapperForm = new Forms.FormMapToDatabase(template.ScreenParameters["Table"].ToString(),schema, connectionString);
                mapperForm.ShowDialog();

                XElement mappedDatabaseField = (from f in nodeXML.Element("children").Elements()
                                                where f.Attribute("name") != null && f.Attribute("name").Value == "mappedDatabaseFieldName"
                                                select f).FirstOrDefault();

                mappedDatabaseField.SetAttributeValue("value", mapperForm.ColumnName);

                XElement mappedDatabaseFieldType = (from f in nodeXML.Element("children").Elements()
                                                    where f.Attribute("name") != null && f.Attribute("name").Value == "mappedDatabaseFieldType"
                                                    select f).FirstOrDefault();

                mappedDatabaseFieldType.SetAttributeValue("value", mapperForm.SqlType);

                XElement mappedDatabaseFieldLength = (from f in nodeXML.Element("children").Elements()
                                                      where f.Attribute("name") != null && f.Attribute("name").Value == "mappedDatabaseFieldLength"
                                                      select f).FirstOrDefault();

                mappedDatabaseFieldLength.SetAttributeValue("value", mapperForm.MaxLength);
            }
        }

        private void toolStripMenuItemCopyToAllTemplates_Click(object sender, EventArgs e)
        {
            XElement tree = SaveTree();

            if (tree.Elements("root").Elements("children").Elements().Any()) //don't overwrite parameters in other templates if this template has none
            {

                Project project = (Project)comboBoxProjects.SelectedItem;
                foreach (ProjectTemplate projectTemplate in project.ProjectTemplateList)
                {
                    projectTemplate.ParametersTree = tree;
                }
                Save();
            }
            else
            {
                MessageBox.Show("Are you sure you want to copy a blank parameter tree to the other templates in this project?", "Confirm", MessageBoxButtons.OKCancel);
            }
        }

        private void toolStripMenuItemLoadFromStoredProcedure_Click(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedIndex > -1)
            {
                ProjectTemplate projectTemplate = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                Forms.FormLoadFromStoredProcedure loadFromStoredProcedure = new Forms.FormLoadFromStoredProcedure(projectTemplate);
                loadFromStoredProcedure.ShowDialog();
                if (comboBoxProjects.SelectedIndex > -1)
                {
                    if (comboBoxTemplates.SelectedIndex > -1)
                    {
                        Save();
                    }
                }
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStripParameterOptions.Show(ptLowerLeft);
        }

        private void contextMenuStripParameterOptions_Opening(object sender, CancelEventArgs e)
        {

        }

        private void loadFromTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedIndex > -1)
            {
                ProjectTemplate projectTemplate = (ProjectTemplate)comboBoxTemplates.SelectedItem;
                Forms.FormLoadFromTable loadFromTable = new Forms.FormLoadFromTable(projectTemplate);
                loadFromTable.ShowDialog();
                if (comboBoxProjects.SelectedIndex > -1)
                {
                    if (comboBoxTemplates.SelectedIndex > -1)
                    {
                        Save();
                    }
                }
            }
        }

        private void dataGridViewParameters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //this is the key column. We don't want to uppercase the value column
            {
                if (e.RowIndex > -1)
                {
                    dataGridViewParameters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridViewParameters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
            }
        }

       
    }
}
