using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace shape_lab9
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            // Flicker буюу анивчихыг багасгах
            this.DoubleBuffered = true;

            // Event холболтууд
            this.MouseClick += new MouseEventHandler(this.Form1_MouseClick);
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
            this.KeyPreview = true;
        }

        // 1. Алдааг арилгах зорилгоор нэмсэн Load функц
        private void Form1_Load(object sender, EventArgs e)
        {
            // Форм ачаалагдах үед хийх зүйлс (одоохондоо хоосон байж болно)
        }

        private void Form1_MouseClick(object? sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            this.Invalidate();
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            // 'R' товч дарвал цэгүүдийг цэвэрлэнэ
            if (e.KeyCode == Keys.R)
            {
                points.Clear();
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Black, 2);
            Brush brush = Brushes.Red;

            int pointRadius = 4;

            // Цэгүүдийг шугамаар холбох
            if (points.Count > 1)
            {
                e.Graphics.DrawLines(pen, points.ToArray());
            }

            // Цэг бүрийг улаанаар зурах
            foreach (var pt in points)
            {
                e.Graphics.FillEllipse(
                    brush,
                    pt.X - pointRadius,
                    pt.Y - pointRadius,
                    pointRadius * 2,
                    pointRadius * 2
                );
            }

            pen.Dispose();
        }
    }
}