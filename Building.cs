using JudgeSystem.Interfaces;

namespace JudgeSystem
{
    public abstract class Building: IBuilding
    {
        public Camp Camp { get; }
        public ushort Id { get; }
        
        protected Building(Camp camp, ushort id)
        {
            Camp = camp;
            Id = id;
        }
    }
}