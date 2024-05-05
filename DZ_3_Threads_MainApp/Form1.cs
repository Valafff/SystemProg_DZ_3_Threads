using System;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_3_Threads_MainApp
{
	public partial class Form1 : Form
	{
		//public CancellationTokenSource PrimeCancellationTokenSource;
		//public CancellationToken PrimeCancellationToken;

		ManualResetEvent ManualResetEventPrime = new ManualResetEvent(true);
		ManualResetEvent ManualResetEventFib = new ManualResetEvent(true);

		bool PrimeFlag = false;
		bool FibFlag = false;
		bool PrimePauseFlag = false;
		bool FibPauseFlag = false;

		uint startValue, endValue;
		List<uint> PrimeNumbers = new List<uint>();

		UInt128 first = 1;
		UInt128 second = 1;
		List<UInt128> FibbNumbers = new List<UInt128>();

		Task PrimeTaskRef;
		Task FibbTaskRef;

		public Form1()
		{


			InitializeComponent();
			numericUpDownStart.Maximum = UInt32.MaxValue;
			numericUpDownStart.Minimum = 2;
			numericUpDownStart.Value = 2;

			numericUpDownEnd.Maximum = UInt32.MaxValue;
			numericUpDownEnd.Minimum = 2;
			numericUpDownEnd.Value = UInt32.MaxValue;

		}

		//Простые числа
		//Метод определения простого числа
		bool IsPrimeNumber(uint _number)
		{
			if (_number > 1)
			{
				for (uint i = 2; i < _number; i++)
				{
					if (_number % i == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		//Нахождение массива простых чисел
		List<uint> CalculatePrime()
		{
			List<uint> result = new List<uint>();
			while (startValue <= endValue && !PrimeFlag)
			{
				//Приостанавливает выполнение расчета
				ManualResetEventPrime.WaitOne();
				if (IsPrimeNumber(startValue))
				{
					result.Add(startValue);
					Console.WriteLine(startValue);
				}
				startValue++;
				//Искуственное замедление расчета последовательности
				if (!checkBox_Busy.Checked) { Thread.Sleep(50); }
			}
			return result;
		}

		//Метод безопасного обновления элементов интерфейса юзера
		private void UpdateUI(List<uint> result)
		{
			// Обновляем элементы управления на форме
			if (InvokeRequired)
			{
				// Используем метод BeginInvoke для безопасного обновления UI
				BeginInvoke(new Action<List<uint>>(UpdateUI), result);
			}
			else
			{
				// Обновляем текст на richTextBoxPrimeNumbers
				richTextBoxPrimeNumbers.Clear();
				foreach (uint number in result)
				{
					richTextBoxPrimeNumbers.AppendText($"{number} ");
				}
				bt_Start.Enabled = true;
				PrimeFlag = false;
			}
		}

		//Обертка  CalculatePrime и UpdateUI для запуска в одном потоке
		void DoWorkPrime()
		{
			List<uint> res = CalculatePrime();
			UpdateUI(res);
		}
		//Простые числа

		//Ряд Фибоначчи
		//Определение последующего члена
		UInt128 GetThirdNumber(UInt128 _number1, UInt128 _number2)
		{
			try
			{
				checked
				{
					return _number1 + _number2;
				}
			}
			catch (Exception)
			{
				MessageBox.Show($"Арифметическое переполнение на {FibbNumbers.Count}м члене!");
				return 0;
			}

		}

		List<UInt128> GetFibbArray()
		{
			List<UInt128> TempFibbNumbers = new List<UInt128>();
			int count = (int)numericUpDownFib.Value;
			TempFibbNumbers.Add(first);
			TempFibbNumbers.Add(second);

			while (count > 2 && !FibFlag)
			{
				ManualResetEventFib.WaitOne();
				UInt128 num1 = TempFibbNumbers[TempFibbNumbers.Count - 2];
				UInt128 num2 = TempFibbNumbers[TempFibbNumbers.Count - 1];
				var t = GetThirdNumber(num1, num2);
				if (t != 0)
				{
					TempFibbNumbers.Add(t);
					FibbNumbers = TempFibbNumbers;
					count--;
					Console.WriteLine(t);
					//Искуственное замедление расчета последовательности
					if (!checkBox_Busy.Checked) { Thread.Sleep(50); }
				}
				else { return TempFibbNumbers; }


			}
			return TempFibbNumbers;
		}

		private void UpdateUIFib(List<UInt128> result)
		{
			// Обновляем элементы управления на форме
			if (InvokeRequired)
			{
				// Используем метод BeginInvoke для безопасного обновления UI
				BeginInvoke(new Action<List<UInt128>>(UpdateUIFib), result);
			}
			else
			{
				// Обновляем текст на richTextBoxPrimeNumbers
				richTextBoxFibbonacci.Clear();
				foreach (UInt128 number in result)
				{
					richTextBoxFibbonacci.AppendText($"{number} ");
				}
				bt_FibStart.Enabled = true;
				FibFlag = false;
			}
		}

		void DoWorkFib()
		{
			List<UInt128> res = GetFibbArray();
			UpdateUIFib(res);
		}

		//Ряд Фибоначчи
		private async void bt_Start_Click(object sender, EventArgs e)
		{
			startValue = (uint)numericUpDownStart.Value;
			endValue = (uint)numericUpDownEnd.Value;
			PrimeNumbers.Clear();
			bt_Start.Enabled = false;

			//Task primeTask = Task.Run(() =>
			//{
			//	DoWorkPrime();
			//});
			Thread primeTask = new Thread(DoWorkPrime);
			primeTask.IsBackground = true;
			primeTask.Start();
		}

		private void button_FibStart_Click(object sender, EventArgs e)
		{
			bt_FibStart.Enabled = false;
			Thread fibThread = new Thread(DoWorkFib);
			fibThread.IsBackground = true;
			fibThread.Start();
		}

		private void bt_PrimeStop_Click(object sender, EventArgs e)
		{
			PrimeFlag = true;
			//PrimeCancellationTokenSource.Cancel();
		}

		private void bt_FibStop_Click(object sender, EventArgs e)
		{
			FibFlag = true;
		}

		private void bt_PrimePause_Click(object sender, EventArgs e)
		{
			if (!PrimePauseFlag)
			{
				ManualResetEventPrime.Reset();
				PrimePauseFlag = true;
				bt_PrimePause.Text = "Продолжить";
				bt_PrimeStop.Enabled = false;
			}
			else
			{
				ManualResetEventPrime.Set();
				PrimePauseFlag = false;
				bt_PrimePause.Text = "Пауза";
				bt_PrimeStop.Enabled = true;
			}

		}

		private void bt_FibPause_Click(object sender, EventArgs e)
		{
			if (!FibPauseFlag)
			{
				ManualResetEventFib.Reset();
				FibPauseFlag = true;
				bt_FibPause.Text = "Продолжить";
				bt_FibStop.Enabled = false;
			}
			else
			{
				ManualResetEventFib.Set();
				FibPauseFlag = false;
				bt_FibPause.Text = "Пауза";
				bt_FibStop.Enabled = true;
			}
		}

		private void bt_Close_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
