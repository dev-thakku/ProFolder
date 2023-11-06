using ProFolder.Handlers;

namespace ProFolder.Utils
{
    public static class FolderHelper
    {
        public static string CurrentPath { get { return Directory.GetCurrentDirectory(); } }

        public static bool IsFolderEmpty(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        public static void CreateDirectories(List<Folder> folders, string parentPath)
        {
            foreach (var folder in folders)
            {
                string fullPath = Path.Combine(parentPath, folder.Name);
                Directory.CreateDirectory(fullPath);

                if (folder.SubFolders != null)
                {
                    CreateDirectories(folder.SubFolders, fullPath);
                }
            }
        }
    }
}
