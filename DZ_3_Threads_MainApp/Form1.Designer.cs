namespace DZ_3_Threads_MainApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			label2 = new Label();
			numericUpDownStart = new NumericUpDown();
			numericUpDownEnd = new NumericUpDown();
			bt_Start = new Button();
			richTextBoxPrimeNumbers = new RichTextBox();
			label3 = new Label();
			numericUpDownFib = new NumericUpDown();
			richTextBoxFibbonacci = new RichTextBox();
			bt_FibStart = new Button();
			bt_PrimeStop = new Button();
			bt_FibStop = new Button();
			bt_PrimePause = new Button();
			bt_FibPause = new Button();
			bt_Close = new Button();
			checkBox_Busy = new CheckBox();
			((System.ComponentModel.ISupportInitialize)numericUpDownStart).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownEnd).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownFib).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 14);
			label1.Name = "label1";
			label1.Size = new Size(107, 15);
			label1.TabIndex = 0;
			label1.Text = "Нижний диапазон";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(127, 14);
			label2.Name = "label2";
			label2.Size = new Size(236, 15);
			label2.TabIndex = 1;
			label2.Text = "Верхний диапазон поиска простых чисел";
			// 
			// numericUpDownStart
			// 
			numericUpDownStart.Location = new Point(19, 36);
			numericUpDownStart.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
			numericUpDownStart.Name = "numericUpDownStart";
			numericUpDownStart.Size = new Size(102, 23);
			numericUpDownStart.TabIndex = 2;
			numericUpDownStart.Value = new decimal(new int[] { 2, 0, 0, 0 });
			// 
			// numericUpDownEnd
			// 
			numericUpDownEnd.Location = new Point(127, 36);
			numericUpDownEnd.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
			numericUpDownEnd.Name = "numericUpDownEnd";
			numericUpDownEnd.Size = new Size(108, 23);
			numericUpDownEnd.TabIndex = 3;
			numericUpDownEnd.Value = new decimal(new int[] { 2, 0, 0, 0 });
			// 
			// bt_Start
			// 
			bt_Start.Location = new Point(241, 36);
			bt_Start.Name = "bt_Start";
			bt_Start.Size = new Size(153, 23);
			bt_Start.TabIndex = 4;
			bt_Start.Text = "Старт";
			bt_Start.UseVisualStyleBackColor = true;
			bt_Start.Click += bt_Start_Click;
			// 
			// richTextBoxPrimeNumbers
			// 
			richTextBoxPrimeNumbers.Location = new Point(12, 98);
			richTextBoxPrimeNumbers.Name = "richTextBoxPrimeNumbers";
			richTextBoxPrimeNumbers.Size = new Size(382, 288);
			richTextBoxPrimeNumbers.TabIndex = 5;
			richTextBoxPrimeNumbers.Text = "";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(409, 14);
			label3.Name = "label3";
			label3.Size = new Size(265, 15);
			label3.TabIndex = 6;
			label3.Text = "Укажите колличество членов ряда Фибоначчи";
			// 
			// numericUpDownFib
			// 
			numericUpDownFib.Location = new Point(409, 36);
			numericUpDownFib.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
			numericUpDownFib.Name = "numericUpDownFib";
			numericUpDownFib.Size = new Size(54, 23);
			numericUpDownFib.TabIndex = 7;
			numericUpDownFib.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// richTextBoxFibbonacci
			// 
			richTextBoxFibbonacci.Location = new Point(409, 65);
			richTextBoxFibbonacci.Name = "richTextBoxFibbonacci";
			richTextBoxFibbonacci.Size = new Size(411, 321);
			richTextBoxFibbonacci.TabIndex = 8;
			richTextBoxFibbonacci.Text = "";
			// 
			// bt_FibStart
			// 
			bt_FibStart.Location = new Point(469, 36);
			bt_FibStart.Name = "bt_FibStart";
			bt_FibStart.Size = new Size(93, 23);
			bt_FibStart.TabIndex = 9;
			bt_FibStart.Text = "Старт";
			bt_FibStart.UseVisualStyleBackColor = true;
			bt_FibStart.Click += button_FibStart_Click;
			// 
			// bt_PrimeStop
			// 
			bt_PrimeStop.Location = new Point(19, 69);
			bt_PrimeStop.Name = "bt_PrimeStop";
			bt_PrimeStop.Size = new Size(244, 23);
			bt_PrimeStop.TabIndex = 10;
			bt_PrimeStop.Text = "Завершить расчет простых чисел";
			bt_PrimeStop.UseVisualStyleBackColor = true;
			bt_PrimeStop.Click += bt_PrimeStop_Click;
			// 
			// bt_FibStop
			// 
			bt_FibStop.Location = new Point(568, 36);
			bt_FibStop.Name = "bt_FibStop";
			bt_FibStop.Size = new Size(131, 23);
			bt_FibStop.TabIndex = 11;
			bt_FibStop.Text = "Завершить расчет";
			bt_FibStop.UseVisualStyleBackColor = true;
			bt_FibStop.Click += bt_FibStop_Click;
			// 
			// bt_PrimePause
			// 
			bt_PrimePause.Location = new Point(269, 69);
			bt_PrimePause.Name = "bt_PrimePause";
			bt_PrimePause.Size = new Size(125, 23);
			bt_PrimePause.TabIndex = 12;
			bt_PrimePause.Text = "Пауза";
			bt_PrimePause.UseVisualStyleBackColor = true;
			bt_PrimePause.Click += bt_PrimePause_Click;
			// 
			// bt_FibPause
			// 
			bt_FibPause.Location = new Point(705, 36);
			bt_FibPause.Name = "bt_FibPause";
			bt_FibPause.Size = new Size(115, 23);
			bt_FibPause.TabIndex = 13;
			bt_FibPause.Text = "Пауза";
			bt_FibPause.UseVisualStyleBackColor = true;
			bt_FibPause.Click += bt_FibPause_Click;
			// 
			// bt_Close
			// 
			bt_Close.Location = new Point(745, 392);
			bt_Close.Name = "bt_Close";
			bt_Close.Size = new Size(75, 23);
			bt_Close.TabIndex = 14;
			bt_Close.Text = "Выход";
			bt_Close.UseVisualStyleBackColor = true;
			bt_Close.Click += bt_Close_Click;
			// 
			// checkBox_Busy
			// 
			checkBox_Busy.AutoSize = true;
			checkBox_Busy.Location = new Point(12, 395);
			checkBox_Busy.Name = "checkBox_Busy";
			checkBox_Busy.Size = new Size(301, 19);
			checkBox_Busy.TabIndex = 15;
			checkBox_Busy.Text = "Отключить искусственную задержку вычислений";
			checkBox_Busy.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(835, 423);
			Controls.Add(checkBox_Busy);
			Controls.Add(bt_Close);
			Controls.Add(bt_FibPause);
			Controls.Add(bt_PrimePause);
			Controls.Add(bt_FibStop);
			Controls.Add(bt_PrimeStop);
			Controls.Add(bt_FibStart);
			Controls.Add(richTextBoxFibbonacci);
			Controls.Add(numericUpDownFib);
			Controls.Add(label3);
			Controls.Add(richTextBoxPrimeNumbers);
			Controls.Add(bt_Start);
			Controls.Add(numericUpDownEnd);
			Controls.Add(numericUpDownStart);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Расчет простых чисел и чисел Фибоначчи в разных потоках";
			((System.ComponentModel.ISupportInitialize)numericUpDownStart).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownEnd).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownFib).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private NumericUpDown numericUpDownStart;
		private NumericUpDown numericUpDownEnd;
		private Button bt_Start;
		private RichTextBox richTextBoxPrimeNumbers;
		private Label label3;
		private NumericUpDown numericUpDownFib;
		private RichTextBox richTextBoxFibbonacci;
		private Button bt_FibStart;
		private Button bt_PrimeStop;
		private Button bt_FibStop;
		private Button bt_PrimePause;
		private Button bt_FibPause;
		private Button bt_Close;
		private CheckBox checkBox_Busy;
	}
}
