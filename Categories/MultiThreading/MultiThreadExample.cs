namespace CodingInterviewPrep.MultiThreading {
    using System;
    using System.Threading;

    class MultiThreadingExample {
        public static void Run() {
            Console.WriteLine("main thread starting worker thread...");
            ConcurrentBuffer cb = new ConcurrentBuffer(10);
            Producer p = new Producer(cb);
            Consumer c = new Consumer(cb);

            Thread p1 = new Thread(p.Produce);
            Thread c1 = new Thread(c.Consume);  
            p1.Start();
            c1.Start();  
            Console.WriteLine("main thread sleeping for 1 second...");  
            Thread.Sleep(1000);
            Console.WriteLine("main thread done.");  
        }
    }

    class Consumer {
        private ConcurrentBuffer buffer;

        public Consumer(ConcurrentBuffer buffer) {
            this.buffer = buffer;
        }
        public void Consume() {
            for (int i = 1; i < 100; i++) {
                Thread.Sleep(200);
                int readValue = buffer.Read();
                Console.WriteLine("Consumer read: " + readValue + ", buffer size: " + this.buffer.Size());
            }
        }
    }

    class Producer {
        private ConcurrentBuffer buffer;

        public Producer(ConcurrentBuffer buffer) {
            this.buffer = buffer;
        }
        public void Produce() {
            for (int i = 1; i < 100; i++) {
                Thread.Sleep(100);
                buffer.Write(i);
                Console.WriteLine("Producer wrote: " + i + ", buffer size: " + this.buffer.Size());
            }
        }
    }

    class ConcurrentBuffer {
        private int size;
        private int[] buffer;
        private int capacity;

        public ConcurrentBuffer(int capacity) {
            this.buffer = new int[capacity];
            this.capacity = capacity;
        }

        public void Write(int value) {
            lock(this) {
                if (this.size == this.capacity) {
                    this.buffer[this.size-1] = value;
                } else {
                    this.buffer[this.size] = value;
                    this.size++;
                }
            }
        }

        public int Read() {
            lock(this) {
                if (this.size == 0) {
                    return Int32.MinValue;
                } else {
                    this.size--;
                    return this.buffer[this.size];
                }
            }
        }

        public int Size() {
            lock(this) {
                return this.size;
            }
        }
    }
}