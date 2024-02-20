using JudgeSystem._2024uc.Building;

namespace JudgeSystem._2024uc
{
    public class BuildingManager: global::JudgeSystem.BuildingManager
    {
        public Base RBase => this[Camp.Red, Base.ID] as Base;
        public Outpost ROutpost => this[Camp.Red, Outpost.ID] as Outpost;
        public Exchanger RExchanger => this[Camp.Red, Exchanger.ID] as Exchanger;
        public DartLauncher RDartLauncher => this[Camp.Red, DartLauncher.ID] as DartLauncher;
        
        public Base BBase => this[Camp.Blue, Base.ID] as Base;
        public Outpost BOutpost => this[Camp.Blue, Outpost.ID] as Outpost;
        public Exchanger BExchanger => this[Camp.Blue, Exchanger.ID] as Exchanger;
        public DartLauncher BDartLauncher => this[Camp.Blue, DartLauncher.ID] as DartLauncher;
        
        public PowerRune PowerRune => this[Camp.Judge, PowerRune.ID] as PowerRune;
    }
}