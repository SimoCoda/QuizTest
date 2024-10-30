namespace MyQuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question(
                    "What is the capital of Germany?", //questions
                    new string[] {"Milan","Paris", "Berlin", "Tokyo", "Budapest" }, //answer
                    2 //correct answer
                ),
                new Question(
                     "What color is Napoleon's white horse?",
                    new string[] {"Red","Black", "Green", "Grey", "White" },
                    4
                ),new Question(
                     "What is 2+2?",
                    new string[] {"1","4", "3", "5", "2" },
                    1
                ),new Question(
                     "Which car is the most powerful?",
                    new string[] {"Audi a3", "Bmw 1 series", "Ferrari portofino", "Atoz", "Opel corsa" },
                    2
                ),new Question(
                     "What is the capital of Italy?",
                    new string[] {"Rome", "Milan", "Udine", "Trieste", "Florence" },
                    0
                ),new Question(
                     "Who wrote the \"divine comedy\"?",
                    new string[] {"Giovanni Boccaccio", "Francesco Petrarca", "Dante Alighieri", "Gemma Donati", "Niccolò Machiavelli" },
                    2
                ),new Question(
                     "Who painted \"The Great Wave off Kanagawa\"?",
                    new string[] {"Van Gogh", "Claude Monet", "Niccolò Machiavelli", "Leonardo da Vinci", "Katsushika Hokusai" },
                    4
                ),
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
            
            Console.ReadLine();
        }
    }
}
