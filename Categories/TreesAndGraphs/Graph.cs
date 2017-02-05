using System;
using System.Collections.Generic;

namespace CodingInterviewPrep.TreesAndGraphs {
  public class Graph {
    public List<Project> Nodes {get ; private set;}

    public Dictionary<string, Project> LookUpMap;

    public Graph() {
      this.Nodes = new List<Project>();
      this.LookUpMap = new Dictionary<string, Project>();
    }

    public Project getOrCreateNode(string nodeName) {
      if (!LookUpMap.ContainsKey(nodeName)) {
        Project p = new Project(nodeName);
        Nodes.Add(p);
        LookUpMap.Add(nodeName, p);
      }
      return LookUpMap[nodeName];
    }

    public void AddEdge(string first, string second) {
      Project p1 = getOrCreateNode(first);
      Project p2 = getOrCreateNode(second);
      p1.AddDependency(p2);
    }
  }

}