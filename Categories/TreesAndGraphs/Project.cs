using System;
using System.Collections.Generic;

namespace CodingInterviewPrep.TreesAndGraphs {
  
  public class Project {
    public string Name {get ; private set;}
    public List<Project> Children { get; private set; }
    private Dictionary<string, Project> LookupMap;
    public int NumberOfDependencies {get; private set;}


    public Project(string name) {
      this.Name = name;
      this.Children = new List<Project>();
      this.LookupMap = new Dictionary<string, Project>();
      this.NumberOfDependencies = 0;
    }

    public void DecrementDependencies() {
      this.NumberOfDependencies--;
    }

    public void IncrementDependencies() {
      this.NumberOfDependencies++;
    }
      
    public void AddDependency(Project other) {
      if (!LookupMap.ContainsKey(other.Name)) {
        Children.Add(other);
        LookupMap.Add(other.Name, other);
        other.IncrementDependencies();
      }
    }
  }
}