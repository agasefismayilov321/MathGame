using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MathGame
{
    public class Game
    {
        private string _operation;
        private int _score;
        private int _totalQuestions = 5;
        private Random _random = new Random();
        private Stopwatch _time = new Stopwatch();

        public Game(string operation)
        {
            _operation = operation;
        }

        public GameResult PlayGame()
        {
            _time.Start();

            for(int i=1; i <= _totalQuestions; i++)
            {
                AskQuestion();
            }

            _time.Stop();

            return new GameResult
            {
                gameTime = DateTime.Now,
                score = _score,
                operation = _operation,
                totalQuestion = _totalQuestions,
                timeSpent = _time.Elapsed.TotalSeconds
            };
        }

        private void AskQuestion()
        {
            int number1 = 0;
            int number2 = 0;
            int correctAnswer = 0;

            switch (_operation)
            {
                case "toplama":
                    number1 = _random.Next(0,101);
                    number2 = _random.Next(0,101);
                    correctAnswer = number1 + number2;
                    Console.WriteLine($"{number1} + {number2} = ?");
                    break;
                case "cixma":
                    number1 = _random.Next(0,101);
                    number2 = _random.Next(0,101);
                    correctAnswer = number1 - number2;
                    Console.WriteLine($"{number1} - {number2} = ?");
                    break;
                case "vurma":
                    number1 = _random.Next(0,13);
                    number2 = _random.Next(0,13);
                    correctAnswer = number1 * number2;
                    Console.WriteLine($"{number1} x {number2} = ?");
                    break;
                case "bolme":
                    number2 = _random.Next(1,13);
                    correctAnswer = _random.Next(0,13);
                    number1 = number2 * correctAnswer;
                    Console.WriteLine($"{number1} / {number2} = ?");
                    break;
            }

            Console.Write("Sənin cavabın: ");
            string input = Console.ReadLine()!;

            if(int.TryParse(input, out int cavab))
            {
                if(cavab == correctAnswer)
                {
                    Console.WriteLine("Cavab doğrudur.");
                    _score++;
                }
                else
                {
                    Console.WriteLine($"Cavab yanlışdır. Doğru cavab {correctAnswer}'dır.");
                }
            }
            
            else
            {
                Console.WriteLine($"Yanlış dəyər daxil etmisiniz! Düzgün dəyər {correctAnswer}'dır.");
            }
        }
    }
}