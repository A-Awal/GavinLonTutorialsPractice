//#define LOG_INFO
// See https://aka.ms/new-console-template for more information

// We have two types of attributes:
//     Predefined attributes(global and local) and
//     Custom attributes

using System.Reflection;
using System.Text.Json;
using Attributes.Models;
using LoggingComponent;
using ValidationComponent;

//[assembly:AssemblyVersion("2.0.1")]
[assembly:AssemblyDescription("My Assembly Description")]

Employee emp = new Employee();
Department dept = new Department();

string empId = null;
string firstName = null;
string postCode = null;
string deptShortName = null;


Type employeeType = typeof(Employee);
Type departmentType = typeof(Department);

if (GetInput(employeeType, "Please enter the employee's id", "Id", out empId)) 
{
    emp.Id = Int32.Parse(empId);
}
if (GetInput(employeeType, "Please enter the employee's first name", "FirstName", out firstName))
{
    emp.FirstName = firstName;
}
if (GetInput(employeeType, "Please enter the employee's post code", "PostCode", out postCode))
{
    emp.PostCode = postCode;
    
}
if (GetInput(departmentType, "Please enter the employee's department code", "DeptShortName", out deptShortName))
{
    dept.DeptShortName = deptShortName;
}
Console.WriteLine();
Console.BackgroundColor = ConsoleColor.DarkGreen;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"Thank you! Employee with first name, {emp.FirstName}, and Id, {emp.Id}, has been entered successfully!!");
Console.ResetColor();
   
Console.ReadKey();

var employeeJSON = JsonSerializer.Serialize<Employee>(emp);

Console.WriteLine(employeeJSON);

Console.ReadKey();


static bool GetInput(Type t, string promptText, string fieldName, out string fieldValue) 
{
    fieldValue = "";
    string enteredValue = "";
    string errorMessage = null;
    do
    {
        Console.WriteLine(promptText);
        
        enteredValue = Console.ReadLine();

        if (!Validation.PropertyValueIsValid(t, enteredValue, fieldName, out errorMessage))
        {
            fieldValue = null;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(errorMessage);
            Console.WriteLine();
            Console.ResetColor();
        }
        else 
        {
            fieldValue = enteredValue;
            break;
        }


    }
    while (true);

    return true;
}
static void OutPutGlobalAttributeInformation()
{
    
Assembly thisAssem = typeof(Program).Assembly;
AssemblyName assemName = thisAssem.GetName();
Version thisAssemVersion = assemName.Version;
object[] attributes = thisAssem.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), true);
AssemblyDescriptionAttribute custAss = attributes[0] as AssemblyDescriptionAttribute;
Console.WriteLine($"Assembly Name: {thisAssem}");
Console.WriteLine($"Assembly version: {thisAssemVersion}");

if (custAss != null)
{
    Console.WriteLine($"Assembly Description: {custAss.Description}");
}

Console.ReadKey();
}

static void TryConditionalAttribute()
{
//Logging.LogToScreen("I am trying my logging functionality");
Logging.LogToFile("Hold my phone");
Console.ReadKey();
}

//TryConditionalAttribute();

