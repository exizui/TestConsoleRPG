using System.Runtime.CompilerServices;
using System.Text;

namespace Test2024
{
    abstract class Locations
    {
        public abstract void PrintLocation();
        public abstract void ReturnToTheShelter();
    }

    class Shelter : Locations
    {
        public override void PrintLocation()
        {
            Console.WriteLine("Ти в притулку!");
        }

        public override void ReturnToTheShelter()
        {
            Console.WriteLine("Ти вже в притулку!");
        }
    }

    class Dungeon : Locations
    {
        public override void PrintLocation()
        {
            Console.WriteLine("Ти в підземкі!");
        }
        public override void ReturnToTheShelter()
        {
            Console.WriteLine("Повернення до притулку");
        }
    }
    class Forest : Locations
    {
        public override void PrintLocation()
        {
            Console.WriteLine("Ти в лісі!");
        }
        public override void ReturnToTheShelter()
        {
            Console.WriteLine("Повернення до притулку");
        }
    }
    class Question
    {
        private string a1 = "І мені також!", a2 = "AAAAAAAAAAAAAA";
        private string reply1 = "Давай!", reply2 = "НЄЄЄЄЄЄЄЄЄ";
        private string responce1 = "Давай почнем гру!", responce2 = "Ем...давай грати?";
        private string[] work = { "Похід до підземелля", "Похід в ліс", "Повернення до притулку" };
     
        
        public void CheckAnswer()
        {
            WriteChoiceAnswer(a1, a2);

            int a = int.Parse(Console.ReadLine());

            WriteProgramResponse(responce1, responce2, a);

            WriteChoiceAnswer(reply1, reply2);

            int defaultPerly = int.Parse(Console.ReadLine());

            if (defaultPerly == 1 || defaultPerly == 2) Console.WriteLine("По тобі сразу видно що хочеш!");

            WriteLine();
            ChoiceActions();
        }
        public void ChoiceActions()
        {
            Console.WriteLine("Ти знаходишься в притулку де є вогнище та ліжко, в ньому ти можешь відновити хп");
            Program.RedLine();
            WriteChoiceActions();
            int i = int.Parse(Console.ReadLine());

            Locations[] locations = new Locations[] { new Dungeon(), new Forest(), new Shelter(),};
            Locations local = null;
            
            switch (i)
            {

                case 1:
                    //locations[0].PrintLocation();
                    local = new Dungeon();
                    break;
                case 2:
                    //locations[1].PrintLocation();
                    local = new Forest();
                    break;
                case 3:
                    Console.WriteLine("Ти й так в притулку!");
                    Thread.Sleep(1000);
                    WriteChoiceActions();
                    break;
                default:
                    Console.WriteLine("Невірна цифра!");
                    break;
            }
            local.PrintLocation();

        }
        private void WriteChoiceActions()
        {
            Console.WriteLine("Виберіть варіант дії");
            Console.WriteLine($"\n1:{work[0]}\n2:{work[1]}\n3:{work[2]}\n");
        }
        private void Write(string o)
        {
            foreach(char c in o)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
        }
        private void WriteLine()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=");     
            }
            Console.WriteLine("\n");
        }
        private void WriteChoiceAnswer(string answer1, string answer2)
        {
            Console.WriteLine($"\n1:{answer1}\n2:{answer2}\n");
        }
        private void WriteProgramResponse(string reply1, string reply2, int answerNumber)
        {
            if(answerNumber == 1) Console.WriteLine(reply1);
            if(answerNumber == 2) Console.WriteLine(reply2);
        }
    }
    class Player
    {
        private string _name;
        public string Name
        {
            get { return !string.IsNullOrEmpty(_name) ? _name : null; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                    Console.WriteLine($"Приємно познайомитися {_name}!");
                    Question question = new Question();
                    question.CheckAnswer();
                }
                else
                {
                    Console.WriteLine("Повторіть спробу");
                }
            }

        }
        public int _hp { get; private set; } = 100;   
        public void MinusHp(int hp)
        {
            _hp -= hp;
            Console.WriteLine("Здоров'я лишилося: " + _hp);
        }
        public void HillingHp()
        {
            _hp = 100;
            Console.WriteLine("Здоров'я відновлено!");
        }
    }
    
  
    class Program
    {      
       
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Ласкаво просимо в цей дивний консольний світ C#!");
            RedLine();         
            Console.WriteLine("Як тебе звати?");
            string playerName = Console.ReadLine();
            Player player = new();
            player.Name = playerName;
            Locations iloc = new Shelter();
        }       
        public static void RedLine()
        {
            Console.WriteLine("\nНатисни Enter...");
            Console.ReadLine();
        }

        public static void ShowStat() 
        {
            Player stat = new();
            Console.WriteLine("HP: " + stat._hp);
            Console.WriteLine("Name: " + stat.Name);
            Program.RedLine();
        }

    }

}