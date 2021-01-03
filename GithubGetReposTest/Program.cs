using System;

namespace GithubGetReposTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var lol = Repository.GetRepositories("https://api.github.com/users/gymnasy55/repos?sort=updated").Result;
            foreach (var repository in lol) Console.WriteLine($"{repository.Name}: {repository.Url}");
        }
    }
}