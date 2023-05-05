using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GOTODON
{
    public sealed class UIBuilder
    {
        public TextBox InitItemTextBox(string message, string style, Thickness margin, VerticalAlignment verticalAlignment = VerticalAlignment.Top, double width = 200, bool wrapping = true, bool multiline = true)
        {
            TextBox textbox = new TextBox();

            textbox.TextWrapping = wrapping == true ? TextWrapping.Wrap : TextWrapping.NoWrap;
            textbox.AcceptsReturn = multiline;
            textbox.SetResourceReference(Control.StyleProperty, style);
            textbox.Margin = margin;
            textbox.Width = width;
            textbox.MinHeight = 45;
            textbox.VerticalAlignment = verticalAlignment;
            textbox.IsReadOnly = true;
            textbox.Background = null;
            textbox.BorderBrush = null;

            textbox.Text = message;

            return textbox;
        }

        public Button InitIconButton(string style, PackIconKind icon, string foreground, VerticalAlignment verticalAlignment, double size = 24, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Right)
        {
            Button btn = new Button();

            PackIcon packIcon = new PackIcon();
            packIcon.Kind = icon;

            btn.SetResourceReference(Control.StyleProperty, style);
            btn.Width = size;
            btn.Height = size;
            btn.HorizontalAlignment = horizontalAlignment;
            btn.VerticalAlignment = verticalAlignment;
            btn.Foreground = GetColorFromHEX(foreground);
            btn.Content = packIcon;

            return btn;
        }

        public Brush GetColorFromHEX(string hex) => (Brush)new BrushConverter().ConvertFrom(hex);

    }
}
