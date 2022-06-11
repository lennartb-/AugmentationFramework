﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using AugmentationFramework.Generators;
using AugmentationFramework.Renderer;
using AugmentationFramework.Transformers;

namespace AugmentationFramework.Augmentations;

public static class AugmentationExtensions
{
    public static Augmentation WithBackground(this Augmentation augmentation, Brush background)
    {
        var backgroundTransformer = new BackgroundTransformer(augmentation, background);

        augmentation.AddLineTransformer(backgroundTransformer);

        return augmentation;
    }

    public static Augmentation WithForeground(this Augmentation augmentation, Brush foreground)
    {
        if (augmentation.Transformers.OfType<ForegroundTransformer>().Any())
        {
            foreach (var existingGenerator in augmentation.Transformers.OfType<ForegroundTransformer>())
            {
                existingGenerator.Foreground = foreground;
            }

            return augmentation;
        }

        var foregroundTransformer = new ForegroundTransformer(augmentation)
        {
            Foreground = foreground
        };

        augmentation.AddLineTransformer(foregroundTransformer);

        return augmentation;
    }

    public static Augmentation WithFontSize(this Augmentation augmentation, double fontSize)
    {
        if (augmentation.Transformers.OfType<ForegroundTransformer>().Any())
        {
            foreach (var existingGenerator in augmentation.Transformers.OfType<ForegroundTransformer>())
            {
                existingGenerator.FontSize = fontSize;
            }

            return augmentation;
        }

        var foregroundTransformer = new ForegroundTransformer(augmentation)
        {
            FontSize = fontSize
        };

        augmentation.AddLineTransformer(foregroundTransformer);

        return augmentation;
    }

    public static Augmentation WithFontWeight(this Augmentation augmentation, FontWeight fontWeight)
    {
        if (augmentation.Transformers.OfType<ForegroundTransformer>().Any())
        {
            foreach (var existingGenerator in augmentation.Transformers.OfType<ForegroundTransformer>())
            {
                existingGenerator.FontWeight = fontWeight;
            }

            return augmentation;
        }

        var foregroundTransformer = new ForegroundTransformer(augmentation)
        {
            FontWeight = fontWeight
        };

        augmentation.AddLineTransformer(foregroundTransformer);

        return augmentation;
    }

    public static Augmentation WithFontFamily(this Augmentation augmentation, FontFamily fontFamily)
    {
        if (augmentation.Transformers.OfType<ForegroundTransformer>().Any())
        {
            foreach (var existingGenerator in augmentation.Transformers.OfType<ForegroundTransformer>())
            {
                existingGenerator.FontFamily = fontFamily;
            }

            return augmentation;
        }

        var foregroundTransformer = new ForegroundTransformer(augmentation)
        {
            FontFamily = fontFamily
        };

        augmentation.AddLineTransformer(foregroundTransformer);

        return augmentation;
    }

    public static Augmentation WithFontStyle(this Augmentation augmentation, FontStyle fontStyle)
    {
        if (augmentation.Transformers.OfType<ForegroundTransformer>().Any())
        {
            foreach (var existingGenerator in augmentation.Transformers.OfType<ForegroundTransformer>())
            {
                existingGenerator.FontStyle = fontStyle;
            }

            return augmentation;
        }

        var foregroundTransformer = new ForegroundTransformer(augmentation)
        {
            FontStyle = fontStyle
        };

        augmentation.AddLineTransformer(foregroundTransformer);

        return augmentation;
    }

    public static Augmentation ForText(this Augmentation augmentation, string text)
    {
        augmentation.TextMatch = text;

        return augmentation;
    }

    public static Augmentation ForText(this Augmentation augmentation, Regex textMatch)
    {
        augmentation.TextMatchRegex = textMatch;

        return augmentation;
    }

    public static Augmentation ForText(this Augmentation augmentation, params Regex[] textMatch)
    {
        augmentation.TextMatchesRegex = textMatch;

        return augmentation;
    }

    public static Augmentation ForText(this Augmentation augmentation, params string[] textMatches)
    {
        augmentation.TextMatches = textMatches;

        return augmentation;
    }

    public static Augmentation WithDecoration(this Augmentation augmentation, Brush decorationColor)
    {
        var backgroundTransformer = new DecorationRenderer(augmentation, decorationColor);
        augmentation.AddBackgroundRenderer(backgroundTransformer);

        return augmentation;
    }

    public static Augmentation WithTooltip(this Augmentation augmentation, string tooltipText)
    {
        if (augmentation.Generators.OfType<OverlayGenerator>().Any())
        {
            foreach (var existingGenerator in augmentation.Generators.OfType<OverlayGenerator>())
            {
                existingGenerator.TooltipText = tooltipText;
            }

            return augmentation;
        }

        var toolTipGenerator = new OverlayGenerator(augmentation) { TooltipText = tooltipText };
        augmentation.AddElementGenerator(toolTipGenerator);

        return augmentation;
    }

    public static Augmentation WithTooltip(this Augmentation augmentation, Func<UIElement> customTooltip)
    {
        if (augmentation.Generators.OfType<OverlayGenerator>().Any())
        {
            foreach (var existingGenerator in augmentation.Generators.OfType<OverlayGenerator>())
            {
                existingGenerator.CustomTooltip = customTooltip;
            }

            return augmentation;
        }

        var toolTipGenerator = new OverlayGenerator(augmentation) { CustomTooltip = customTooltip };
        augmentation.AddElementGenerator(toolTipGenerator);

        return augmentation;
    }

    public static Augmentation WithOverlay(this Augmentation augmentation, string overlayText)
    {
        if (augmentation.Generators.OfType<OverlayGenerator>().Any())
        {
            foreach (var existingGenerator in augmentation.Generators.OfType<OverlayGenerator>())
            {
                existingGenerator.OverlayText = overlayText;
            }

            return augmentation;
        }

        var toolTipGenerator = new OverlayGenerator(augmentation) { OverlayText = overlayText };
        augmentation.AddElementGenerator(toolTipGenerator);

        return augmentation;
    }

    public static Augmentation WithOverlay(this Augmentation augmentation, Func<UIElement> overlay)
    {
        if (augmentation.Generators.OfType<OverlayGenerator>().Any())
        {
            foreach (var existingGenerator in augmentation.Generators.OfType<OverlayGenerator>())
            {
                existingGenerator.CustomOverlay = overlay;
            }

            return augmentation;
        }

        var toolTipGenerator = new OverlayGenerator(augmentation, overlay);
        augmentation.AddElementGenerator(toolTipGenerator);

        return augmentation;
    }
}
