using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();

var DatabaseSetup = new DatabaseSetup(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if (modelName == "Computer")
{
    var computerRepository = new ComputerRepository(databaseConfig);
    if (modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

        var computer = new Computer(id, ram, processor);

        computerRepository.Save(computer);
    }

    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if (computerRepository.ExistsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
        else { Console.WriteLine("Input value is not valid (id may not exist)"); }
    }

    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);

        if (computerRepository.ExistsById(id))
        {

            var ram = args[3];
            var processor = args[4];

            var computer = new Computer(id, ram, processor);

            computerRepository.Update(computer);
            Console.WriteLine("Updated");
        }
        else { Console.WriteLine("Input value is not valid (id may not exist)"); }
    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if (computerRepository.ExistsById(id))
        {
            computerRepository.Delete(id);
            Console.WriteLine("Deleted");
        }
        else { Console.WriteLine("Input value is not valid (id may not exist)"); }
    }
}

if (modelName == "Lab")
{
    var labRepository = new LabRepository(databaseConfig);

    if (modelAction == "List")
    {
        Console.WriteLine("Lab List");
        foreach (var lab in labRepository.GetAll())
        {
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
    }

    if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        var name = args[4];
        var block = args[5];

        var lab = new Lab(id, number, name, block);

        labRepository.Save(lab);
    }

    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if (labRepository.ExistsById(id))
        {
            var lab = labRepository.GetById(id);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
        else { Console.WriteLine("Input value is not valid (id may not exist)"); }
    }

    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);

        if (labRepository.ExistsById(id))
        {

            var number = args[3];
            var name = args[4];
            var block = args[5];

            var lab = new Lab(id, number, name, block);

            labRepository.Update(lab);
            Console.WriteLine("Updated");
        }
        else { Console.WriteLine("Input value is not valid (id may not exist)"); }
    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if (labRepository.ExistsById(id))
        {
            labRepository.Delete(id);
            Console.WriteLine("Deleted");
        }
        else { Console.WriteLine("Input value is not valid (id may not exist)"); }
    }
}