# UmbracoProjectWizard
Fun project creating a wizard for creating Umbraco projects wrapping the CLI commands

This project uses AvaloniaUI as base for the desktop UI. It is extended with Material.Avalonia for a prettier UI.

## CLI support
The app uses CLIWrap to interact with the dotnet CLI to use it's commands to create the project, add packages and the solution file.

## Umbraco Packages
Umbraco packages can be currated via a yaml file where you can add packages you want to be selectable.
It comes with a small number of pre-selected packages.
The file is read and converted using the YamlDotNet library.


## Preview
For a sneak peak at the outcome:

[![Watch the video](https://img.youtube.com/vi/DgNTzljC5o8/default.jpg)](https://youtu.be/DgNTzljC5o8)