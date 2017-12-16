using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TowerDefense.Core;


namespace SimpleTowerDefense
{
	public partial class MainForm : Form
	{
		private Bitmap _mainBitmap;
		private GameCore _gameCore;

		public MainForm()
		{
			InitializeComponent();
			_gameCore = new GameCore(new Size(700, 400));
			_gameCore.RedrawEventHendler += GameCore_RedrawEventHendler;
			_gameCore.StartGame();
			_mainBitmap = new Bitmap(10, 10);
		}
		private void GameCore_RedrawEventHendler(object sender, Bitmap bitmap)
		{
			_mainBitmap = new Bitmap(bitmap);
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawImage(_mainBitmap, 0, 0);
			base.OnPaint(e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			_gameCore.AddMouseDown(new Point(e.X, e.Y), e);
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			_gameCore.AddMouseDown(new Point(e.X, e.Y), e);
			base.OnMouseUp(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			_gameCore.AddMouseDown(new Point(e.X, e.Y), e);
			base.OnMouseMove(e);
		}
		

	}
}
