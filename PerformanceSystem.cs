namespace JudgeSystem
{
    /// <summary>
    /// 保存实体性能指标信息
    /// </summary>
    /// <typeparam name="T">Json struct 定义</typeparam>
    public abstract class PerformanceSystem<T> where T : struct
    {
        private static T _performance;
        
        public static V Read<V>(string key, V defaultValue = default)
        {
            return defaultValue;
        }
        
        public static void ReadFromJson<T>(string key, T target)
        {
            // JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), target);
        }
    }
}