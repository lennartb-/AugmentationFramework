using System.Collections.Generic;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Windows.Media;
using AugmentationFramework.AdviceDisplay;
using AugmentationFramework.Augmentations;
using AugmentationFramework.Renderer.Premade;
using ICSharpCode.AvalonEdit.Document;
using ReactiveUI;
using RoslynPad.Editor;

namespace AugmentationSampleEditor.ViewModels;

public class AdviceVm : ISampleContent
{
    private const string Text = @"var hashedString = HashingAlgorithms.HashWithSha1(""Lorem ipsum dolor sit amet"")";
    private readonly IList<Augmentation> augmentations = new List<Augmentation>();
    private bool isEnabled;

    public AdviceVm()
    {
        var stringTextSource = new StringTextSource(Text);
        Document = new TextDocument(stringTextSource);
        EditorLoadedCommand = ReactiveCommand.Create<CodeTextEditor>(OnLoaded);
    }

    public ReactiveCommand<CodeTextEditor, Unit> EditorLoadedCommand { get; }
    public TextDocument Document { get; }

    public bool IsEnabled
    {
        get => isEnabled;
        set
        {
            isEnabled = value;
            if (isEnabled)
            {
                foreach (var augmentation in augmentations) augmentation.Enable();
            }
            else
            {
                foreach (var augmentation in augmentations) augmentation.Disable();
            }
        }
    }

    public string Title => "Security Advice";

    private void OnLoaded(CodeTextEditor editor)
    {
        var underlineAugmentation = new Augmentation(editor.TextArea.TextView)
            .WithDecorationColor(Brushes.Red)
            .WithDecoration(UnderlineBracket.Geometry)
            .WithAdviceOverlay(new SampleAdviceModel())
            .ForText(new Regex(@"\.HashWithSha1(.*)?\)"));

        augmentations.Add(underlineAugmentation);
    }
}
