using System.Xml;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

Dictionary<string, string> users = new Dictionary<string, string>(); 
string? currentUser = null; 
Dictionary<string, List<string>> quizzes = new Dictionary<string, List<string>>(); 
Dictionary<string, Dictionary<string, int>> quizResults = new Dictionary<string, Dictionary<string, int>>();

bool isRunning = true;
while (isRunning)
{
Console.WriteLine("                                   ---------------------- Quiz --------------------------                     ");
Console.WriteLine("1. Login");
Console.WriteLine("2. Registration");
Console.WriteLine("3. Exit");
Console.Write("Choose action: ");
string choice = Console.ReadLine()!;

 if (choice == "1" || choice == "2")
 {
   if (File.Exists("users.json"))
   {LoadUsersFromFile(); }
 }

 switch (choice)
{
 case "1":
     Login();
     Console.Clear();
     break;
 case "2":
     Register();
     Console.Clear();
     break;
 case "3":
     isRunning = false;
     break;
 default:
     Console.WriteLine("Incorrect enter Try again.");
     break;
}

 }
 void Login()
 {
     Console.Clear();

     Console.WriteLine("                      ------------------------------------- Login --------------------------------");

    Console.Write("Enter login: ");
    string username = Console.ReadLine()!;

     if (users.ContainsKey(username))
     {
         Console.Write("Enter password: ");
         string password = Console.ReadLine()!;

         if (users[username] == password)
         {
             currentUser = username;
             Console.WriteLine("You have entered succesfully!");
             ShowMainMenu();
         }
         else
         {
             Console.WriteLine("Incorrect password.");
         }
     }
     else
     {
         Console.WriteLine("User isn't found.Try again");
     }
 }

 void Register()
 {
    Console.Clear();
    Console.WriteLine("                      ------------------------------------- Registration --------------------------------");
    Console.Write("Enter login: ");
     string username = Console.ReadLine()!;

     if (users.ContainsKey(username))
     {
         Console.WriteLine("User with this login is found yet.");
         return;
     }

     Console.Write("Enter password: ");
     string password = Console.ReadLine()!;

     Console.Write("Enter your birthday(DD.MM.YYYY): ");
     string birthday = Console.ReadLine()!;

     users.Add(username, password);
     SaveUsersToFile();
     Console.WriteLine("Registration have been succesfully been!");
 }

  void ShowMainMenu()
  {
    if (File.Exists("results.json")) LoadResultsFromFile();
    
    Console.Clear();
      
      Console.WriteLine("                     ---------------------------------- Main menu ----------------------------------");
      Console.WriteLine("1. Start new quiz");
      Console.WriteLine("2. View results from finished quizes");
      Console.WriteLine("3. Exit");
      Console.Write("Choose action: ");
      string choice = Console.ReadLine()!;
  
      switch (choice)
      {
          case "1":
           StartNewQuiz();
              break;
          case "2":
              ShowResults();
              break;
          case "3":
              currentUser = null;
              break;
          default:
              Console.WriteLine("Incorrect enter Try again.");
              break;
      }
  }
void StartNewQuiz()
{
    Console.Clear();
    Console.WriteLine("!!!!!! PLEASE WHEN YOU SEE THE VARIANTS ANSWERS ANSWER ONLY ONE BIG LETTER,BECAUSE SMALL LETTER IS INCORRECT ANSWER!!!!!");
    Console.WriteLine(@"!!!! PLEASE WHEN YOU SEE THE True-False ANSWERS ANSWER ONLY True OR False,BECAUSE ANOTHER TYPINGS IS INCORRECT ANSWER!!!");
    Console.WriteLine("\nChoose category of quiz:");
    Console.WriteLine("1. History");
    Console.WriteLine("2. Geography");
    Console.WriteLine("3. Biology");
    Console.WriteLine("4. Mixed quiz");
    Console.Write("Choose category: ");
    string category = Console.ReadLine()!;

    List<string> questions = GetQuizQuestions(category);
    if (questions.Count == 0)
    {
        Console.WriteLine("Quiz with this category isn't access yet.");
        return;
    }

    int score = 0;
    int numb_question = 1 ;
    foreach (string question in questions)
    {
        Console.Clear();
        Console.Write($"{numb_question}) ");
        Console.WriteLine(question);
        Console.Write("Enter answer: ");
        string userAnswer = Console.ReadLine()!;
        if (CheckAnswer(question, userAnswer))
        {
            score++;
        }
        numb_question++;
    }

    Console.WriteLine($"Correct answers: {score} of {questions.Count}");
    UpdateQuizResults(category, score);
}

