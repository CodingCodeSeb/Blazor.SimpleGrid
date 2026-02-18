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

## Configuration

### SimpleGrid (Container)
- Columns: string (e.g., "1fr 100px")
- Rows: string (optional)
- Gap: string (combined shorthand)
- TemplateAreas: string (separated by |)
- Horizontal: HorizontalAlignment Enum
- AutoFlow: GridAutoFlow Enum

### SimpleGridItem (Element)
- Area: string (assigned area name)
- ColumnSpan: int (span count)
- RowSpan: int (span count)
- Horizontal: HorizontalAlignment (Self)

---

## Quality Assurance

Verified by an automated test suite using bUnit and NUnit.
Run tests locally with: `dotnet test`

---

## License

MIT License. See LICENSE file for details.