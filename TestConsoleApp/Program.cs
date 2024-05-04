//#define PrimeNumbers
//#define FibonachiNumbers

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
