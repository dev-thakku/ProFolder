using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace ProFolder.Utils
{
    public class Folder
    {
        public string Name { get; set; } = string.Empty;
        public List<Folder> SubFolders { get; set; } = new List<Folder>();
    }

    public static class FolderStructureReader
    {
        public static List<Folder> GetFolders(FolderType folderType)
        {
            string baseFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string jsonFilePath = baseFolder + "\\folderStructure.json"; // Replace with your actual JSON file path

            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                dynamic data = JsonConvert.DeserializeObject(jsonString);

                JArray folders;
                if (folderType == FolderType.RootFolders)
                {
                    folders = data["rootfolders"];
                }
                else if (folderType == FolderType.ProjectFolders)
                {
                    folders = data["projectFolders"];
                }
                else
                {
                    throw new ArgumentException("Invalid folder type.");
                }

                List<Folder> folderList = new List<Folder>();
                foreach (var folder in folders)
                {
                    Folder currentFolder = new Folder
                    {
                        Name = GetFolderName(folder),
                        SubFolders = new List<Folder>()
                    };

                    if (folder["subfolders"] != null)
                    {
                        currentFolder.SubFolders = GetSubfolders((JArray)folder["subfolders"]);
                    }

                    folderList.Add(currentFolder);
                }

                return folderList;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while reading the JSON file: " + e.Message);
                return new List<Folder>();
            }
        }

        private static List<Folder> GetSubfolders(JArray subfolders)
        {
            List<Folder> subfolderList = new List<Folder>();
            foreach (var subfolder in subfolders)
            {
                Folder currentSubFolder = new Folder
                {
                    Name = GetFolderName(subfolder),
                    SubFolders = new List<Folder>()
                };

                if (subfolder["subfolders"] != null)
                {
                    currentSubFolder.SubFolders = GetSubfolders((JArray)subfolder["subfolders"]);
                }

                subfolderList.Add(currentSubFolder);
            }
            return subfolderList;
        }

        private static string GetFolderName(JToken folder)
        {
            return folder["priority"]?.ToString() + "_" + folder["name"]?.ToString();
        }
    }
}