namespace CodingInterviewPrep.MultiThreading {
  using System;
  using System.Threading;
  class Chopstick {
    private object lockObj;
    private bool lockWasTaken;
    private int sleepTimeout;

    public int ID { get; set;}

    public Chopstick() {
      lockObj = new object();
      lockWasTaken = false;

      Random random = new Random();
      this.sleepTimeout = random.Next(100, 1000);
    }

    public bool TryPickUp() {
      lockWasTaken = false;
      Monitor.TryEnter(lockObj, ref lockWasTaken);
      Thread.Sleep(sleepTimeout);
      return lockWasTaken;
    }

    public void PutDown() {
      Thread.Sleep(sleepTimeout);
      if (Monitor.IsEntered(lockObj)) {
        Monitor.Exit(lockObj);
      }
    }
  }

  class Philosopher {
    private Chopstick left;
    private Chopstick right;
    public bool isHungry;
    private string name;
    public Philosopher(string name, Chopstick left, Chopstick right) {
      this.name = name;
      this.left = left;
      this.right = right;
      this.isHungry = true;
    }

    public void setChopstic(Chopstick c, bool left) {
      if (left) {
        this.left = c;
      } else {
        this.right = c;
      }
    }

    public Chopstick getChopstick(bool left) {
      return left ? this.left : this.right;
    }

    public void Eat() {
      while(this.isHungry) {
        Console.WriteLine("Philosoler: " + this.name + " is hungry.");
        Console.WriteLine("Philosoler: " + this.name + " is picking up left chopstick: " + this.left.ID);
        if (this.left.TryPickUp()) {
          Console.WriteLine("Philosoler: " + this.name + " is picking up right chopstick: " + this.right.ID); 
          if (this.right.TryPickUp()) {
            Console.WriteLine("Philosoler: " + this.name + " is eating.");
            Thread.Sleep(5000);
            Console.WriteLine("Philosoler: " + this.name + "  finished eating. Putting Chopsticks down.");
            this.left.PutDown();
            this.right.PutDown();
            this.isHungry = false;
          } else {
            Console.WriteLine("Philosoler: " + this.name + " is unable to get right chopstick, putting down left one.");
            this.left.PutDown();
          }
        } else {
          this.left.PutDown();
          Console.WriteLine("Philosoler: " + this.name + " is unable to get left chopstick");
        }
      }
    }
  }

  class DinnerTable {
    private Philosopher[] philosophers;

    public DinnerTable(int size) {
      philosophers = new Philosopher[size];

      // set left chopstick for each philosopher
      for (int i = 0; i < size; i++) {
        Chopstick c = new Chopstick();
        c.ID = i;
        philosophers[i] = new Philosopher(i.ToString(), c, null);
      }

      // set right chopstick
      for (int i = 0; i < size; i++) {
        Chopstick cur = null;
        if (i == 0) {
          cur = philosophers[size - 1].getChopstick(true);
        } else {
          cur = philosophers[i - 1].getChopstick(true);
        }
        philosophers[i].setChopstic(cur, false);
      }

      // check table setup
      for (int i = 0; i < size; i++) {
        Philosopher p = philosophers[i];
        Chopstick cLeft = p.getChopstick(true);
        Chopstick cRight = p.getChopstick(false);
        Console.WriteLine("Philosopher " + i + " has left chopstick " + cLeft.ID + " and right chopstick " + cRight.ID);
      } 
    }

    public void StartDining() {
      Console.WriteLine("Dinner started");
      foreach (Philosopher p in philosophers) {
        Thread t = new Thread(p.Eat);
        t.Start();
      }
      
      Console.WriteLine("Dinner finished");
    }
  }
} 