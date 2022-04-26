using System;
using System.IO;
namespace studentsmanage
{
    class Program
    {

        static void Main()
        {

            
            string updatecondition = ""; //termination condition for the nested (update user) loop
            string condition = "";//condition takes the user input to navigate the main menu
            int terminationcondition = 0; // an int variable initiated for the termination condition of the loop and to take inputs
            Console.WriteLine("Hello! welcome to the student manager portal");
            while (terminationcondition != -1)
            {//if user inputs -1 the loop terminates
                Console.WriteLine("*********************************************");
                Console.WriteLine("press 1 to see the list");
                Console.WriteLine("press 2 to register a new user");
                Console.WriteLine("press 3 to search by the registration");
                Console.WriteLine("press 4 to delete the user using registration number");
                Console.WriteLine("press 5 to update the user");
                Console.WriteLine("press -1 to exit");
                Console.WriteLine("*********************************************");
                condition = Console.ReadLine(); //user input to decide the next action

                if (condition == "1")
                {// if user inputs one we will print all the users in our file
                    


                    printAllUsers();




                }
                else if (condition == "2")
                { //if user inputs 2 we will take further inputs to register a new user
                    string tempString = "";
                   
                    //inserting reg#
                    tempString += generateRegistrationNumber() + "/";
                    //creates the empty string and then generates the registrationNumber and adds / for filing format.
                    Console.Write("input name                    :");
                    string input = Console.ReadLine();
                    while (!checkName(input))
                    {//check if name is valid if not takes input again and repeats
                        Console.Write("your name input was not valid, enter name again, do not use numbers or special characters:");
                        input = Console.ReadLine();
                    }
                    //inserting name by appending the tempString variable with name and /
                    tempString += input + "/";
                    Console.Write("input phone number            :");
                    input = Console.ReadLine();
                    while (!checkPhone(input))
                    {//check if name is valid if not takes input again and repeats
                        Console.WriteLine("Invalid phone number, please enter again. It should be at least 11 digits long and start with 0. :");
                        Console.Write("No letters or special characters allowed: ");
                        input = Console.ReadLine();
                    }
                    //inserting phone by appending the tempString variable with phone and /
                    tempString += input + "/";
                    Console.Write("input date of birth (yyyy-mm-dd):");//should check the format of the date
                    input = Console.ReadLine();
                    while (!checkdate(input))
                    {
                        Console.Write("invalid input!, input date of birth again (yyyy-mm-dd):");
                        input = Console.ReadLine();
                    }
                    //inserting dob by appending the tempString variable with dob and /
                    tempString += input + "/";
                    Console.Write("input designation             :");
                    input = Console.ReadLine();
                    while (!checkdesignation(input))
                    {
                        Console.Write("Invalid length, enter designation again:");
                        input = Console.ReadLine();
                    }
                    //inserting designation by appending the tempString variable with designation and /
                    tempString += input + "/";

                    //giving temporary string to the insertUser function.
                    insertUser(tempString);
                    tempString = "";//empties the tempstring Again.


                }
                else if (condition == "3")
                {//if user inputs 3 we take registration number as input search and show the user 
                    Console.WriteLine("Enter the registration number:");
                    string reg = Console.ReadLine();

                    printSearchedUser(reg);

                }
                else if (condition == "4")
                {//if user inputs 4 we take registration number and delete the user
                    Console.Write("Enter the registration number to delete the user:");
                    string input = Console.ReadLine();
                    deleteUser(input);
                }
                else if (condition == "5")
                   
                { //if user inputs 5 the nested loop starts with the termination condition of update==false
                    bool update = true;
                    Console.WriteLine("enter the registration number to update the user");
                    string input = "";
                    input = Console.ReadLine();
                    while (!checkValidRegistrationNumber(input))
                    {   //runs the loop while registration number is invalid and asks for inputs again
                        Console.Write("Invalid registration number!");
                        Console.Write("enter again or press x to return to main menu:");
                        input = Console.ReadLine();
                        if (input == "x")
                        {//if input is x then breaks
                            break;
                        }
                    }
                    if (input == "x")
                    {// here recieves the x as input and skips the  loop ahead.
                        continue;
                    }
                    string reg = input;
                    while (update)
                    {//the nested loop starts the update menu
                        Console.WriteLine("_________________________________");
                        Console.WriteLine("press 1 to update name:");
                        Console.WriteLine("press 2 to update phone number:");
                        Console.WriteLine("press 3 to update designmation:");
                        Console.WriteLine("press 0 to go back:");
                        updatecondition = Console.ReadLine();
                        if (updatecondition == "1")
                        { //condition 1 expects name and updates
                            Console.WriteLine("Enter new name:");
                            input = Console.ReadLine();
                            while (!checkName(input))
                            {//check if name is valid if not takes input again and repeats
                                Console.Write("your name input was not valid, enter name again:");
                                input = Console.ReadLine();
                            }
                            updateUser(input, reg, "name");
                            Console.Write("Name updated:");
                        }
                        else if (updatecondition == "2")
                        { //condition 2 expects phone number
                            Console.WriteLine("Enter new phone number:");
                            input = Console.ReadLine();
                            while (!checkPhone(input))
                            {//check if name is valid if not takes input again and repeats
                                Console.Write("invalid phone number, enter phone number again:");
                                input = Console.ReadLine();
                            }
                            updateUser(input, reg, "phone");
                            Console.Write("Phone number updated:");

                        }
                        else if (updatecondition == "3")
                        { //condition 3 expects designation
                            Console.WriteLine("Enter new designation:");
                            input = Console.ReadLine();
                            while (!checkdesignation(input))
                            {//check if name is valid if not takes input again and repeats
                                Console.Write("Invalid length, enter designation again:");
                                input = Console.ReadLine();
                            }
                            updateUser(input, reg, "designation");
                            Console.Write("Designation updated:");
                        }
                        else if (updatecondition == "0")
                        { //0 returns you to the main menu
                            update = false;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input check again");
                        }
                    }

                }
                else if (condition == "-1")
                {
                    terminationcondition = -1;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }


            }

            static bool checkName(string name)
            {//validates the name input
                int numericvalue;//creaing a integer variable for tryparse function
                for (int i = 0; i < name.Length; i++)
                {
                    if (Int32.TryParse(Char.ToString(name[i]), out numericvalue))
                    { //for tryparse: takes two arguments (an output variable, assigns converted
                      // value and also returns a boolean if the conversion was successful or not) 
                        return false;
                    }
                }
                if (name.Length < 3)
                {
                    return false;
                }
                return true;
            }

            static bool checkPhone(string phone)
            {
                //takes phonenumber (string) as an input and return the boolean for the checks
                int numericvalue;
                if (phone[0] != '0')
                {//checks the first char if it's 0
                    return false;
                }
                for (int i = 0; i < phone.Length; i++)
                {
                    if (!Int32.TryParse(Char.ToString(phone[i]), out numericvalue))
                    { //for tryparse: takes two arguments (an output variable, assigns converted
                      // value and also returns a boolean if the conversion was successful or not) 
                        return false;
                    }
                }
                if (phone.Length < 11)
                {//checks the length of the phone number
                    return false;
                }
                return true;
            }

            static bool checkdate(string date)
            {//validates the date
                //takes a string as an input and validates with the datetime object and matches format with the object
                DateTime datevar;
                if (!DateTime.TryParse(date, out datevar))
                {//checks for the date format(yyyy,mm,dd)
                    return false;
                }
                return true;
                //returns a  boolean (false)if invalid true otherwise
            }

            static bool checkdesignation(string designation)
            {//validates designation
                if (designation.Length > 3)
                {//checks for the length of the input string
                    return true;
                }
                return false;
                //returns true if the length is greater than 3 and false otherwise
            }

            bool checkValidRegistrationNumber(string reg)
            {//validates registration number
                StreamReader readingfile = new StreamReader("userfile.txt");

                //It looks for the file userfile.txt
                string inputline;
                while ((inputline = readingfile.ReadLine()) != null)
                {//loop runs until the file is empty and reads line by line
                 //and inserts it to the input line variable
                 //because the readingfile.Readline() function reads the current line and then goes to the next one
                 // after returning the current one.

                    string[] temporary = inputline.Split("/");
                    if (temporary[0] == reg)
                    {
                        readingfile.Close();
                        return true;
                    }


                }
                readingfile.Close();
                return false;

            }


            void printAllUsers()
            {
                
                try
                {
                    StreamReader readingfile = new StreamReader("userfile.txt");//It looks for the file userfile.txt
                    string inputline;//creates a string variable
                    while ((inputline = readingfile.ReadLine()) != null)
                    {//loop runs until the file is empty and reads line by line
                     //and inserts it to the input line variable
                     //because the readingfile.Readline() function reads the current line and then goes to the next one
                     // after returning the current one.


                        string[] temporary = inputline.Split("/");//spliting the read line and inserting it to a temporary array
                                                                  //reading the indexes and extracting information.
                        Console.WriteLine("Registration number       :" + temporary[0]);
                        Console.WriteLine("Name                      :" + temporary[1]);
                        Console.WriteLine("Phone number              :" + temporary[2]);
                        Console.WriteLine("Date of birth (yyyy-mm-dd):" + temporary[3]);
                        Console.WriteLine("Designation               :" + temporary[4]);
                        Console.WriteLine("____________________________");
                    }
                    readingfile.Close();//closing the readingfile
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No registered users yet, kindly press 2 to register a new user or -1 to exit the program");
                    //and then the menu displays again 
                }
            }

            void printSearchedUser(string registrationNumber)
            {
                try
                {
                    StreamReader readingfile = new StreamReader("userfile.txt");//It looks for the file userfile.txt
                    string inputline;
                    while ((inputline = readingfile.ReadLine()) != null)
                    {//loop runs until the file is empty and reads line by line
                     //and inserts it to the input line variable
                     //because the readingfile.Readline() function reads the current line and then goes to the next one
                     // after returning the current one.

                        string[] temporary = inputline.Split("/");
                        if (temporary[0] == registrationNumber)
                        {//it matches the registrationNumber in the function argument
                         //with registration number of every line in the file. if we find a match it prints the user 
                         //and returns (terminating and returning the control after the function)
                            Console.WriteLine("____________________________");
                            Console.WriteLine("User you requested for:");
                            Console.WriteLine("Registration number     : " + temporary[0]);
                            Console.WriteLine("Name                    :" + temporary[1]);
                            Console.WriteLine("Phone number            :" + temporary[2]);
                            Console.WriteLine("Date of birth (yyyy-mm-dd):" + temporary[3]);
                            Console.WriteLine("Designation             :" + temporary[4]);
                            Console.WriteLine("____________________________");
                            readingfile.Close();
                            return;
                        }

                    }
                    Console.WriteLine("There is no user with that registration number:");
                    readingfile.Close();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No registered users yet");
                }
            }

            string generateRegistrationNumber()
            {

                int max = 0;//initializing max variable to find the maximum reg#
                try
                {
                    StreamReader readingfile = new StreamReader("userfile.txt");//It looks for the file userfile.txt
                    string inputline;

                    while ((inputline = readingfile.ReadLine()) != null)
                    {//loop runs until the file is empty and reads line by line
                     //and inserts it to the input line variable
                     //because the readingfile.Readline() function reads the current line and then goes to the next one
                     // after returning the current one.

                        string[] temporary = inputline.Split("/");//spliting the lines on (/)
                        if (Int16.Parse(temporary[0]) > max)
                        {// if current registration number is greater than
                         //current max then it reassigns the max variable with the current registration number
                            max = Int16.Parse(temporary[0]);
                        }

                    }
                    readingfile.Close();

                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No registered users yet");
                }
                return (max + 1) + "";//returns the max+1 registration number


            }


            void insertUser(string user)
            {

                StreamWriter registrationFile = new StreamWriter("userfile.txt", append: true);
                registrationFile.WriteLine(user);
                registrationFile.Close();

            }

            void deleteUser(string registrationNumber)
            {
                //it creates a temporay file.
                //it reads all the lines from file userfile.txt and writes it to the temporary file
                //if it finds the matching registration number it skips that line.
                //it deletes the orignal userfile.txt and renames the temp file to userfile.txt.

                StreamReader readingfile = new StreamReader("userfile.txt");
                StreamWriter registrationFile = new StreamWriter("temp.txt");
                //It looks for the file userfile.txt
                string inputline;
                while ((inputline = readingfile.ReadLine()) != null)
                {//loop runs until the file is empty and reads line by line
                 //and inserts it to the input line variable
                 //because the readingfile.Readline() function reads the current line and then goes to the next one
                 // after returning the current one.

                    string[] temporary = inputline.Split("/");
                    if (temporary[0] == registrationNumber)
                    {//it matches the registration number with 
                     //every line and if it matches the registration number it skips that line
                        continue;
                    }
                    registrationFile.WriteLine(inputline);


                }
                readingfile.Close();
                registrationFile.Close();
                File.Delete("userfile.txt");
                File.Move("temp.txt", "userfile.txt");
                Console.WriteLine("The data of registration Number " + (registrationNumber) + "has been successfully deleted");


            }


            void updateUser(string StringToUpdate, string regNumberToUpdate, string updation)
            {
                //stringToUpdate has string which we are going to replace.
                //regNumberToUpdate is to match the registration numbers from file.
                //updation is the string suggesting what field is to be updated.

                //it creates a temporary file.
                //it reads all the lines from file userfile.txt and writes it to the temporary file
                //if it finds the matching registration number 
                // creats a temporary line with the format we are saving lines to the file with the new updatation.
                //it writes that temp line and skips the rest of the loop.
                //it deletes the orignal userfile.txt and renames the temp file to userfile.txt.
                StreamReader readingfile = new StreamReader("userfile.txt");
                StreamWriter registrationFile = new StreamWriter("temp.txt");
                //It looks for the file userfile.txt
                string inputline;
                string templine = "";
                while ((inputline = readingfile.ReadLine()) != null)
                {//loop runs until the file is empty and reads line by line
                 //and inserts it to the input line variable
                 //because the readingfile.Readline() function reads the current line and then goes to the next one
                 // after returning the current one.

                    string[] temporary = inputline.Split("/");
                    if (temporary[0] == regNumberToUpdate)
                    {

                        if (updation == "name")
                        {//if updation is name it creates the new temp line with changedname
                            templine = temporary[0] + "/" + StringToUpdate + "/" + temporary[2] + "/" + temporary[3] + "/" + temporary[4] + "/";
                        }
                        else if (updation == "phone")
                        {//if updation is phone it creates the new temp line with changed phone
                            templine = temporary[0] + "/" + temporary[1] + "/" + StringToUpdate + "/" + temporary[3] + "/" + temporary[4] + "/";
                        }
                        else if (updation == "designation")
                        {//if updation is designation it creates the new temp line with changed designation
                            templine = temporary[0] + "/" + temporary[1] + "/" + temporary[2] + "/" + temporary[3] + "/" + StringToUpdate + "/";
                        }
                        registrationFile.WriteLine(templine);
                        continue;
                    }
                    registrationFile.WriteLine(inputline);


                }
                readingfile.Close();
                registrationFile.Close();
                File.Delete("userfile.txt");
                File.Move("temp.txt", "userfile.txt");


            }

        }
    }
}