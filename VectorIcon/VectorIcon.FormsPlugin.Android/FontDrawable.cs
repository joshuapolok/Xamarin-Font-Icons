using System.Linq;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Graphics;
using Android.Util;

namespace VectorIcon.FormsPlugin.Android
{
    public class FontDrawable : Drawable
    {
        private int alpha = 255;
        private int size;
        private string text;
        private readonly TextPaint paint = new TextPaint();

        public override int Opacity => alpha;

        public FontDrawable(Context context, string text, Color iconColor, int iconSizeDP, string font)
        {
            this.text = text;
            if (font == null || font.Length <= 0)
            {
                font = "fontawesome.ttf";
            }

            paint.SetTypeface(Typeface.CreateFromAsset(context.Assets, font));
            paint.SetStyle(Paint.Style.Fill);
            paint.TextAlign = Paint.Align.Center;
            paint.Color = iconColor;
            paint.AntiAlias = true;
            size = GetPX(context, iconSizeDP);
            SetBounds(0, 0, size, size);
        }

        public override void Draw(Canvas canvas)
        {
            paint.TextSize = Bounds.Height();
            var textBounds = new Rect();
            paint.GetTextBounds(text, 0, 1, textBounds);
            var textHeight = textBounds.Height();
            var textBottom = Bounds.Top + (paint.TextSize - textHeight) / 2f + textHeight - textBounds.Bottom;
            canvas.DrawText(text, Bounds.ExactCenterX(), textBottom, paint);
        }

        private static int GetPX(Context context, int sizeDP)
        {
            return (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, sizeDP, context.Resources.DisplayMetrics);
        }

        public override void SetAlpha(int alpha)
        {
            this.alpha = alpha;
            paint.Alpha = alpha;
        }

        public override void SetColorFilter(ColorFilter colorFilter)
        {
            paint.SetColorFilter(colorFilter);
        }
    }
}