namespace JudgeSystem._2024uc.Building
{
    public static class BuildingUtils
    {
        public static bool IsBase(this global::JudgeSystem.Building building)
        {
            return building.Id == Base.ID;
        }
    }
}