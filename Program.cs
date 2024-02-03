using System.Text;

namespace Test2024
{
    abstract class LocationState
    {
        protected Place place;
        public Place Plase { set => place = value; }
       // public abstract void NextState();
        public virtual void PreviousState()
        {
            Console.WriteLine("Повернення до притулку...");
        }
        public virtual void Forest()
        {
            Console.WriteLine("Вихід в ліс...");
        }
        public virtual void Dungeon() 
        {
            Console.WriteLine("Вхід до підземелля...");
        }
       
    }

    class Place
    {
        private LocationState localstate;
        public Place(LocationState localstate) => SetState(localstate);

        public void SetState(LocationState ls)
        {
            localstate = ls;
            localstate.Plase = this;
        }
        //public void NextState()
        //{
        //    localstate.NextState();
        //}
        public void PreviousState()
        {
            localstate.PreviousState();
        }
    }
    class Dungeon : LocationState
    {
        //public override void NextState()
        //{
        //    Console.WriteLine("из подземки в в лес");
        //    place.SetState(new Forest());
        //}
        public override void PreviousState()
        {
            base.PreviousState();
        }
    }
   
    class Forest : LocationState 
    {

        //public override void NextState()
        //{
        //    Console.WriteLine("из леса в убежище");
        //    place.SetState(new Shelter());
        //}
        public override void PreviousState()
        {
            base.PreviousState();
        }
    } 
    class Shelter : LocationState
    {
        public override void Dungeon()
        {
            base.Dungeon();
        }
        public override void Forest()
        {
            base.Forest();
        }
        public override void PreviousState()
        {
            Console.WriteLine("подземка");
            place.PreviousState();
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
           /* if(a == 1)
                Console.WriteLine("Давай почнем гру!");
            if(a == 2)
                Console.WriteLine("Ем...давай грати?");*/

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

            // Place place = new Place(new Shelter());
            LocationState state = new Shelter();
                switch(i)
                {
                    case 1:
                        //Console.WriteLine("Ти в пошуках моба");
                        state.Dungeon();
                        break;
                    case 2:
                        //Console.WriteLine("Ти пошуках матеріала для крафта");
                        state.Forest();
                        break;
                    case 3:
                        //Console.WriteLine("Ти повернувся в притулок де є вогнище, і твоє хп відновилось!");
                        Console.WriteLine("Ти й так в притулку!");
                        Thread.Sleep(1000);
                        WriteChoiceActions();
                        break; 
                    default:
                        Console.WriteLine("Невірна цифра!");
                        break;
                }

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
        private void WriteChoiceAnswer(string a1, string a2)
        {
            Console.WriteLine($"\n1:{a1}\n2:{a2}\n");
        }
        private void WriteProgramResponse(string r1, string r2, int a)
        {
            if(a == 1) Console.WriteLine(r1);
            if(a == 2) Console.WriteLine(r2);
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