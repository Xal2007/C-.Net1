using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;

Dictionary<string, string> users = new Dictionary<string, string>(); 
string currentUser = null!;
Dictionary<string, List<string>> quizzes = new Dictionary<string, List<string>>(); 

 LoadQuizzesFromFile();
 LoadUsersFromFile();
 
 bool isRunning = true;
 while (isRunning)
 {
     Console.WriteLine("1. Enter");
     Console.WriteLine("2. Exit");
     Console.Write("Choose action: ");
     string choice = Console.ReadLine()!;

     switch (choice)
     {
         case "1":
             Login();
             break;
         case "2":
             isRunning = false;
             break;
         default:
             Console.WriteLine("Incorrect choice. Try again.");
             break;
     }
 }
void Login()
 {
     Console.Write("Enter login: ");
     string username = Console.ReadLine()!;

     if (users.ContainsKey(username))
     {
         Console.Write("Enter password: ");
         string password = Console.ReadLine()!;

         if (users[username] == password)
         {
             currentUser = username;
             Console.WriteLine("Succesfully entered!");
             ShowMainMenu();
         }
         else
         {
             Console.WriteLine("Incorrect password.");
         }
     }
     else
     {
         Console.WriteLine("Пользователь не найден.");
     }
 }
 void ShowMainMenu()
 {
     Console.WriteLine("----------------Main menu(admin)----------------");
     Console.WriteLine("1. Add new quiz");
     Console.WriteLine("2. Redact quizzes");
     Console.WriteLine("3. Delete quizzes");
     Console.WriteLine("4. Exit");
     Console.Write("Choose action: ");
     string choice = Console.ReadLine()!;

     switch (choice)
     {
         case "1":
             CreateNewQuiz();
             break;
         case "2":
             EditQuiz();
             break;
         case "3":
             DeleteQuiz();
             break;
         case "4":
             currentUser = null!;
             break;
         default:
             Console.WriteLine("Incorrect. Try again.");
             break;
     }
 }

void CreateNewQuiz()
 {
     Console.Write("Enter name of new quiz: ");
     string quizName = Console.ReadLine()!;
     quizzes.Add(quizName, new List<string>());

     bool isAddingQuestions = true;
     while (isAddingQuestions)
     {
         Console.WriteLine("Adding new question:");
         Console.Write("Text of question: ");
         string question = Console.ReadLine()!;
         quizzes[quizName].Add(question);

         Console.Write("Add one anothet? (yes or no): ");
         string addAnother = Console.ReadLine()!;
         if (addAnother == "no")
         {
             isAddingQuestions = false;
         }
     }

     SaveQuizzesToFile();
 }
 void EditQuiz()
        {
            Console.WriteLine("List of avilable quizzes:");
            foreach (var quiz in quizzes)
            {
                Console.WriteLine(quiz.Key);
            }

            Console.Write("Enter name for redact quiz: ");
            string quizName = Console.ReadLine()!;

            if (!quizzes.ContainsKey(quizName))
            {
                Console.WriteLine("Quiz is not found.");
                return;
            }

            List<string> questions = quizzes[quizName];
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                Console.Write("Redact question? (yes or no): ");
                string editQuestion = Console.ReadLine()!;
                if (editQuestion == "yes")
                {
                    Console.Write("Type new question: ");
                    questions[i] = Console.ReadLine()!;
                }
            }

            SaveQuizzesToFile();
        }
void DeleteQuiz()
{ 
            Console.WriteLine("List of avilable quizzes:");
 foreach (var quiz in quizzes)
 {
     Console.WriteLine(quiz.Key);
 }

 Console.Write("Enter name of quiz to delete it: ");
 string quizName = Console.ReadLine()!;

 if (quizzes.ContainsKey(quizName))
 {
     quizzes.Remove(quizName);
     SaveQuizzesToFile();
     Console.WriteLine("Quiz removed.");
 }
 else
 {
     Console.WriteLine("Quiz is not found.");
 }
 }
void LoadQuizzesFromFile()
{
    using (FileStream file = new FileStream("users.json", FileMode.Open))
    {
        quizzes = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(file)!;
    }
}
void SaveQuizzesToFile()
{
    using (FileStream file = new FileStream("quizzes.json", FileMode.Open))
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
