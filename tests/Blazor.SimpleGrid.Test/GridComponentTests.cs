using Bunit;
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
            .Add(p => p.Horizontal, Sge.HorizontalAlignment.Center)
            .Add(p => p.Vertical, Sge.VerticalAlignment.End)
        );

        var style = cut.Find("div").GetAttribute("style");

        Assert.That(style, Does.Contain("justify-content: center;"));
        Assert.That(style, Does.Contain("align-items: end;"));
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
            .Add(p => p.Horizontal, Sge.HorizontalAlignment.Start)
            .Add(p => p.Vertical, Sge.VerticalAlignment.Baseline)
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
