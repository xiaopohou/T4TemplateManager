using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class ProjectContainer
    {
        public  string ProjectsRootDirectory = (Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Projects"));
        public List<Project> ProjectList;
        public EventHandler Reload; //notify listeners that we have saved and they need to reload data
        private static ProjectContainer _projectContainer;
        public Dictionary<string, string> ConnectionStrings;

        public static ProjectContainer GetInstance()
        {
            if(_projectContainer == null)
            {
                _projectContainer = new ProjectContainer();
            }
            return _projectContainer;
        }

        private ProjectContainer()
        {
            this.ProjectList = new List<Project>();
            this.ConnectionStrings = new Dictionary<string, string>();
        }

        public bool UpdateProject(Project project)
        {
            if (project.ID == Guid.Empty)
            {
                project.ID = Guid.NewGuid();
                this.ProjectList.Add(project);
            }
            else
            {
                int index = this.ProjectList.ToList().FindIndex(x => x.ID == project.ID);
                System.Diagnostics.Debug.Assert(index > -1, "index should always be found");
                if (index > -1)
                {
                    this.ProjectList[index] = project;
                }          
            }
            return true;
        }

        public bool DeleteProject(Guid id)
        {
            int index = this.ProjectList.ToList().FindIndex(x => x.ID == id);
            System.Diagnostics.Debug.Assert(index > -1, "index should always be found");
            this.ProjectList.RemoveAt(index);
            return true;
        }

        public bool Save()
        {
            try
            {
                foreach (Project project in this.ProjectList)
                {
                    XDocument xDoc = new XDocument();
                    XElement root = new XElement("xml");
                    root.Add(project.Export());
                    xDoc.Add(root);
                    if (!Directory.Exists(Path.Combine(ProjectsRootDirectory, project.Name)))
                    {
                        Directory.CreateDirectory(Path.Combine(ProjectsRootDirectory, project.Name));
                    }

                    if (!Directory.Exists(Path.Combine(ProjectsRootDirectory, project.Name,"Assets")))
                    {
                        Directory.CreateDirectory(Path.Combine(ProjectsRootDirectory, project.Name,"Assets"));
                    }

                    if (!Directory.Exists(Path.Combine(ProjectsRootDirectory, project.Name, "WorkingDirectory")))
                    {
                        Directory.CreateDirectory(Path.Combine(ProjectsRootDirectory, project.Name, "WorkingDirectory"));
                    }

                    xDoc.Save(Path.Combine(ProjectsRootDirectory, project.Name, "project.xml"));
                }

                this.Load();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool LoadConnectionStrings()
        {
            this.ConnectionStrings = new Dictionary<string,string>();
            System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(
             System.Configuration.ConfigurationUserLevel.None);
            foreach (System.Configuration.ConnectionStringSettings connectionString in configuration.ConnectionStrings.ConnectionStrings)
            {
                if (!String.Equals(connectionString.Name, "LocalMySqlServer", StringComparison.CurrentCultureIgnoreCase) && !String.Equals(connectionString.Name, "LocalSqlServer", StringComparison.CurrentCultureIgnoreCase)) //IDK where these two string come from
                {
                    this.ConnectionStrings[connectionString.Name] = connectionString.ConnectionString;
                }
            }
            return true;
        }
        public bool Load()
        {
            try
            {
                this.ProjectList = new List<Project>();
                string [] directories = Directory.GetDirectories(ProjectsRootDirectory);

                foreach(string directory in directories)
                {
                XDocument xDoc = XDocument.Load(Path.Combine(directory,"project.xml"));



                Project project = (from p in xDoc.Root.Descendants("project")
                                          select new Project
                                          {
                                              ID = Guid.Parse(p.Element("id").Value),
                                              Name = (string)p.Element("name").Value ?? string.Empty,

                                              ProjectTemplateList = (from pt in p.Elements("projectTemplates").Descendants("projectTemplate")
                                                                     select new ProjectTemplate
                                                                     {
                                                                         TemplateName = (string)pt.Element("templateName").Value ?? string.Empty,
                                                                         Parameters = (from par in pt.Element("parameters").Descendants("parameter")
                                                                                       select new
                                                                                       {
                                                                                           key = (string)par.Element("key").Value ?? string.Empty,
                                                                                           value = (string)par.Element("value").Value ?? string.Empty
                                                                                       }).ToDictionary(pair => pair.key, pair => pair.value),
                                                                       
                                                                     }).ToList<ProjectTemplate>()
                                              

                                          }).FirstOrDefault();
                    this.ProjectList.Add(project);
                
                }

                this.LoadConnectionStrings();
                if(this.Reload != null)
                {
                    this.Reload(this,EventArgs.Empty);
                }
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }  
        }
    }
}
