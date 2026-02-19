using Blazor.SimpleGrid.Extensions;
using Blazor.SimpleGrid.Models;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Sg = Blazor.SimpleGrid.Components;
using Sge = Blazor.SimpleGrid.Enums;

namespace Blazor.SimpleGrid.Test;

[TestFixture]
public class GridComponentTests
{
    private BunitContext _context;

    [SetUp]
    public void SetUp() => _context = new BunitContext();

    [TearDown]
    public void TearDown() => _context.Dispose();

    // --- Container Tests (SimpleGrid) ---

    [Test]
    public void Grid_ShouldApplyAlignmentProperties()
    {
        var cut = _context.Render<Sg.SimpleGrid>(parameters => parameters
            .Add(p => p.HorizontalAlignment, Sge.HorizontalAlignment.Center)
            .Add(p => p.VerticalAlignment, Sge.VerticalAlignment.End)
        );

        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("justify-content: center;"));
        Assert.That(style, Does.Contain("align-items: end;"));
    }

    [Test]
    public void Grid_ShouldApplyNewProperties_WidthAndRows()
    {
        var cut = _context.Render<Sg.SimpleGrid>(parameters => parameters
            .Add(p => p.Width, "100%")
            .Add(p => p.Rows, "100px 1fr")
            .Add(p => p.AutoColumns, "200px")
        );

        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("width: 100%;"));
        Assert.That(style, Does.Contain("grid-template-rows: 100px 1fr;"));
        Assert.That(style, Does.Contain("grid-auto-columns: 200px;"));
    }

    [Test]
    public void Grid_ShouldApplyAutoFlowAndRows()
    {
        var cut = _context.Render<Sg.SimpleGrid>(parameters => parameters
            .Add(p => p.AutoFlow, Sge.GridAutoFlow.ColumnDense)
            .Add(p => p.AutoRows, "min-content")
        );

        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("grid-auto-flow: column dense;"));
        Assert.That(style, Does.Contain("grid-auto-rows: min-content;"));
    }

    [Test]
    public void Grid_ShouldApplyHeight()
    {
        var cut = _context.Render<Sg.SimpleGrid>(parameters => parameters
            .Add(p => p.Height, "500px")
        );

        var style = cut.Find("div").GetAttribute("style");
        Assert.That(style, Does.Contain("height: 500px;"));
    }

    // --- Global Options Tests (Dependency Injection) ---

    [Test]
    public void Grid_ShouldUseGlobalOptions_WhenNoParametersSet()
    {
        // 1. Globalen Dienst mit speziellen Werten registrieren
        _context.Services.AddSimpleGrid(globalOptions =>
        {
            globalOptions.HorizontalGap = "55px";
            globalOptions.VerticalAlignment = Sge.VerticalAlignment.Center;
        });

        // 2. Grid ohne Parameter rendern
        var cut = _context.Render<Sg.SimpleGrid>();
        var style = cut.Find("div").GetAttribute("style");

        // 3. Prüfen, ob die globalen Werte im Style landen
        Assert.That(style, Does.Contain("column-gap: 55px;"));
        Assert.That(style, Does.Contain("align-items: center;"));
    }

    [Test]
    public void Grid_ShouldOverrideGlobalOptions_WithLocalParameters()
    {
        // 1. Globalen Dienst registrieren (z.B. 55px Gap)
        _context.Services.AddSingleton(new SimpleGridOptions { HorizontalGap = "55px" });

        // 2. Lokal am Tag 10px Gap setzen
        var cut = _context.Render<Sg.SimpleGrid>(parameters => parameters
            .Add(p => p.HorizontalGap, "10px")
        );
        var style = cut.Find("div").GetAttribute("style");

        // 3. Lokal muss gewinnen!
        Assert.That(style, Does.Contain("column-gap: 10px;"));
        Assert.That(style, Does.Not.Contain("column-gap: 55px;"));
    }

    [Test]
    public void GridItem_ShouldUseGlobalOptions_ForSelfAlignment()
    {
        // 1. Globale Item-Ausrichtung festlegen
        _context.Services.AddSingleton(new SimpleGridOptions
        {
            ItemHorizontalAlignment = Sge.HorizontalAlignment.End
        });

        var cut = _context.Render<Sg.SimpleGridItem>();
        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("justify-self: end;"));
    }

    // --- Item Tests (SimpleGridItem) ---

    [Test]
    public void GridItem_ShouldApplySpecificPositioning()
    {
        var cut = _context.Render<Sg.SimpleGridItem>(parameters => parameters
            .Add(p => p.Column, "2")
            .Add(p => p.Row, "1")
        );

        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("grid-column: 2 / span 1;"));
        Assert.That(style, Does.Contain("grid-row: 1 / span 1;"));
    }

    [Test]
    public void GridItem_ShouldApplySelfAlignment()
    {
        var cut = _context.Render<Sg.SimpleGridItem>(parameters => parameters
            .Add(p => p.HorizontalAlignment, Sge.HorizontalAlignment.Start)
            .Add(p => p.VerticalAlignment, Sge.VerticalAlignment.Baseline)
        );

        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("justify-self: start;"));
        Assert.That(style, Does.Contain("align-self: baseline;"));
    }

    [Test]
    public void GridItem_Area_ShouldTakePrecedence()
    {
        // Wenn Area gesetzt ist, sollte die manuelle Spaltenberechnung ignoriert werden
        var cut = _context.Render<Sg.SimpleGridItem>(parameters => parameters
            .Add(p => p.Area, "sidebar")
            .Add(p => p.ColumnSpan, 5) // Sollte im Style nicht auftauchen, wenn Area genutzt wird
        );

        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("grid-area: sidebar;"));
        Assert.That(style, Does.Not.Contain("grid-column:"));
    }

    // --- Spezialfall: TemplateAreas Formatierung ---

    [Test]
    public void Grid_ShouldFormatComplexTemplateAreas()
    {
        var cut = _context.Render<Sg.SimpleGrid>(parameters => parameters
            .Add(p => p.TemplateAreas, "a b | c d | e f")
        );

        var style = cut.Find("div").GetAttribute("style");

        // Erwartet: "a b" "c d" "e f"
        Assert.That(style, Does.Contain("grid-template-areas: \"a b\" \"c d\" \"e f\";"));
    }

    // --- Content Test ---

    [Test]
    public void Grid_ShouldRenderChildContent()
    {
        var cut = _context.Render<Sg.SimpleGrid>(parameters => parameters
            .AddChildContent("<span id='test-child'>Hello</span>")
        );

        Assert.That(cut.Find("#test-child"), Is.Not.Null);
        Assert.That(cut.Find("#test-child").TextContent, Is.EqualTo("Hello"));
    }
}
