using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp
{
    internal class Quiz
    {
        private Question[] _questions;
        private int _correctScore;
        private int _wrongScore;
        private double _percentualCorrectAnswer;
        private double _percentualIncorrectAnswer;
        public Quiz(Question[] questions)
        {
            this._questions = questions;
            _correctScore = 0;
            _wrongScore = 0;
            _percentualCorrectAnswer = 0;
            _percentualIncorrectAnswer = 0;
        }
        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the quiz");
            int questionNumber = 1; //to display question number
            foreach (Question question in _questions)
            {
                Console.WriteLine($"Question {questionNumber++}: ");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();
                if (question.IsCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Is Correct!");
                    _correctScore++;
                }
                else {
                    Console.WriteLine($"Wrong! The correct answer was: {question.Answers[question.CorrectAnswerIndex]}");
                    _wrongScore++;
                }
            }
            _percentualCorrectAnswer = (_correctScore*100)/_questions.Length;
            _percentualIncorrectAnswer = (_wrongScore*100)/_questions.Length;
            DisplayResults(_correctScore,_wrongScore, _percentualCorrectAnswer, _percentualIncorrectAnswer);
        }

        public void DisplayResults(int _correctScore, int _wrongScore, double _percentualCorrectAnswer, double _percentualIncorrectAnswer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Results                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"Well, the quiz is finish. Your result is: {_correctScore} ({_percentualCorrectAnswer}%) correct and {_wrongScore} ({_percentualIncorrectAnswer}%) incorrect!");
            if (_percentualCorrectAnswer >= 75)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Excelent Work!");
            }
            else if (_percentualCorrectAnswer >= 51) {
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("Not bad!");
            }else if(_percentualCorrectAnswer <= 50)
            {
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("Keep practicing!");
            }
        }

        private void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine(question.QuestionText);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("    ");
                Console.Write(i + 1 +". ");
                Console.ResetColor();
                Console.WriteLine(question.Answers[i]);
            }
        }

        private int GetUserChoice()
        {
            Console.Write("Your answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice. please enter a number between 1 and 5: ");
                input = Console.ReadLine() ;
            }
            return choice - 1;
        }
    }
}
