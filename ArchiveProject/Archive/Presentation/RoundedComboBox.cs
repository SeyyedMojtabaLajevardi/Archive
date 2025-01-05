using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedComboBox : ComboBox
{
    public int CornerRadius { get; set; } = 40; // Default corner radius

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Set up graphics for anti-aliasing
        Graphics graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Create a rounded rectangle path
        GraphicsPath path = new GraphicsPath();
        Rectangle rect = new Rectangle(0, 0, Width, Height);
        path.AddArc(rect.X, rect.Y, CornerRadius, CornerRadius, 180, 90);
        path.AddArc(rect.X + rect.Width - CornerRadius, rect.Y, CornerRadius, CornerRadius, 270, 90);
        path.AddArc(rect.X + rect.Width - CornerRadius, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
        path.AddArc(rect.X, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
        path.CloseFigure();

        // Fill the background with a solid color or gradient
        using (Brush brush = new LinearGradientBrush(rect, Color.LightBlue, Color.DarkBlue, LinearGradientMode.Vertical))
        {
            graphics.FillPath(brush, path);
        }

        // Draw the border
        using (Pen pen = new Pen(Color.Black))
        {
            graphics.DrawPath(pen, path);
        }

        // Draw text (optional)
        TextRenderer.DrawText(graphics, this.Text, this.Font, new Point(5, (Height - this.Font.Height) / 2), this.ForeColor);
    }
}