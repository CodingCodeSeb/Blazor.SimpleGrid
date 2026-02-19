using Blazor.SimpleGrid.Enums;

namespace Blazor.SimpleGrid.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Converts a type-safe Enum value into its corresponding CSS property string.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>A string formatted for CSS inline styles.</returns>
    public static string ToCss(this GridAutoFlow value)
        => value switch
        {
            // Special handling for combined Auto-Flow values
            GridAutoFlow.RowDense => "row dense",
            GridAutoFlow.ColumnDense => "column dense",

            // Default case: Simply convert to lowercase 
            // (Works for: Start, Center, End, Stretch, Baseline, Row, Column, Dense)
            _ => value.ToString().ToLower()
        };

    /// <summary>
    /// Converts a type-safe Enum value into its corresponding CSS property string.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>A string formatted for CSS inline styles.</returns>
    public static string ToCss(this HorizontalItemAlignment value)
        => value switch
        {
            // Explicit mapping for alignment values that require hyphens
            HorizontalItemAlignment.BaselineAlignment => "baseline alignment",

            // Default case: Simply convert to lowercase 
            // (Works for: Start, Center, End, Stretch, Baseline, Row, Column, Dense)
            _ => value.ToString().ToLower()
        };



    /// <summary>
    /// Converts a type-safe Enum value into its corresponding CSS property string.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>A string formatted for CSS inline styles.</returns>
    public static string ToCss(this VerticalItemAlignment value)
        => value switch
        {
            // Explicit mapping for alignment values that require hyphens
            VerticalItemAlignment.FlexStart => "flex-start",
            VerticalItemAlignment.FlexEnd => "flex-end",

            // Default case: Simply convert to lowercase 
            // (Works for: Start, Center, End, Stretch, Baseline, Row, Column, Dense)
            _ => value.ToString().ToLower()
        };

    /// <summary>
    /// Converts a type-safe Enum value into its corresponding CSS property string.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>A string formatted for CSS inline styles.</returns>
    public static string ToCss(this VerticalAlignment value)
        => value switch
        {
            // Explicit mapping for alignment values that require hyphens
            VerticalAlignment.FlexStart => "flex-start",
            VerticalAlignment.FlexEnd => "flex-end",
            VerticalAlignment.SpaceEvenly => "space-evenly",
            VerticalAlignment.SpaceAround => "space-around",
            VerticalAlignment.SpaceBetween => "space-between",

            // Default case: Simply convert to lowercase 
            // (Works for: Start, Center, End, Stretch, Baseline, Row, Column, Dense)
            _ => value.ToString().ToLower()
        };

    /// <summary>
    /// Converts a type-safe Enum value into its corresponding CSS property string.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>A string formatted for CSS inline styles.</returns>
    public static string ToCss(this HorizontalAlignment value)
        => value switch
        {
            // Explicit mapping for alignment values that require hyphens
            HorizontalAlignment.FlexStart => "flex-start",
            HorizontalAlignment.FlexEnd => "flex-end",
            HorizontalAlignment.SpaceEvenly => "space-evenly",
            HorizontalAlignment.SpaceAround => "space-around",
            HorizontalAlignment.SpaceBetween => "space-between",

            // Default case: Simply convert to lowercase 
            // (Works for: Start, Center, End, Stretch, Baseline, Row, Column, Dense)
            _ => value.ToString().ToLower()
        };

}
