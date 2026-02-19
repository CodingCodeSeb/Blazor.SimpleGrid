# Blazor.SimpleGrid

![Build Status](https://github.com/CodingCodeSeb/Blazor.SimpleGrid/actions/workflows/dotnet-ci.yml/badge.svg)
![NuGet Version](https://img.shields.io/nuget/v/Blazor.SimpleGridComponent)
![License](https://img.shields.io/github/license/CodingCodeSeb/Blazor.SimpleGrid)

A modern, lightweight Blazor component library for creating **CSS Grid Layouts**. Define complex structures directly in Razor syntax without writing manual CSS.

---

## Features

- Type-Safe: Use Enums for alignments and flows instead of error-prone strings.
- Intuitive Areas: Define layout zones with a simple pipe syntax (header | content).
- Smart Logic: Automatic prioritization of Gap over individual spacing properties.
- Flexible: Full support for Attribute Splatting (CSS classes, IDs, etc.).
- Lightweight: No external CSS frameworks or JavaScript dependencies required.

---

## Live Demo
> Explore all features and live examples here:
[https://codingcodeseb.github.io/Blazor.SimpleGrid/](https://codingcodeseb.github.io/Blazor.SimpleGrid/)

---

## Installation

1. Install the package via NuGet:
   `dotnet add package Blazor.SimpleGridComponent`

2. Add the namespace to your _Imports.razor:
   `@using Blazor.SimpleGrid.Components`
   `@using Blazor.SimpleGrid.Enums`

---

## Usage

### Simple 3-Column Grid
```razor
<SimpleGrid Columns="1fr 1fr 1fr" Gap="20px">
    <SimpleGridItem>Item 1</SimpleGridItem>
    <SimpleGridItem>Item 2</SimpleGridItem>
    <SimpleGridItem>Item 3</SimpleGridItem>
</SimpleGrid>
```

### Complex Layout with Template Areas
```razor
<SimpleGrid Columns="250px 1fr" 
            TemplateAreas="header header | sidebar content | footer footer"
            Gap="15px">
            
    <SimpleGridItem Area="header">Header</SimpleGridItem>
    <SimpleGridItem Area="sidebar">Nav</SimpleGridItem>
    <SimpleGridItem Area="content">Main</SimpleGridItem>
    <SimpleGridItem Area="footer">Footer</SimpleGridItem>
</SimpleGrid>
```

---

## Global Configuration (Optional)

You can define project-wide defaults for your grids using the SimpleGridOptions. This is useful for maintaining consistent spacing and alignment across your entire application without repeating parameters on every component.

### 1. Registration in Program.cs

You can register the services in your Program.cs file.:

Custom Global Defaults
This allows you to override any property for all grids in your app.
```csharp
builder.Services.AddSimpleGrid(options => { options.HorizontalGap = "20px"; options.VerticalGap = "20px"; options.ItemHorizontalAlignment = HorizontalAlignment.Center; options.Columns = "1fr 1fr"; // All grids will default to 2 columns });
```

### 2. Priority Order

The components follow a strict priority logic to determine which value to use:
1. Local Parameter: Value set directly on the <SimpleGrid> or <SimpleGridItem> tag.
2. Global Options: Value set in Program.cs via AddSimpleGrid.
3. Library Defaults: Hardcoded fallbacks in the SimpleGridOptions class.

---

## API Reference
#### SimpleGrid (Container)

| Property | Type | Default | Description |
| :--- | :--- | :--- | :--- |
| Columns | string | Options.Columns | Defines grid columns (e.g., "1fr 2fr"). |
| Rows | string | "none" | Defines explicit grid rows. |
| TemplateAreas| string | null | Named areas using &vert; as row separator. |
| AutoFlow | GridAutoFlow| Row | Controls the auto-placement algorithm. |
| AutoColumns | string | "auto" | Size of implicitly created columns. |
| AutoRows | string | "auto" | Size of implicitly created rows. |
| Gap | string | null | Shorthand for both Horizontal and Vertical gap. |
| Width | string | "auto" | Width of the grid container. |
| Height | string | "auto" | Height of the grid container. |
| HorizontalAlignment | HorizontalAlignment | Start | Align grid content (justify-content). |
| VerticalAlignment | VerticalAlignment | Stretch | Align items (align-items). |
#### SimpleGridItem (Element)

| Property | Type | Default | Description |
| :--- | :--- | :--- | :--- |
| Area | string | "" | Name of the target grid area. |
| Column | string | "auto" | Starting column position. |
| Row | string | "auto" | Starting row position. |
| ColumnSpan | int | 1 | Number of columns to span. |
| RowSpan | int | 1 | Number of rows to span. |
| HorizontalAlignment | HorizontalAlignment | Stretch | justify-self. |
| VerticalAlignment | VerticalAlignment | Stretch | align-self. |

---

## Quality Assurance

Verified by an automated test suite using bUnit and NUnit.
Run tests locally with: `dotnet test`

---

## License

MIT License. See LICENSE file for details.