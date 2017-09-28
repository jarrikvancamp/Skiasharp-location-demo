using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace App1 {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
			tables = new List<Table> {
				new Table {
					X= 100,
					Y=100,
					Width=300,
					Height= 120,
					Name="tab"
				},
				new Table {
					X= 500,
					Y=100,
					Width=300,
					Height= 120,
					Name="tab2"
				},
				new Table {
					X= 650,
					Y=100,
					Width=300,
					Height= 120,
					Name="tab3"
				},
				new Table {
					X= 100,
					Y=850,
					Width=300,
					Height= 120,
					Name="tab4"
				},
			}; ;

		}
		List<Table> tables;
		SKImageInfo info;
		SKSurface surface;
		SKCanvas canvas;

		private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args) {

			info = args.Info;
			surface = args.Surface;
			canvas = surface.Canvas;
			canvas.Clear();

			SKPaint paint = new SKPaint {
				Color = SKColors.Black,
				StrokeWidth = 5,
				StrokeCap = SKStrokeCap.Round,
				TextSize = 60
			};

			foreach(var tab in tables) {
				var rect = SKRect.Create(tab.X, tab.Y, tab.Width, tab.Height);

				canvas.DrawRect(rect, paint);
			}
		}


		private void SKCanvasView_Touch(object sender, SKTouchEventArgs e) {
			var a = sender;
			var args = e;
			Debug.WriteLine($"--------Clicked on {args.Location.X},{args.Location.Y}-----------");
			//rect starts on 100,100 to 400,220

			foreach(var tab in tables) {
				if((args.Location.X >= tab.X && args.Location.X <= tab.X + tab.Width) && (args.Location.Y >= tab.Y && args.Location.Y <= tab.Y + tab.Height)) {
					Debug.WriteLine($"clicked inside {tab.Name}");
				}
			}

		}

	}

	public class Table {
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public string Name { get; set; }
	}
}
