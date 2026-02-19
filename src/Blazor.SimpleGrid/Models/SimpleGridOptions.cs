using Blazor.SimpleGrid.Enums;

namespace Blazor.SimpleGrid.Models;

/// <summary>
/// Global configuration options for the SimpleGrid library.
/// These values serve as the default configuration for all grid components 
/// unless overridden by local parameters.
/// </summary>
public class SimpleGridOptions
{
    // --- Grid Structure Defaults ---

    /// <summary>
    /// The default column definition (grid-template-columns).
    /// Default: "repeat(auto-fit, minmax(200px, 1fr))"
    /// </summary>
    public string Columns { get; set; } = "repeat(auto-fit, minmax(200px, 1fr))";

    /// <summary>
    /// The default row definition (grid-template-rows).
    /// Default: "none"
    /// </summary>
    public string Rows { get; set; } = "none";

    /// <summary>
    /// Default size for implicitly created columns (grid-auto-columns).
    /// Default: "auto"
    /// </summary>
    public string AutoColumns { get; set; } = "auto";

    /// <summary>
    /// Default size for implicitly created rows (grid-auto-rows).
    /// Default: "auto"
    /// </summary>
    public string AutoRows { get; set; } = "auto";

    /// <summary>
    /// Default auto-placement algorithm for the grid (grid-auto-flow).
    /// Default: Row
    /// </summary>
    public GridAutoFlow AutoFlow { get; set; } = GridAutoFlow.Row;

    // --- Spacing Defaults ---

    /// <summary>
    /// Default spacing between grid columns (column-gap).
    /// Default: "1rem"
    /// </summary>
    public string HorizontalGap { get; set; } = "1rem";

    /// <summary>
    /// Default spacing between grid rows (row-gap).
    /// Default: "1rem"
    /// </summary>
    public string VerticalGap { get; set; } = "1rem";

    // --- Dimension Defaults ---

    /// <summary>
    /// Default width of the grid container.
    /// Default: "auto"
    /// </summary>
    public string Width { get; set; } = "auto";

    /// <summary>
    /// Default height of the grid container.
    /// Default: "auto"
    /// </summary>
    public string Height { get; set; } = "auto";

    // --- Container Alignment Defaults ---

    /// <summary>
    /// Default horizontal alignment of the entire grid content (justify-content).
    /// Default: Start
    /// </summary>
    public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Start;

    /// <summary>
    /// Default vertical alignment of the grid items within their areas (align-items).
    /// Default: Stretch
    /// </summary>
    public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Stretch;

    // --- GridItem Defaults ---

    /// <summary>
    /// Default horizontal alignment for individual grid items (justify-self).
    /// Default: Stretch
    /// </summary>
    public HorizontalAlignment ItemHorizontalAlignment { get; set; } = HorizontalAlignment.Stretch;

    /// <summary>
    /// Default vertical alignment for individual grid items (align-self).
    /// Default: Stretch
    /// </summary>
    public VerticalAlignment ItemVerticalAlignment { get; set; } = VerticalAlignment.Stretch;
}