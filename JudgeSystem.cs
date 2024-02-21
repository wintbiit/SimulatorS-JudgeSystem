using System;
using System.Collections.Concurrent;
using System.Threading;
using Event;
using JudgeSystem.Event;

namespace JudgeSystem
{
    public abstract class JudgeSystem: Entity, IDisposable
    {
        protected readonly Thread WorkerThread;
        protected readonly ConcurrentQueue<Action> TaskQueue;
        protected readonly AutoResetEvent TaskNewEvent;
        protected readonly Timer Timer;
        protected MatchConfig Config { get; }
        
        public JudgeSystem(int maxTime, MatchConfig matchConfig, Economy economy)
        {
            MaxTime = maxTime;
            Config = matchConfig;
            Economy = economy;
            
            TaskQueue = new ConcurrentQueue<Action>();
            TaskNewEvent = new AutoResetEvent(false);
            WorkerThread = new Thread(WorkerThreadFunc);
            WorkerThread.Start();
            Timer = new Timer(Tick, null, 0, 1000);
            Stop();
        }
        
        public MatchConfig MatchConfig { get; protected set; }
        public RobotManager RobotManager { get; } = new();
        public ZoneManager ZoneManager { get; } = new();
        public BuildingManager BuildingManager { get; } = new();
        public Economy Economy { get; }
        public int Time { get; protected set; } = 0;
        protected int MaxTime { get; }
        
        public void EnqueueTask(Action task)
        {
            TaskQueue.Enqueue(task);
            TaskNewEvent.Set();
        }

        private void WorkerThreadFunc()
        {
            while (true)
            {
                TaskNewEvent.WaitOne();

                while (TaskQueue.TryDequeue(out var task))
                {
                    task.Invoke();
                }
            }
        }

        public void Start()
        {
            Timer.Change(0, Config.TickPeriod);
        }

        public void Stop()
        {
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        
        private readonly TickEvent _tickEvent = new();
        private readonly GameStartEvent _gameStartEvent = new();
        private readonly GameOverEvent _gameOverEvent = new();
        private readonly StatisticOverEvent _statisticOverEvent = new();
        private void Tick(object _)
        {
            Time += 1;
            _tickEvent.Time = Time;
            _tickEvent.Publish();

            if (Time == Config.WaitTime)
            {
                _gameStartEvent.Publish();
            }
            else if (Time == MaxTime + Config.WaitTime)
            {
                _gameOverEvent.Publish();
            }
            else if (Time == MaxTime + Config.StatisticTime + Config.WaitTime)
            {
                _statisticOverEvent.Publish();
            }
            else if (Time == MaxTime + Config.StatisticTime + Config.WaitTime + 5)
            {
                Stop();
            }
        }
        
        public void Dispose()
        {
            WorkerThread.Abort();
            Timer.Dispose();
        }

        public void Reset()
        {
            Time = 0;
        }

        public void Wait()
        {
            WorkerThread.Join();
        }
    }
}