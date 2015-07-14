namespace ConsoleApplication1
{
    public struct Optional<T>
    {
        /// <summary>
        /// Initializes a new instance to the specified value.
        /// </summary>
        /// <param name="value"></param>
        public Optional(T value)
        {
            HasValue = true;
            Value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the current object has a value.
        /// </summary>
        /// <returns></returns>
        public bool HasValue { get; }

        /// <summary>
        /// Gets the value of the current object.
        /// </summary>
        /// <returns></returns>
        public T Value { get; }

        /// <summary>
        /// Creates a new object initialized to a specified value. 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }
    }
}