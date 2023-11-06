using ProFolder.Handlers.Interfaces;
using ProFolder.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFolder.Handlers
{
    public class CreateFoldersHandler
    {
        protected readonly TraceHandler _traceHandler;

        public CreateFoldersHandler(TraceHandler traceHandler)
        {
            _traceHandler = traceHandler;
        }

        protected void CreateFolders(FolderType folderType, string[] args)
        {
            switch (folderType)
            {
                case FolderType.ProjectFolders:
                    {
                        if (args.Contains("."))
                        {
                            if (!FolderHelper.IsFolderEmpty(FolderHelper.CurrentPath))
                            {
                                throw new Exception("Folder not empty!");
                            }
                            CreateFoldersInCurrentFolder(folderType);
                        }
                        else if (!string.IsNullOrEmpty(args[1]))
                        {
                            CreateFoldersInFolder(args[1], folderType);
                        }
                        else
                        {
                            throw new ArgumentNullException("Project Name");
                        }
                        break;
                    }

                case FolderType.RootFolders:
                    {
                        CreateFoldersInCurrentFolder(folderType);
                        break;
                    }
            }
        }

        protected void CreateFoldersInCurrentFolder(FolderType folderType)
        {
            try
            {
                var folderList = FolderStructureReader.GetFolders(folderType);
                FolderHelper.CreateDirectories(folderList, Directory.GetCurrentDirectory());
            }
            catch (Exception e)
            {
                _traceHandler.PrintMessage($"An error occurred while creating folders: {e.Message}");
            }
        }

        protected void CreateFoldersInFolder(string folder, FolderType folderType)
        {
            try
            {
                Directory.CreateDirectory(folder);
                _traceHandler.PrintMessage($"Created project folder: {folder}");

                Directory.SetCurrentDirectory(folder);
                var folderList = FolderStructureReader.GetFolders(folderType);
                FolderHelper.CreateDirectories(folderList, Directory.GetCurrentDirectory());
            }
            catch (Exception e)
            {
                _traceHandler.PrintMessage($"An error occurred while creating project: {e.Message}");
            }
        }
    }
}