List<string> GetQuizQuestions(string category)
{
    List<string> questions = new List<string>();

    if (category == "1")
    {
        questions.Add("In what year did the Second World War take place?");
        questions.Add("Who was the last emperor of Russia?");
        questions.Add("Where did Joseph Stalin, Winston Churchill, and Franklin D. Roosevelt meet following the conclusion of WW2?");
        questions.Add("When did the Berlin Wall fall?");
        questions.Add("Bosnia and Herzegovina was part of what former European country?");
        questions.Add("Who was the first explorer to sail around the world?");
        questions.Add("On what island was Napoleon born?"); 
        questions.Add("True or False: Sweden was neutral in WWII? (Type True or False)");
        questions.Add("Whose statue stand in Trafallgar square?");
        questions.Add("How many of the 7 Ancient Wonders were located in modern-day Egypt?");

    }
    else if (category == "2") // География
    {
        questions.Add("What is the longest river in the world?");
        questions.Add("Capital of France?");
        questions.Add("Where are the Great Pyramids of Giza located?");
        questions.Add("What type of leaf is on the Canadian flag?");
        questions.Add("The White Sea is located next to which country?");
        questions.Add("What is the capital city of Morocco?");
        questions.Add("Oslo is the capital of which country?");
        questions.Add("What is the capital city of Portugal?");
        questions.Add("Which capital city is known as 'the capital of Europe'?");
        questions.Add("Hanoi is the capital city of which country?");
    }
    else if (category == "3")
    {
        questions.Add("What do fish breathe?");
        questions.Add("Which animal is the symbol of Australia?");
        questions.Add(@"Ozone hole refers to: 
                        A)hole in ozone layer
                        B)decrease in the ozone layer in troposphere
                        C)decrease in thickness of ozone layer in stratosphere
                        D)increase in the thickness of ozone layer in troposphere");
        questions.Add(@"Plants receive their nutrients mainly from: 
                        A)chlorophyll
                        B)atmosphere
                        C)light
                        D)soil");
        questions.Add(@"Photosynthesis generally takes place in which parts of the plant?
                        A)Leaf and other chloroplast bearing parts
                        B)stem and leaf
                        C)Roots and chloroplast bearing parts
                        D)Bark and leaf");
        questions.Add(@"One of the following is not a function of bones:
                        A)Place for muscle attachment
                        B)Protection of vital organs
                        C)Secretion of hormones for calcium regulation in blood and bones
                        D)Production of blood corpuscles");
        questions.Add(@"Process of cell division can take place by:
                        A)heterosis
                        B)fusion
                        C)mitosis
                        D)None of these");
        questions.Add(@"Most highly intelligent mammals are:
                        A)whales
                        B)dolphins
                        C)elephants
                        D)kangaroos");
        questions.Add(@"Prokaryotic cells lack
                        A)nucleolus
                        B)nuclear membrane
                        C)membrane bound by organelles
                        D)All of these");
        questions.Add(@"Photosynthesis takes place faster in
                         A)yellow light
                         B)white light
                         C)red light
                         D)darkness");
        questions.Add(@"Plants that grow in saline water are called:
                        A)halophytes
                        B)hydrophytes
                        C)mesophytes
                        D)thallophytes");
        questions.Add(@"Myopia is connected with: 
                        A)ears
                        B)eyes
                        C)lungs
                        D)None of these");

    }
    else if (category == "4") // Смешанная викторина
    {
        questions.AddRange(GetQuizQuestions("1")); // История
        questions.AddRange(GetQuizQuestions("2")); // География
        questions.AddRange(GetQuizQuestions("3")); // Биология
    }
    return questions;
}
bool CheckAnswer(string question, string userAnswer)
{
    if (question.Contains("Second World War") && userAnswer == "1941-1945")
    {
        return true;
    }
    else if (question.Contains("the last emperor of Russia") && userAnswer == "Nicholas II")
    {
        return true;
    }
    else if (question.Contains("Joseph Stalin, Winston Churchill") && userAnswer == "Yalta")
    {
        return true;
    }
    else if (question.Contains("Berlin Wall fall") && userAnswer == "1989")
    {
        return true;
    }
    else if (question.Contains("Bosnia and Herzegovina") && userAnswer == "Yugoslavia")
    {
        return true;
    }
    else if (question.Contains("the first explorer") && userAnswer == "Ferdinand Magellan")
    {
        return true;
    }
    else if (question.Contains("Napoleon born") && userAnswer == "Corsica")
    {
        return true;
    }
    else if (question.Contains("Sweden was neutral") && userAnswer == "True")
    {
        return true;
    }
    else if (question.Contains("stand in Trafallgar") && userAnswer == "Lord Nelson")
    {
        return true;
    }
    else if (question.Contains("7 Ancient Wonders") && userAnswer == "2")
    {
        return true;
    }
    else if (question.Contains("the longest river in the world") && userAnswer == "Amazon")
    {
        return true;
    }
    else if (question.Contains("Capital of France") && userAnswer == "Paris")
    {
        return true;
    }
    else if (question.Contains("the Great Pyramids of Giza") && userAnswer == "Egypt")
    {
        return true;
    }
    else if (question.Contains("on the Canadian flag") && userAnswer == "A maple leaf")
    {
        return true;
    }
    else if (question.Contains("The White Sea") && userAnswer == "Russia")
    {
        return true;
    }
    else if (question.Contains("the capital city of Morocco") && userAnswer == "Rabat")
    {
        return true;
    }
    else if (question.Contains("Oslo is the capital") && userAnswer == "Norway")
    {
        return true;
    }
    else if (question.Contains("the capital city of Portugal") && userAnswer == "Lisbon")
    {
        return true;
    }
    else if (question.Contains("the capital of Europe") && userAnswer == "Brussels")
    {
        return true;
    }
    else if (question.Contains("Hanoi is the capital") && userAnswer == "Vietnam")
    {
        return true;
    }
    else if (question.Contains("fish breathe") && userAnswer == "with gills")
    {
        return true;
    }
    else if (question.Contains("the symbol of Australia") && userAnswer == "Kangaroo")
    {
        return true;
    }
    else if (question.Contains("Ozone hole refers to") && userAnswer == "C")
    {
        return true;
    }
    else if (question.Contains("Plants receive their") && userAnswer == "D")
    {
        return true;
    }
    else if (question.Contains("Photosynthesis generally takes") && userAnswer == "A")
    {
        return true;
    }
    else if (question.Contains("One of the following") && userAnswer == "C")
    {
        return true;
    }
    else if (question.Contains("Process of cell division") && userAnswer == "C")
    {
        return true;
    }
    else if (question.Contains("intelligent mammals") && userAnswer == "B")
    {
        return true;
    }
    return false;
}

