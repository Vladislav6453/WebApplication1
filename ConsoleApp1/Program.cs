//1
//using System.Net.Http.Json;
//using WebApplication1.SQRS.DTO;

//Console.Write("Введите ID группы:");
//int ID = int.Parse(Console.ReadLine());
//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("http://localhost:5251/api/");
//var result = await client.GetAsync($"Students/SpisokStudentByGroupId/{ID}");
//var data = await result.Content.ReadFromJsonAsync<StudentDTO[]>();
//Console.WriteLine($"Количество студентов этой группы {data.Length}.");
//foreach (StudentDTO i in data)
//{
//    Console.WriteLine($"Имя - {i.FirstName}, фамилия - {i.LastName}.");
//}
//Console.ReadLine();

//2
using System.Net.Http.Json;
using WebApplication1.SQRS.DTO;

//Console.Write("Введите ID группы:");
//int ID = int.Parse(Console.ReadLine());
//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("http://localhost:5251/api/");
//var result = await client.GetAsync($"Students/SpisokStudentByGroupIdToGenders/{ID}");
//var data = await result.Content.ReadFromJsonAsync <GendersCountDTO>();
//Console.WriteLine($"Мальчики - {data.MaleCount}, девочки - {data.FemaleCount}.");
//Console.ReadLine();

//3
//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("http://localhost:5251/api/");
//var result = await client.GetAsync($"Students/GetListStudentsOutGroups");
//var data = await result.Content.ReadFromJsonAsync<IEnumerable< StudentDTO>>();
//Console.WriteLine($"Без группы у нас всего {data.Count()} студента.");
//Console.ReadLine();

//4
//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("http://localhost:5251/api/");
//var result = await client.GetAsync($"Students/GetListGroupsOutStudents");
//var data = await result.Content.ReadFromJsonAsync<IEnumerable<GroupDTO>>();
//Console.WriteLine($"Без студентов у нас всего {data.Count()} групп.");
//Console.ReadLine();

//5
//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("http://localhost:5251/api/");
//var result = await client.GetAsync($"Students/GetListGroupsWithStudents");
//var data = await result.Content.ReadFromJsonAsync<IEnumerable<GroupDTO>>();
//Console.WriteLine($"У нас всего {data.Count()} групп.");
//foreach (GroupDTO i in data)
//{
//    Console.WriteLine($"Название группы - {i.Title}, количество ее студентов - {i.StudentCount}.");
//}
//Console.ReadLine();

//6
Console.Write("Введите ID специальность группы:");
int spec = int.Parse(Console.ReadLine());
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5251/api/");
var result = await client.GetAsync($"Students/GetListGroupsWithStudentsWithIndex/{spec}");
var data = await result.Content.ReadFromJsonAsync<IEnumerable<GroupDTO>>();
Console.WriteLine($"У нас всего {data.Count()} групп со специальностью с ID {spec}.");
foreach (GroupDTO i in data)
{
    Console.WriteLine($"Название группы - {i.Title}, количество ее студентов - {i.StudentCount}.");
}
Console.ReadLine();