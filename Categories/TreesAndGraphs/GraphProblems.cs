using System;
using System.Collections.Generic;

namespace CodingInterviewPrep.TreesAndGraphs {
  public class GraphProblems {
    public static void Run(){
      string[] projects = new string[] { "a", "b", "c", "d", "e", "f" };
      string[,] projectDependencies = new string[,] { 
        { "a", "d" },
        { "f", "b" },
        { "b", "d" },
        { "f", "a" },
        { "d", "c" }
      };

      Graph graph = createBuildGraph(projects, projectDependencies);

      Project[] buildOrder = orderProjects(graph.Nodes);
      if (buildOrder == null) {
        Console.WriteLine("No valid build order");
      } else {
        foreach(Project p in buildOrder) {
          Console.Write(p.Name + " ");
        }
      }
    }

    public static Project[] orderProjects(List<Project> projects) {
      Project[] order = new Project[projects.Count];


      int endOfList = addNonDependent(order, projects, 0);
      int buildPosition = 0;

      while (buildPosition < order.Length) {
        Project current = order[buildPosition];
        if (current == null) {
          // error, no expected state: circular reference
          return null;
        }

        // "Build" this project. AKA remove it as a dependency in children
        foreach (Project child in current.Children) {
          child.DecrementDependencies();
        }

        endOfList = addNonDependent(order, projects, endOfList);
        buildPosition++;
      }
      return order;
    }

    public static int addNonDependent(Project[] order, List<Project> projects, int index) {
      foreach(Project p in projects) {
        if (p.NumberOfDependencies == 0) {
          order[index] = p;
          index++;
        }
      }
      return index;
    }

    public static Graph createBuildGraph(string[] projects, string[,] dependecyList) {
      Graph g = new Graph();

      foreach (string s in projects) {
        g.getOrCreateNode(s);
      }

      for (int i = 0; i <  dependecyList.Length; i++) {
        g.AddEdge(dependecyList[i, 0], dependecyList[i, 1]);
      }

      return g;
    }
  }
}