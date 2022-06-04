﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace RoslynPadTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IList<Augmentation> plugins = new List<Augmentation>();

    public MainWindow()
    {
        InitializeComponent();
        var backgroundAugmentation = new Augmentation(Editor.TextArea.TextView);
        backgroundAugmentation.WithBackground(Brushes.HotPink);
        backgroundAugmentation.ForTextMatch(new Regex(@"\bsit\b"));
        plugins.Add(backgroundAugmentation);

        var underlineAugmentation = new Augmentation(Editor.TextArea.TextView);
        underlineAugmentation.WithDecoration(Brushes.Blue);
        underlineAugmentation.ForTextMatch(new Regex(@"\btristique\b"));
        plugins.Add(underlineAugmentation);
    }

    private void OnOverlayChecked(object sender, RoutedEventArgs e)
    {
        foreach (var augmentation in plugins)
        {
            augmentation.Enable();
        }
    }

    private void OnOverlayUnchecked(object sender, RoutedEventArgs e)
    {
        foreach (var augmentation in plugins)
        {
            augmentation.Disable();
        }
    }
}
