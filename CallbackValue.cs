namespace JudgeSystem
{
    public class CallbackValue<T>
    {
        private T _cachedValue;
        
        public T Value
        {
            get => _cachedValue;
            set
            {
                if (_cachedValue!=null && _cachedValue.Equals(value))
                    return;
                OnChange?.Invoke(_cachedValue, value);
                _cachedValue = value;
            }
        }
        
        public event System.Action<T, T> OnChange;
        
        public CallbackValue(T cachedValue = default)
        {
            _cachedValue = cachedValue;
        }
    }
}