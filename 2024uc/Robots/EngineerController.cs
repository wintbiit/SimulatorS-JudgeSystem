using JudgeSystem._2024uc.Buffs;
using JudgeSystem._2024uc.Robots.Interfaces;

namespace JudgeSystem._2024uc.Robots
{
    public partial class Engineer: IEngineerController
    {
        private static readonly int[] Grades = {1, 2, 3, 4, 5};
        private static readonly int[] GradesWithBuff1 = {2, 3, 4, 5};
        private static readonly int[] GradesWithBuff2 = {3, 4, 5};
        private static readonly int[] GradesWithBuff3 = {4, 5};
        private static readonly int[] GradesWithBuff4 = {5};
        public int[] GetUsableGrades()
        {
            if (Buffs.Has<OreExchangerBuff1>())
            {
                return GradesWithBuff1;
            }
            else if (Buffs.Has<OreExchangerBuff2>())
            {
                return GradesWithBuff2;
            }
            else if (Buffs.Has<OreExchangerBuff3>())
            {
                return GradesWithBuff3;
            }
            else if (Buffs.Has<OreExchangerBuff4>())
            {
                return GradesWithBuff4;
            }
            else
            {
                return Grades;
            }
        }
    }
}