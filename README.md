# ProFolder

ProFolder is a command line tool that simplifies the process of creating standardized project folder structures. ProFolder allows users to create and customize project directories efficiently. With ProFolder, you can effortlessly generate a comprehensive directory setup for your projects, including essential folders for storing documentations, source codes, reference materials and temporary files to keep your work organized. Save time and streamline your project setup with ProFolder.

## Installation

To use ProFolder, clone the repository and build the solution using Visual Studio or your preferred C# development environment.

## Usage

- **CreateRoot**: Use this command to create the root folder for the project structure.

```
ProFolder.exe CreateRoot
```

- **CreateProject**: Use this command to generate a project with the folder structure specified in the 'folder.config' file.

```
ProFolder.exe CreateProject
```

## Configuring Folder Structure

To customize folder names and order, modify the 'folder.config' file in the project directory. The 'folder.config' file allows you to specify the folder names and their desired order for each project.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
