namespace JudgeSystem.Buffs
{
    public class RestrictedZonePenalty: IBuff
    {
        public RestrictedZone Zone;
        
        public RestrictedZonePenalty(RestrictedZone zone)
        {
            Zone = zone;
        }
    }
}