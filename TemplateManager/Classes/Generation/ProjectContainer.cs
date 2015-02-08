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
        public  string FileLocation = (Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ProjectContainer.Filename));
        public static string Filename = "projects.xml";
        public List<Project> ProjectList;
        public EventHandler Reload;
        private static ProjectContainer _projectContainer;

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

        public bool Save(string filename)
        {
            XDocument xDoc = new XDocument();
            XElement root = new XElement("xml");
            XElement projects= new XElement("projects");

            foreach(Project project in this.ProjectList)
            {
                projects.Add(project.Export());
            }
            root.Add(projects);
            xDoc.Add(root);
            xDoc.Save(filename);
            this.Load(this.FileLocation);
            return true;
        }

        public bool Load(string filename)
        {

            try
            {
                XDocument xDoc = XDocument.Load(filename);

                this.ProjectList = (from project in xDoc.Root.Element("projects").Descendants("project")
                                          select new Project
                                          {
                                              ID = Guid.Parse(project.Element("id").Value),
                                              Name = (string)project.Element("name").Value ?? string.Empty,
                                              ConnectionStrings =  (from p in project.Element("connectionStrings").Descendants("connectionString")
                                                                                       select new
                                                                                       {
                                                                                           key = (string)p.Element("key").Value ?? string.Empty,
                                                                                           value = (string)p.Element("value").Value ?? string.Empty
                                                                                       }).ToDictionary(pair => pair.key, pair => pair.value),

                                              ProjectTemplateList = (from pt in project.Elements("projectTemplates").Descendants("projectTemplate")
                                                                     select new ProjectTemplate
                                                                     {
                                                                         TemplateName = (string)pt.Element("templateName").Value ?? string.Empty,
                                                                         OutputDirectory = (string)pt.Element("outputDirectory").Value ?? string.Empty,
                                                                         Parameters = (from p in pt.Element("parameters").Descendants("parameter")
                                                                                       select new
                                                                                       {
                                                                                           key = (string)p.Element("key").Value ?? string.Empty,
                                                                                           value = (string)p.Element("value").Value ?? string.Empty
                                                                                       }).ToDictionary(pair => pair.key, pair => pair.value),
                                                                       
                                                                     }).ToList<ProjectTemplate>()
                                              

                                          }).ToList<Project>();
                
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
