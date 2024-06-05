
# Introduction
WeasyPrint Wrapper for .Net on Windows to generate pdf from html. It uses [WeasyPrint](https://github.com/Kozea/WeasyPrint) to generate pdf from html without any extra installation and setup on Windows.

`Gtb.WeasyPrint` simplifies the using of WeasyPrint on Windows, it is a minor change from `Balbarak.WeasyPrint` 


# Getting started

## Installation

As nuget package, the tb version is not on nuget.org, so first add a local repository and copy the .nupkg to it.

`PM> Install-Package Gtb.WeasyPrint`

It is also possible to install as dll reference, or even as a project reference.

## Usage

### From html text 

```C#
using Gtb.WeasyPrint
using System.IO;

using (WeasyPrintClient client = new WeasyPrintClient(@"E:\path\to\weasy"))
{
    var html = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";

    var binaryPdf = await client.GeneratePdfAsync(html);

    File.WriteAllBytes("result.pdf",binaryPdf);
}
```

### From html file
```C#
using (WeasyPrintClient client = new WeasyPrintClient(@"E:\path\to\weasy"))
{
    var input = @"path\to\input.html";
    var output = @"path\to\output.pdf";

    await client.GeneratePdfAsync(input,output);
}
```

### Watch output and errors
```C#
using (WeasyPrintClient client = new WeasyPrintClient(@"E:\path\to\weasy"))
{
    var input = @"path\to\input.html";
    var output = @"path\to\output.pdf";

    client.OnDataError += OnDataError;
    client.OnDataOutput += OnDataOutput;

    await client.GeneratePdfAsync(input,output);
}

private void OnDataOutput(OutputEventArgs e)
{
    Console.WriteLine(args.Data);
}

private void OnDataError(OutputEventArgs e)
{
    Console.WriteLine(e.Data);
}
```

# Third Parties
* [Balbarak/WeasyPrint-netcore](https://github.com/balbarak/WeasyPrint-netcore) - BSD-3-Clause license
* [WeasyPrint](https://github.com/Kozea/WeasyPrint) - BSD 3-Clause License 
* [Python 3.6 Embedded](https://wiki.python.org/moin/EmbeddedPython) - [PSF License](https://docs.python.org/3/license.html)
* Gtk3 for Windows:  [Windows package](https://github.com/tschoonj/GTK-for-Windows-Runtime-Environment-Installer),  [Documentation](https://gnome.pages.gitlab.gnome.org/gtk/) - [LGPL 2](https://gitlab.gnome.org/GNOME/gtk/-/blob/main/COPYING)