void UpdateQuizResults(string category, int score)
{
    if (!quizResults[currentUser].ContainsKey(category))
    {
        quizResults[currentUser].Add(category, score);
    }
    else
    {
        quizResults[currentUser][category] = score;
    }
    SaveResultsToFile();
}

void LoadResultsFromFile()
{
    using (FileStream file = new FileStream("results.json", FileMode.Open))
    {
        quizResults = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(file)!;
    }
}

void SaveResultsToFile()
{
 using (FileStream file = new FileStream("results.json", FileMode.OpenOrCreate))
 {
     JsonSerializerOptions options = new JsonSerializerOptions();
     options.WriteIndented = true;
     JsonSerializer.Serialize(file, quizResults, options);
 }
}
void LoadQuizzesFromFile()
{
    using (FileStream file = new FileStream("quizzes.json", FileMode.Open))
    {
        quizzes = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(file)!;
    }
}
void SaveQuizzesToFile()
{
 using (FileStream file = new FileStream("quizzes.json", FileMode.OpenOrCreate))
 {
    JsonSerializerOptions options = new JsonSerializerOptions();
    options.WriteIndented = true;
    JsonSerializer.Serialize(file, quizzes, options);
 }
}
void LoadUsersFromFile()
{
    using (FileStream file = new FileStream("users.json", FileMode.Open))
    {
        users = JsonSerializer.Deserialize<Dictionary<string, string>>(file)!;
    }
}
void SaveUsersToFile()
{
    using (FileStream file = new FileStream("users.json", FileMode.OpenOrCreate))
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        JsonSerializer.Serialize(file, users, options);
    }
}
void ShowResults()
{
    Console.WriteLine("Last quizzes result:");
    foreach (var result in quizResults[currentUser])
    {
        Console.WriteLine($"Category: {result.Key}, Result: {result.Value}");
    }
}