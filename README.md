# Sitecore Markdown Field

A quick and dirty example of how to create a custom field in Sitecore. 
Created for the Bristol Sitecore User Group (SCUG).

The field uses [`showdown.js`](http://softwaremaniacs.org/playground/showdown-highlight/) to render the live preview in the Content Editor and then uses [`MarkdownSharp`](http://code.google.com/p/markdownsharp/) to render the HTML on the front end.

### Build / Installation
* Copy `Sitecore.Kernel.dll` into the /lib directory and build.
* Copy the resulting DLL into your `\bin` directory
* Copy `MarkdownField.config` to the `App_Config\Includes` directory of your Sitecore install.
* Install the Sitecore package in the `packages` dir. This contains the custom field (in `Core`) which you can then include it in one of your templates.

### Disclaimer
This is, of course, **not** production code but simply to demonstrate how a simple custom field can be created in Sitecore. 

### Fork Me!
If you think this is worth improving then fork it and I'm very happy to accept pull requests ! 