using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Diplom2
{
	public class Simbol
	{
		public int x;
		public int y;
		public Color clr;
		public byte simnum;
		
		public Simbol()
		{
			this.x = 0;
			this.y = 0;
		}
		public Simbol (int X, int Y, Color col, int SimNum)
		{
			this.x = X;
			this.y = Y;
			this.clr = col;
			this.simnum = (byte)SimNum;
		}		
	}
	public class SimbolPos
	{
		public int x;
		public int y;
		public int symnum;
		public SimbolPos()
		{
			this.x=0;
			this.y=0;
			this.symnum=0;
		}
		public SimbolPos(int X, int Y, int SimNum)
		{
			this.x=X;
			this.y=Y;
			this.symnum=SimNum;
		}
	}
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>		
		private Simbol[] sim = new Simbol[25000];
		private Simbol[] cursim;
		private SimbolPos[] simpos;// = new SimbolPos[50000];
		int arCounter = 0;
		int cursimcounter = 0;
		int simCounter = 0;
		private System.ComponentModel.IContainer components;
		public Image	img, img2,imgMod;
		private System.Windows.Forms.Button Process;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label0;
		System.Drawing.Bitmap bmpfile = new System.Drawing.Bitmap("..\\..\\input.bmp");
		Bitmap bmpmask, simbmp;		
		
		System.Drawing.Color clr = new System.Drawing.Color();
		private System.Windows.Forms.ProgressBar progressBarConvert;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.StatusBar statusBar;
		System.Drawing.Color clrn = new System.Drawing.Color();

		public Form1() //Main Form Class
		{
			//Duoube Buffer for this form - ON
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			//
			// Required for Windows Form Designer support			
			InitializeComponent();
			initil();
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		#region Dispose
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Process = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label0 = new System.Windows.Forms.Label();
			this.progressBarConvert = new System.Windows.Forms.ProgressBar();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.statusBar = new System.Windows.Forms.StatusBar();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// Process
			// 
			this.Process.Location = new System.Drawing.Point(576, 384);
			this.Process.Name = "Process";
			this.Process.Size = new System.Drawing.Size(96, 32);
			this.Process.TabIndex = 0;
			this.Process.Text = "Convert";
			this.Process.Click += new System.EventHandler(this.Process_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(352, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 344);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			this.label1.Visible = false;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(608, 360);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
			this.numericUpDown1.TabIndex = 2;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 50,
																		 0,
																		 0,
																		 0});
			// 
			// label0
			// 
			this.label0.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.label0.Location = new System.Drawing.Point(8, 16);
			this.label0.Name = "label0";
			this.label0.Size = new System.Drawing.Size(320, 344);
			this.label0.TabIndex = 3;
			this.label0.Text = "label2";
			this.label0.Visible = false;
			// 
			// progressBarConvert
			// 
			this.progressBarConvert.Location = new System.Drawing.Point(24, 384);
			this.progressBarConvert.Name = "progressBarConvert";
			this.progressBarConvert.Size = new System.Drawing.Size(528, 23);
			this.progressBarConvert.Step = 1;
			this.progressBarConvert.TabIndex = 4;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 400);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(680, 22);
			this.statusBar.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 422);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar,
																		  this.progressBarConvert,
																		  this.label0,
																		  this.numericUpDown1,
																		  this.Process,
																		  this.label1});
			this.Menu = this.mainMenu;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main Frame";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		/// <summary>
		/// On paint procedure
		/// </summary>
		/// <param name="pe"></param>
		protected override void OnPaint(PaintEventArgs pe)
		{			
			img = Image.FromFile("..\\..\\input.bmp");
			if(img != null)	
			{
				Graphics g = pe.Graphics;
				//g.DrawImage(img,ClientRectangle);
				g.DrawImage(img,label0.Bounds);
			}		
			//imgMod = Image.FromFile("..\\..\\newmask.bmp");			
			if(imgMod != null)
			{
				Graphics g = pe.Graphics;
				g.DrawImage(imgMod,label1.Bounds);
			}
			
		}
				
		private void initil()
		{			
			MakeMask();		
		}
		private void FindSimbol()
		{			
			bmpmask = new Bitmap("..\\..\\mask.bmp");
			int clrBlack = System.Math.Abs(Color.Black.ToArgb());
			int progresstotal=bmpmask.Width*bmpmask.Height;
			progressBarConvert.Maximum=progresstotal;
			for(int i=0; i<bmpmask.Width; i++)
				for( int j=0; j<bmpmask.Height; j++)
				{
					clr = bmpmask.GetPixel(i,j);
					int origColor = System.Math.Abs(clr.ToArgb());
					if (origColor == clrBlack)
					{
						cursim = null;
						cursim = new Simbol[500];
						cursimcounter=0;						
						ProccessSimbol(i,j);
						FixSimCoord();
						//add compare simbol here
						cursim.CopyTo(sim,arCounter);						
						arCounter+=cursimcounter;
						simCounter++;															
					}					
					progressBarConvert.Increment(1);
				}
			bmpmask.Save("..\\..\\newmask.bmp");
			bmpmask.Dispose();
			SaveSimbol();
			//MessageBox.Show("Done");			
			statusBar.Text="Done";
		}	
						
		public void ProccessSimbol(int i, int j)
		{			
			CheckSimbol(i-1,j-1);// top-left
			CheckSimbol(i,j-1);// top
			CheckSimbol(i+1,j-1);// top right
			CheckSimbol(i-1,j);// center-left
			CheckSimbol(i,j);//senter
			CheckSimbol(i+1,j);// center-right
			CheckSimbol(i-1,j+1);// down-left
			CheckSimbol(i,j+1);// down
			CheckSimbol(i+1,j+1);// down-right
		}
		private void CheckSimbol(int x, int y)
		{
			if(x>0 && y>0 && x < bmpmask.Width && y < bmpmask.Height)
			{
				Color curColor = bmpmask.GetPixel(x,y);
			
				int clrBlack = System.Math.Abs(Color.Black.ToArgb());
				int origColor = System.Math.Abs(curColor.ToArgb());
				if(origColor == clrBlack)
				{				
					cursim[cursimcounter] = new Simbol(x,y,Color.Green, simCounter);
					bmpmask.SetPixel(x,y,Color.Red);
					cursimcounter++;
					ProccessSimbol(x,y);
				}
			}
		}
		public void FixSimCoord()
		{
			int minX=0,minY=0,maxX=0,maxY=0;			
			for(int k=0;k<cursimcounter;k++)
			{
				if(minX==0 && minY==0 && maxX==0 && maxY==0)
				{
					minX = cursim[k].x; maxX = cursim[k].x;
					minY = cursim[k].y; maxY = cursim[k].y;
				}
				if(cursim[k].x>maxX) maxX = cursim[k].x;
				if(cursim[k].x<minX) minX = cursim[k].x;
				if(cursim[k].y>maxY) maxY = cursim[k].y;
				if(cursim[k].y<minY) minY = cursim[k].y;
			}
			//Adjust Coordinates
			for(int k=0;k<cursimcounter;k++)
			{
				cursim[k].x-=(minX);
				cursim[k].y-=(minY);
			}
			//simpos = new SimbolPos(minX,maxY, cursimcounter);
			IEnumerator myEnumerator = simpos.GetEnumerator();
		}		

		public void SaveSimbol()
		{
			for(int s=0; s<simCounter; s++)
			{
				int ImgSize = 20;
				simbmp = new Bitmap(ImgSize,ImgSize);
										
				for(int k=0;k<arCounter;k++)
				{
					if(sim[k].simnum==s && sim[k] != null)
					{
						simbmp.SetPixel(sim[k].x,sim[k].y,Color.Blue);
					}
				}

				string fname = s.ToString();
				if(fname.Length==1)
					fname = String.Format("0{0}",fname);
								
				string pathname = String.Format("..\\..\\Simbols\\{0}sim.png",fname);
				simbmp.Save(pathname,ImageFormat.Png);
				simbmp.Dispose();
			}
		}

		private void MakeMask()
		{
			for(int i = 0; i < bmpfile.Width; i++)
				for(int j = 0; j < bmpfile.Height; j++)
				{
					clr = bmpfile.GetPixel(i,j);
					int origColor = System.Math.Abs(clr.ToArgb());
					int clrBlack = System.Math.Abs(Color.Black.ToArgb());
					int clrLGray = System.Math.Abs(Color.LightGray.ToArgb());
					if (origColor <= clrBlack &&
						origColor >= clrLGray)
					{
						bmpfile.SetPixel(i,j,Color.Black);
					}
					else
					{
						bmpfile.SetPixel(i,j,Color.White);
					}
				}
			bmpfile.Save("..\\..\\mask.bmp",ImageFormat.Bmp);
			bmpfile.Dispose();
			statusBar.Text="File Loaded";
		}
		
		
		private void Process_Click(object sender, System.EventArgs e)
		{
			statusBar.Text="Converting...";
			FindSimbol();			
			Invalidate();			
		}
	}
}
