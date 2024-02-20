using JudgeSystem._2024uc.Buildings;
using Base = JudgeSystem._2024uc.Buildings.Base;

namespace JudgeSystem._2024uc
{
    public static class BuildingManagerExt
    {
        public static Base RBase(this BuildingManager buildingManager) => buildingManager[Camp.Red, Base.ID] as Base;
        public static Outpost ROutpost(this BuildingManager buildingManager) => buildingManager[Camp.Red, Outpost.ID] as Outpost;
        public static Exchanger RExchanger(this BuildingManager buildingManager) => buildingManager[Camp.Red, Exchanger.ID] as Exchanger;
        public static DartLauncher RDartLauncher(this BuildingManager buildingManager) => buildingManager[Camp.Red, DartLauncher.ID] as DartLauncher;
        
        public static Base BBase(this BuildingManager buildingManager) => buildingManager[Camp.Blue, Base.ID] as Base;
        public static Outpost BOutpost(this BuildingManager buildingManager) => buildingManager[Camp.Blue, Outpost.ID] as Outpost;
        public static Exchanger BExchanger(this BuildingManager buildingManager) => buildingManager[Camp.Blue, Exchanger.ID] as Exchanger;
        public static DartLauncher BDartLauncher(this BuildingManager buildingManager) => buildingManager[Camp.Blue, DartLauncher.ID] as DartLauncher;
        
        public static PowerRune PowerRune(this BuildingManager buildingManager) => buildingManager[Camp.Judge, Buildings.PowerRune.ID] as PowerRune;
    }
}