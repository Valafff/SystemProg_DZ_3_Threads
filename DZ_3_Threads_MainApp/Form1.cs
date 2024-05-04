using System;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_3_Threads_MainApp
{
	public partial class Form1 : Form
	{
		public CancellationTokenSource PrimeCancellationTokenSource;
		public CancellationToken PrimeCancellationToken;

		bool PrimeFlag = false;
		bool FibFlag = false;

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
			Console.WriteLine(_number);
			return true;
		}

		//Нахождение массива простых чисел
		List<uint> CalculatePrime()
		{
			List<uint> result = new List<uint>();
			while (startValue <= endValue && !PrimeFlag)
			{
				if (IsPrimeNumber(startValue))
				{
					result.Add(startValue);
				}
				startValue++;
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
			return _number1 + _number2;
		}

		List<UInt128> GetFibbArray()
		{
			List<UInt128> TempFibbNumbers = new List<UInt128>();
			int count = (int)numericUpDownFib.Value;
			TempFibbNumbers.Add(first);
			TempFibbNumbers.Add(second);

			while (count > 2 && !FibFlag)
			{
				UInt128 num1 = TempFibbNumbers[TempFibbNumbers.Count - 2];
				UInt128 num2 = TempFibbNumbers[TempFibbNumbers.Count - 1];
				var t = GetThirdNumber(num1, num2);
				TempFibbNumbers.Add(t);
				count--;
                Console.WriteLine(t);
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
				foreach (uint number in result)
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
			var cancellationTokenSource = new CancellationTokenSource();
			var cancellationToken = cancellationTokenSource.Token;
			PrimeCancellationTokenSource = cancellationTokenSource;
			PrimeCancellationToken = cancellationToken;
			startValue = (uint)numericUpDownStart.Value;
			endValue = (uint)numericUpDownEnd.Value;
			PrimeNumbers.Clear();
			bt_Start.Enabled = false;

			Task primeTask = Task.Run(() =>
			{
				DoWorkPrime();
				//if (PrimeCancellationToken.IsCancellationRequested)
				//{
				//	// Выход из задачи
				//	return;
				//}
				PrimeCancellationTokenSource.Token.ThrowIfCancellationRequested();

			}, PrimeCancellationTokenSource.Token);

			//PrimeCancellationTokenSource.Cancel();
		}

		private void button_FibStart_Click(object sender, EventArgs e)
		{
			Thread fibThread = new Thread(DoWorkFib);
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
	}
}
