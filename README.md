# Calendar PDF Generator

This tool was created to easily _generate_ and print refills for your calendar/planner yourself. It comes with two premade templates, one for a _single page_ A4 layout, and a _double sided_ A5 layout.

It outputs a single merged PDF file `result.pdf` containing all pages in the correct printing order.

<p align="center">
  <img src="https://0x0.st/o64h.png" />
</p>

## Building
This project was built using .NET 6.0 Core. For building the following NuGet dependencies are needed:
- [PdfSharp](http://www.pdfsharp.net/)
- `System.Text.Encoding.CodePages`

To build, simply execute the following command:
```bash
dotnet build
```
The corresponding executable `calendar.exe` will be in the `bin` directory.

## Usage
We use a very simplistic approach to PDF generation. So far, there was no need to integrate a fully-fledged templating engine, nor a dedicated library for programmatic PDF generation (such as QuestPDF). Instead, the templates are written using normal HTML/CSS with specific placeholders that are to be replaced. For this, we use a helper tool [wkhtmltopdf](https://wkhtmltopdf.org/) that stems the actual `HTML -> PDF` conversion.

It is therefore required to have the `wkhtmltopdf` binaries included in your `PATH` environment variable.

**Usage is then very simple:** Simply pick the wanted year and a format/template that is to be generated and hit `Generate`.