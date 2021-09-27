using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Managers
{
    public abstract class AResourceManager<T>
    {
        #region Properties
        protected string ResourcePath { get; set; } = ".";
        protected string DefaultResourceName { get; set; }
        protected string FileExtension { get; set; }
        protected Dictionary<string, T> Resources { get; set; }
        #endregion

        #region Constructors
        public AResourceManager()
        {
            Resources = new Dictionary<string, T>();
        }

        public AResourceManager(string resourcePath, string fileExtension, string defaultResourceName = null) : this()
        {
            ResourcePath = resourcePath;
            FileExtension = fileExtension;
            DefaultResourceName = defaultResourceName;
        }
        #endregion

        #region Methods
        public virtual T GetResource(string systemName)
        {
            T resource;
            if (Resources.TryGetValue(systemName, out resource))
            {
                return resource;
            }
            var filePath = GetFilePath(systemName);
            if (!File.Exists(filePath))
            {
                if (DefaultResourceName != null)
                {
                    filePath = GetFilePath(DefaultResourceName);
                }
                else
                {
                    throw new Exception($"File {filePath} does not exist.");
                }
            }
            resource = LoadResource(filePath);
            Resources[systemName] = resource;
            return resource;
        }

        protected virtual string GetFilePath(string systemName)
        {
            var fileName = systemName.Replace(".", "/") + (FileExtension != null ? "." + FileExtension : "");
            return Path.Combine(ResourcePath, fileName);
        }

        protected abstract T LoadResource(string filePath);
        #endregion

    }
}
