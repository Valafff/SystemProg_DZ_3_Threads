//#define PrimeNumbers
//#define FibonachiNumbers
//#define CancellationTokenSource
#define ManualResetEvent

#if PrimeNumbers
uint startValue = 2, endValue = uint.MaxValue;
List<uint> PrimeNumbers = new List<uint>();


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

do
{
	var t = Convert.ToUInt32(Console.ReadLine());
	Console.WriteLine(IsPrimeNumber(t));

} while (true);

//Console.WriteLine(startValue);
//Console.WriteLine(endValue);
#endif

#if FibonachiNumbers

Console.WriteLine("До какого числа считать ряд Фибоначчи?");
int number = Convert.ToInt32(Console.ReadLine());

int first = 1;
int second = 1;
// Выводим первые два числа ряда
Console.Write($"{first} {second}");

while (number >= first + second)
{
	int sum = first + second;
	Console.Write($" {sum}");
	first = second;
	second = sum;
}

//Console.WriteLine(); // Переход на новую строку

#endif

#if CancellationTokenSource
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
	static async Task Main()
	{
		var cancellationTokenSource = new CancellationTokenSource();
		var cancellationToken = cancellationTokenSource.Token;

		var task = Task.Run(() =>
		{

			// Ваш код внутри задачи
			// ...
			Thread.Sleep(10000);
			// Проверка отмены
			if (cancellationToken.IsCancellationRequested)
			{
				// Выход из задачи
				return;
			}

			// Продолжение выполнения
			// ...
		}, cancellationToken);

		// Отмена задачи через 5 секунд (пример)
		await Task.Delay(5000);
		cancellationTokenSource.Cancel();

		try
		{
			await task; // Дождитесь завершения задачи
		}
		catch (OperationCanceledException)
		{
			// Обработка отмены
			Console.WriteLine("Задача была отменена.");
		}
	}
}
#endif

#if ManualResetEvent

using System;
using System.Threading;

public class Example
{
	// mre is used to block and release threads manually. It is
	// created in the unsignaled state.
	private static ManualResetEvent mre = new ManualResetEvent(false);

	static void Main()
	{
		Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

		for (int i = 0; i <= 2; i++)
		{
			Thread t = new Thread(ThreadProc);
			t.Name = "Thread_" + i;
			t.Start();
		}

		Thread.Sleep(500);
		Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
						  "\nto release all the threads.\n");
		Console.ReadLine();

		mre.Set();

		Thread.Sleep(500);
		Console.WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
						  "\ndo not block. Press Enter to show this.\n");
		Console.ReadLine();

		for (int i = 3; i <= 4; i++)
		{
			Thread t = new Thread(ThreadProc);
			t.Name = "Thread_" + i;
			t.Start();
		}

		Thread.Sleep(500);
		Console.WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
						  "\nwhen they call WaitOne().\n");
		Console.ReadLine();

		mre.Reset();

		// Start a thread that waits on the ManualResetEvent.
		Thread t5 = new Thread(ThreadProc);
		t5.Name = "Thread_5";
		t5.Start();

		Thread.Sleep(500);
		Console.WriteLine("\nPress Enter to call Set() and conclude the demo.");
		Console.ReadLine();

		mre.Set();

		// If you run this example in Visual Studio, uncomment the following line:
		//Console.ReadLine();
	}

	private static void ThreadProc()
	{
		string name = Thread.CurrentThread.Name;

		Console.WriteLine(name + " starts and calls mre.WaitOne()");

		mre.WaitOne();

		Console.WriteLine(name + " ends.");
	}
}


#endif

