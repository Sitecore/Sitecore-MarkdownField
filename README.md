# Sitecore Markdown Field

A quick and dirty example of how to create a custom field in Sitecore. 
Created for the Bristol Sitecore User Group (SCUG).

The field uses [showdown.js](http://softwaremaniacs.org/playground/showdown-highlight/) to render the live preview in the Content Editor and then uses [MarkdownSharp](http://code.google.com/p/markdownsharp/) to render the HTML on the front end.

### Pre-Requisites

This project is build for Sitecore 7 and requires .NET 4.5.

### Installation

* Install the Sitecore package located in the `packages` directory. This contains everything you need in order to start using the markdown field on your Sitecore install.

### Manually Build and Install
* Copy `Sitecore.Kernel.dll` into the /lib directory and build.
* Copy the resulting DLL (`SCUG.MarkdownField.dll`) and `MarkdownSharp.dll` into your `\bin` directory of your Sitecore install.
* Copy `MarkdownField.config` to the `App_Config\Include` directory of your Sitecore install.
* Copy `showdown.js` to the `sitecore modules\Shell\MarkdownField\js` directory of your Sitecore install.
* You need to create a field type item similar to the one included in the Install package:

  You'll have to add a field type named `markdown` based on `/sitecore/templates/System/Templates/Template field type` and with the following specified in the Control attribute `markdown:MarkdownField`.

### Disclaimer
This is, of course, **not** production code but simply to demonstrate how a simple custom field can be created in Sitecore. 

### Fork Me!
If you think this is worth improving then fork it and I'm very happy to accept pull requests! 